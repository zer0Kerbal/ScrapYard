[LICENSE](https://github.com/zer0Kerbal/ScrapYard/blob/master/LICENSE)  
[CONTRIBUTING](https://github.com/zer0Kerbal/ScrapYard/blob/master/.github/CONTRIBUTING.md)

# Submitting changes

Please send a GitHub Pull Request to ScrapYard with a clear list of what you've done (read more about pull requests). When you send a pull request, we will love you forever if you include RSpec examples. We can always use more test coverage. Please follow our coding conventions (below) and make sure all of your commits are atomic (one feature per commit).

Always write a clear log message for your commits. One-line messages are fine for small changes, but bigger changes should look like this:

$ git commit -m "A brief summary of the commit
> 
> A paragraph describing what changed and its impact."

Coding conventions

Start reading our code and you'll get the hang of it. We optimize for readability:

    - We indent using tabs (or if must, 4 spaces)
    - We ALWAYS put spaces after list items and method parameters ([1, 2, 3], not [1,2,3]), around operators (x += 1, not x+=1), and around hash arrows.
    - This is open source software. Consider the people who will read your code, and make it look nice for them. It's sort of like driving a car: Perhaps you love doing donuts when you're alone, but with passengers the goal is to make the ride as smooth as possible.
    -So that we can consistently serve images from the CDN, always use image_path or image_tag when referring to images. Never prepend "/images/" when using image_path or image_tag.
    - Also for the CDN, always use cwd-relative paths rather than root-relative paths in image URLs in any CSS. So instead of url('/images/blah.gif'), use url('../images/blah.gif').

# All submissions become subject to this repository's [LICENSE](Under GitHub ToS, the pull request is licensed under the target repository license, unless different agreement is previously reached.
For all effects, that push request is licensed under the MIT.
). 
Under GitHub Terms of Service, all pull requests are licensed under the target repository license, unless different agreement is previously reached.

Read this page before reporting a bug. If you ignore these directions, your report may be ignored.

### Before you report

**Has it already been reported?**  
Check the [issue tracker](https://github.com/zer0Kerbal/NukeRefueled/issues) and the [Known issues](https://github.com/zer0Kerbal/NukeRefueled/wiki/Known-Issues) to see if the problem has already been reported. If so, see if you can contribute additional information, without adding a new issue. 
If you're not sure if your issue is related, comment on the existing report first.

**Is it intended behavior? / Are you doing it right?**  
Make sure you're encountering a bug and not just an intended aspect of the mod.

**Is it actually a Nuke Refueled problem?**  
See if the problem occurs if you uninstall Nuke Refueled, and also see if it occurs when Nuke Refueled is the *only* mod installed. 

**Are you up-to-date?**  
Only the latest version of ScrapYard and the latest version of KSP are supported. Make sure both are completely up-to-date before filing a report.

### Filing a report

Bug reports and feature requests should be filled on the [issue tracker](https://github.com/zer0Kerbal/NukeRefueled/issues) here on Github. Please read the following guidelines for filing reports; it's very difficult for me to help otherwise.

* **Be specific.** The title and description of your report should describe exactly what isn't working. Provide reproduction steps if you can, and explain in detail the symptoms of the issue and what causes it.
* **Provide your output log.** This file can be found at `KSP/KSP_Data/output_log.txt`. This contains debug information about your last KSP session. Without this, I cannot diagnose most issues. If your report has precise reproduction steps and the cause is obvious, the log is optional. When in doubt, please include it.
* **List other mods.** While mod compatibility issues are rare, you should list all the other mods you have installed.
* **System specifications.** Include your hardware specifications (CPU, GPU, RAM) and your operating system. Also include whether you're using Steam or the manual download of KSP and the folder where KSP is installed.
* **One issue per report.** If you have multiple issues, submit multiple reports. Don't lump everything together; it becomes difficult to track disparate issues that way.

If you don't have enough information to file a bug report, you may ask questions on the forum thread. **Do not send me private messages about bugs unless you believe the bug is an exploitable security issue.**

