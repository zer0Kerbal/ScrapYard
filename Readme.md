 # ScrapYard: The Common Part Inventory
![Mod Version](https://img.shields.io/github/v/release/zer0Kerbal/ScrapYard?include_prereleases?style=plastic)
![KSP version](https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/zer0Kerbal/ScrapYard/master/json/ksp.json?style=plastic) ![KSP-AVC](https://img.shields.io/badge/KSP-AVC--supported-brightgreen.svg?style=plastic) ![License MIT](https://img.shields.io/badge/license-MIT-red?style=plastic)  
![Spacedock](https://img.shields.io/badge/SpaceDock-listed-blue.svg?style=plastic) ![CKAN](https://img.shields.io/badge/CKAN-Indexed-blue.svg?style=plastic) ![Github](https://img.shields.io/badge/Github-Indexed-blue.svg?style=plastic) ![Curseforge](https://img.shields.io/badge/CurseForge-listed-blue.svg?style=plastic)

Preamble by severedsolo: So you may have heard that @magico13 is giving up modding KSP. I've got the honour of taking over support for ScrapYard, because it makes sense as I have my own mod that depends on it (Oh Scrap!). I want to take this opportunity to thank magico13 for all his hard work and contributions to the community over the years, as I know that my own KSP experience would be much poorer without his mods. Anyway, enough from me.

The bit you are actually interested in

ScrapYard is a mod that provides a part inventory that can be shared between multiple mods. Parts are added to the inventory when you recover a vessel and are removed from the inventory when you build a new vessel. If you have ever played with Kerbal Construction Time, it's a significantly improved version of the part inventory that KCT had, that is also able to be used by other mods.

As of writing, ScrapYard does the following:

    Parts are added to the inventory automatically upon vessel recovery
    Parts are applied in the editor (not automatically like with KCT)
    Parts are then pulled from the inventory on build (mods can change when this happens)
    Parts are stored individually in the inventory along with any modules that “define” the part (think TweakScale and Procedural Parts)
    The number of times “like” parts are used is tracked and available for mods, both total uses and number of builds (KCT’s part tracker feature, expanded)
    Parts are trackable from the moment they are placed in the editor until they are removed from the game via a unique ID that transcends recovery and new builds
    The number of times an individual part is recovered is tracked, perfect for consumption by part failure mods
    (WIP) Funds can be overridden so that using parts from the inventory do not contribute to the cost of the vessel. You do still need to have the full amount of funds (for now).
    ContractConfigurator support for adding or removing parts from the inventory as part of contracts

 

Download: 2.1.0.0 (2020 03 03)

Magicore and Module Manager are required dependencies.

These are no longer bundled and must be obtained separately.

[SpaceDock](https://spacedock.info/mod/1746/ScrapYard)

[GitHub](https://github.com/zer0Kerbal/ScrapYard/releases/latest/)

 
![](https://i.imgur.com/DVDdgU1.png)

 
![](https://i.imgur.com/y0vd6WS.png)

 

 

Source: [GitHub](https://github.com/zer0Kerbal/ScrapYard/)

ScrapYard is licensed MIT

Support me on Patreon!

![](https://www.paypalobjects.com/en_GB/i/btn/btn_donate_LG.gif)

 

Special thanks to @SiriusSam for the original idea of creating a separate part inventory way back in 2014 and for the name, and to @enneract for discussion and design help.

As a player, why do I want this?

If you are using Kerbal Construction Time, all balance is assumed you have this mod. It will substantially reduce build times for both vessels that use parts from the inventory and new vessels that use frequently used parts due to the part tracker. As of writing, no other mods are using this framework, but when they do this mod may be required. And this mod can be used by itself with the override funds option to play with a very different play style.

As a mod developer, why do I want this?


There are numerous reasons you might want to integrate with ScrapYard (with a hard dependency or a soft dependency, both options are offered), here are just a few that I can think of off the top of my head:

    ScrapYard provides a way to uniquely track a part during its entire life cycle, from the moment it is placed in the editor until the time it is removed from the game. That includes surviving through multiple recoveries and launches. I imagine part failure mods might get the most use out of this, but surprise me!
    By using a developed, common system you don’t need to worry about implementing your own part inventory and automatically gain support with other mods. Spend more time writing new features instead of rewriting something that exists.
    Fine control over the modules that are stored with a part. Once Module Manager support for module templates is added, you can create a new module and a module manager patch to automatically store your module and its data with a part through its entire lifecycle. Module templates use MagiCore’s MathParser to allow for logic processing within the config file (currently limited to just numbers, strings will likely be added soon). Until Module Manager is supported, you can just edit the ModuleTemplates.cfg file directly. ﻿
    Get information about how often parts are used on a total used and number of builds basis. This is referred to as either the Part Tracker or the "Like" Part Tracker since it just tracks parts that are like each other (same name).
    Many more that I can’t think of off the top of my head


Mods using ScrapYard:

[Kerbal Construction Time](https://forum.kerbalspaceprogram.com/index.php?/topic/62900-*) by @linuxgurugamer / @magico13

[Oh Scrap!](https://forum.kerbalspaceprogram.com/index.php?/topic/160854-*) by @severedsolo 