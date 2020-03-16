/* MagiCore.MathParsing
 * Copyright(c) 2017 Michael Marvin

 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ScrapYard.Utilities
{
    public class MathParsing
    {
        private static Dictionary<string, double> formulaCache = new Dictionary<string, double>();


        /// <summary>
        /// Replace all instances of variables with their provided values
        /// </summary>
        /// <param name="identifier">An identifier for the string</param>
        /// <param name="input">The string to replace variables on</param>
        /// <param name="variables">The Dictionary containing the variables and their values</param>
        /// <returns>A string with the variables replaced</returns>
        public static string ReplaceMathVariables(string identifier, string input, Dictionary<string, string> variables)
        {
            if (variables?.ContainsKey("true") == false) variables["true"] = "1";
            if (variables?.ContainsKey("false") == false) variables["false"] = "0";
            //raise an event to allow other mods to add variables
            EventBehavior.EventBehaviour.onSYVariableReplacing.Fire(identifier, variables);

            string cpy = input;
            if (variables != null)
            {
                foreach (KeyValuePair<string, string> kvp in variables)
                {
                    if (!string.IsNullOrEmpty(kvp.Key))
                    {
                        cpy = cpy.Replace("[" + kvp.Key + "]", kvp.Value);
                    }
                }

                //we also replace "true" and "false" with 1 and 0, but only if they are the word by themselves
                Regex trueReplace = new Regex(@"(?i)\btrue\b");
                cpy = trueReplace.Replace(cpy, variables["true"]);

                Regex falseReplace = new Regex(@"(?i)\bfalse\b");
                cpy = falseReplace.Replace(cpy, variables["false"]);
            }
            return cpy;
        }

        /// <summary>
        /// Takes a string and evaluates it as a mathematical expression, replacing any variables "ie, [X]" with the provided values
        /// </summary>
        /// <param name="identifier">An identifier for the string</param>
        /// <param name="input">The string to evaluate</param>
        /// <param name="variables">The Dictionary containing the variables and their values</param>
        /// <returns>The result of the evaluation</returns>
        public static double ParseMath(string identifier, string input, Dictionary<string, string> variables)
        {
            string inputBackup = input;
            double currentVal = 0;
            string stack = "";
            try
            {
                if (identifier != null) //recursive calls will pass null to avoid firing the events
                {
                    input = ReplaceMathVariables(identifier, input, variables);

                    inputBackup = input;

                    //check for a cached value, if found then return the cached value
                    if (formulaCache.TryGetValue(inputBackup, out currentVal))
                    {
                        return currentVal;
                    }
                }

                //No cached value, compute it

                string lastOp = "+";
                string[] ops = { "+", "-", "*", "/", "%", "^", "(", "e", "E" };
                string[] functions = { "min", "max", "l", "ln", "L", "log", "abs", "sign", "if" }; //if (a < b ? stuff : other stuff)
                for (int i = 0; i < input.Length; ++i)
                {
                    string ch = input[i].ToString();
                    bool isOp = false, isFunction = false;
                    foreach (string op in ops)
                    {
                        if (op == ch)
                        {
                            isOp = true;
                            break;
                        }
                    }
                    if (!isOp)
                    {
                        foreach (string fun in functions)
                        {
                            if (fun[0] == input[i])
                            {
                                isFunction = true;
                                break;
                            }
                        }
                    }

                    if (isOp)
                    {
                        if (ch == "-" && (stack.Trim() == ""))
                        {
                            stack += ch;
                        }
                        else if (ch == "e" || ch == "E")
                        {
                            int index;
                            for (index = i + 2; index < input.Length; ++index)
                            {
                                string ch2 = input[index].ToString();
                                if (ops.Contains(ch2))
                                    break;
                            }
                            string sub = input.Substring(i + 1, index - i - 1);
                            double exp = ParseMath(null, sub, null);
                            double newVal = double.Parse(stack) * Math.Pow(10, exp);
                            currentVal = DoMath(currentVal, lastOp, newVal.ToString());
                            stack = "0";
                            lastOp = "+";
                            i = index - 1;
                        }
                        else if (ch == "(")
                        {
                            int j = FindEndParenthesis(input, i)[0];
                            string sub = input.Substring(i + 1, j - i - 1);
                            string val = ParseMath(null, sub, null).ToString();
                            input = input.Substring(0, i) + val + input.Substring(j + 1);
                            --i;
                        }
                        else
                        {
                            currentVal = DoMath(currentVal, lastOp, stack);
                            lastOp = ch;
                            stack = "";
                        }
                    }
                    else if (isFunction)
                    {
                        int subStart = input.IndexOf('(', i) + 1;
                        string function = input.Substring(i, subStart - i - 1);
                        int[] parenComma = FindEndParenthesis(input, subStart - 1);
                        int j = parenComma[0];
                        int comma = parenComma[1];
                        string sub = input.Substring(subStart, j - subStart);
                        double val = 0.0;

                        if (function == "if")
                        {
                            val = DoIfStatement(sub);
                        }
                        else if (function == "l" || function == "ln")
                        {
                            val = ParseMath(null, sub, null);
                            val = Math.Log(val);
                        }
                        else if (function == "L" || function == "log")
                        {
                            val = ParseMath(null, sub, null);
                            val = Math.Log10(val);
                        }
                        else if (function == "max" || function == "min")
                        {
                            string[] parts = new string[2];
                            parts[0] = input.Substring(subStart, comma - subStart);
                            parts[1] = input.Substring(comma + 1, j - comma - 1);
                            double sub1 = ParseMath(null, parts[0], null);
                            double sub2 = ParseMath(null, parts[1], null);
                            if (function == "max")
                                val = Math.Max(sub1, sub2);
                            else if (function == "min")
                                val = Math.Min(sub1, sub2);
                        }
                        else if (function == "sign")
                        {
                            val = ParseMath(null, sub, null);
                            if (val >= 0)
                                val = 1;
                            else
                                val = -1;
                        }
                        else if (function == "abs")
                        {
                            val = ParseMath(null, sub, null);
                            val = Math.Abs(val);
                        }

                        input = input.Substring(0, i) + val.ToString() + input.Substring(j + 1);
                        i--;
                    }
                    else
                    {
                        stack += ch;
                    }
                }
                currentVal = DoMath(currentVal, lastOp, stack);

                //cache the result so we can avoid computing it in the future
                if (identifier != null)
                {
                    formulaCache[inputBackup] = currentVal;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, string.Format("Exception encountered while parsing '{0}' : '{1}'. Current value: '{2}' Stack: {3}", identifier, input, currentVal, stack));
                currentVal = 0;
            }
            return currentVal;
        }

        /// <summary>
        /// Locates the terminating paranthesis for the given position. Also finds the location of any commas (for max, min, etc)
        /// </summary>
        /// <param name="str">The string to search</param>
        /// <param name="curPos">The current position in the string</param>
        /// <returns>An int[2] of the end position and the location of any appropriate comma.</returns>
        private static int[] FindEndParenthesis(string str, int curPos)
        {
            int depth = 0;
            int j = 0, commaPos = -1;
            for (j = curPos + 1; j < str.Length; ++j)
            {
                if (str[j] == '(') depth++;
                if (str[j] == ')') depth--;

                if (str[j] == ',' && depth == 0)
                    commaPos = j;

                if (depth < 0)
                {
                    break;
                }
            }
            return new int[] { j, commaPos };
        }

        /// <summary>
        /// Takes the current value and performs the requested operation on it
        /// </summary>
        /// <param name="currentVal">The current value</param>
        /// <param name="operation">The operation to perform</param>
        /// <param name="newVal">The new value string to "add" to the current value</param>
        /// <returns>The new value after the operation</returns>
        private static double DoMath(double currentVal, string operation, string newVal)
        {
            double newValue = 0;
            if (String.IsNullOrEmpty(newVal))
                return currentVal;
            if (!double.TryParse(newVal, out newValue))
            {
                UnityEngine.Debug.LogError("[MagiCore] Tried to parse a non-double value: " + newVal);
                return currentVal;
            }
            switch (operation)
            {
                case "+": currentVal += newValue; break;
                case "-": currentVal -= newValue; break;
                case "*": currentVal *= newValue; break;
                case "/": currentVal /= newValue; break;
                case "%": currentVal = currentVal % long.Parse(newVal); break;
                case "^": currentVal = Math.Pow(currentVal, newValue); break;
                default: break;
            }

            return currentVal;
        }

        /// <summary>
        /// Performs parsing of inline if statements
        /// </summary>
        /// <param name="statement">The statement string to act on</param>
        /// <returns>The result of the if statement</returns>
        private static double DoIfStatement(string statement)
        {
            //At this point "statement" would look something like a < b ? stuff : other stuff
            //We need to grab the conditional and the two possible values, then do the conditional and evaluate the correct value
            string[] mathConditionals = { "<", ">", "<=", ">=", "==", "!=" }; //do we want to support && and ||, too? Ideally yes, but it's way tougher
            string[] stringConditionals = { " seq ", " sneq " };

            string[] conditionals = mathConditionals.Concat(stringConditionals).ToArray();
            double val = 0.0;

            try
            {
                // Debug.Log("MagiCore: Statement = " + statement);

                int indexOfQMark = statement.IndexOf("?");
                string conditionalSection = statement.Substring(0, indexOfQMark);
                //string[] condSides = conditionalSection.Split(conditionals, StringSplitOptions.RemoveEmptyEntries);
                foreach (string conditional in conditionals)
                    conditionalSection = conditionalSection.Replace(conditional, ";" + conditional + ";");
                string[] parts = conditionalSection.Split(';');
                //this is a kind of horrible method that I got from here, but avoided excessive regex: http://stackoverflow.com/a/2484982

                //lets assume there are only three elements
                if (parts.Length < 3)
                    return 0.0;

                //check that we aren't doing string comparisons, if so then we don't parse math on val1 or val2

                string condition = parts[1].Trim();
                double val1 = 0;
                double val2 = 0;

                string val1S = parts[0].Trim();
                string val2S = parts[1].Trim();

                if (mathConditionals.Contains(condition))
                {
                    //do math on part one
                    //do math on part two
                    //compare them
                    val1 = ParseMath(null, parts[0], null);
                    val2 = ParseMath(null, parts[2], null);
                }
                // Debug.Log("MagiCore: val1 = " + val1);
                // Debug.Log("MagiCore: val2 = " + val2);

                int indexOfColon = indexOfQMark;
                int depth = 0;
                for (int i = indexOfQMark + 1; i < statement.Length; i++)
                {
                    char s = statement[i];
                    if (s == '(') depth++;
                    if (s == ')') depth--;

                    if (s == ':' && depth == 0)
                        indexOfColon = i;

                    if (depth < 0)
                        break;
                }

                string leftOption = statement.Substring(indexOfQMark + 1, indexOfColon - indexOfQMark - 1);//starts at "?" and ends at last ":" for this depth
                string rightOption = statement.Substring(indexOfColon + 1); //starts at last ":" and ends at end of statment

                // Debug.Log("MagiCore: left option = " + leftOption);
                // Debug.Log("MagiCore: right option = " + rightOption);

                string selectedOption = "";

                switch (condition)
                {
                    case "<": selectedOption = val1 < val2 ? leftOption : rightOption; break;
                    case ">": selectedOption = val1 > val2 ? leftOption : rightOption; break;
                    case "<=": selectedOption = val1 <= val2 ? leftOption : rightOption; break;
                    case ">=": selectedOption = val1 >= val2 ? leftOption : rightOption; break;
                    case "==": selectedOption = val1 == val2 ? leftOption : rightOption; break;
                    case "!=": selectedOption = val1 != val2 ? leftOption : rightOption; break;
                    case "seq": selectedOption = string.Equals(val1S, val2S, StringComparison.Ordinal) ? leftOption : rightOption; break;
                    case "sneq": selectedOption = !string.Equals(val1S, val2S, StringComparison.Ordinal) ? leftOption : rightOption; break;
                    default: selectedOption = leftOption; break;
                }

                val = ParseMath(null, selectedOption, null);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, string.Format("Exception while performing if statement. Statement: '{1}'", statement));
                val = 0;
            }
            return val;
        }
    }
}
