<!-- Readme.md v1.0.1.0
ScrapYard {SYD}
created: 01 Oct 19
updated: 2020 03 12 -->
<!-- # KerbGuise Experimental engineering (KGEx)
#### Brings you: -->
<!-- Download on SpaceDock or Github or Curseforge. Also available on CKAN. -->

# ScrapYard: The Common Part Inventory
![Mod Version][SHIELD:mod:latest] 
![KSP version][SHIELD:ksp] ![KSP-AVC][SHIELD:kspavc] ![License MIT][SHIELD:license] ![LOGO:mit]  
![SpaceDock][SHIELD:spacedock] ![CKAN][SHIELD:ckan] ![GitHub][SHIELD:github] ![Curseforge][SHIELD:curseforge]  
![Validate AVC .version files][SHIELD:avcvalid]  

Preamble by [@severedsolo][LINK:severedsolo]: 
> So you may have heard that @magico13 is giving up modding KSP. I've got the honour of taking over support for ScrapYard, because it makes sense as I have my own mod that depends on it (Oh Scrap!). I want to take this opportunity to thank magico13 for all his hard work and contributions to the community over the years, as I know that my own KSP experience would be much poorer without his mods. Anyway, enough from me.

The bit you are actually interested in

ScrapYard is a mod that provides a part inventory that can be shared between multiple mods. Parts are added to the inventory when you recover a vessel and are removed from the inventory when you build a new vessel. If you have ever played with Kerbal Construction Time, it's a significantly improved version of the part inventory that KCT had, that is also able to be used by other mods.

As of writing, ScrapYard does the following:

- Parts are added to the inventory automatically upon vessel recovery
- Parts are applied in the editor (not automatically like with KCT)
- Parts are then pulled from the inventory on build (mods can change when this happens)
- Parts are stored individually in the inventory along with any modules that “define” the part (think TweakScale and Procedural Parts)
- The number of times “like” parts are used is tracked and available for mods, both total uses and number of builds (KCT’s part tracker feature, expanded)
- Parts are trackable from the moment they are placed in the editor until they are removed from the game via a unique ID that transcends recovery and new builds
- The number of times an individual part is recovered is tracked, perfect for consumption by part failure mods
- (WIP) Funds can be overridden so that using parts from the inventory do not contribute to the cost of the vessel. You do still need to have the full amount of funds (for now).
- ContractConfigurator support for adding or removing parts from the inventory as part of contracts

#### Installation Directions:
- Use CKAN

### Changelog Summary
*See [ChangeLog][MOD:changelog] for full details of mod changes*

### Dependencies
- [x] Kerbal Space Program: [![][SHIELD:ksp]][KSP:website]

- [Kerbal Space Program](https://kerbalspaceprogram.com) v1.9.1, ***may*** work on earlier versions (YMMV)
- [x] Module Manager: [![][shield:support-mm]][thread:mm]
- [ModuleManager](https://forum.kerbalspaceprogram.com/index.php?/topic/50533-**)
- [Magicore](http://forum.kerbalspaceprogram.com/index.php?/topic/97033-*)

### Recomends
- [OhScrap!](https://forum.kerbalspaceprogram.com/index.php?/topic/160854-*)
- [KerbalChangeLog](https://forum.kerbalspaceprogram.com/index.php?/topic/179207-*)

### Suggests
- [Kerbal Construction Time]()
- [StageRecovery](https://forum.kerbalspaceprogram.com/index.php?/topic/179306-**)

### Supports
- [KRASH](http://forum.kerbalspaceprogram.com/index.php?/topic/133082-*)
- [TweakScale](https://forum.kerbalspaceprogram.com/index.php?/topic/179030-*)
- [RemoteTech]()
- [FAR]()

### Conflicts
- [RealChutes  (maybe)]()

  * [x] [![][shield:support-warp]][thread:warp]
  * [x] [![][shield:support-crp]][thread:crp]
  * [x] [![][shield:support-di]][thread:di]
  * [x] [![][shield:support-dr]][thread:dr]
  * [x] [![][shield:support-epl]][thread:epl]
  * [x] [![][shield:support-fs]][thread:fs]
  * [x] [![][shield:support-ics]][thread:ics]
  * [x] [![][shield:support-kspi]][thread:kspi]
  * [x] [![][shield:support-mc]][thread:mc]
  * [x] [![][shield:support-nr]][thread:nr]
  * [x] [![][shield:support-snacks]][thread:snacks]
  * [x] [![][shield:support-ls]][thread:ls]


[SpaceDock][MOD:spacedock]

[GitHub](https://github.com/zer0Kerbal/ScrapYard/releases/latest/)

![hero shot][IMG:hero:0]  
![hero shot][IMG:hero:1]  

Source: [GitHub][MOD:github:repo]

ScrapYard is licensed ![MIT][MOD:license] ![LOGO:mit]  

 

Special thanks to [@SiriusSam][LINK:siriussame] for the original idea of creating a separate part inventory way back in 2014 and for the name, and to [@enneract][LINK:enneract] for discussion and design help.

As a player, why do I want this?

If you are using Kerbal Construction Time, all balance is assumed you have this mod. It will substantially reduce build times for both vessels that use parts from the inventory and new vessels that use frequently used parts due to the part tracker. As of writing, no other mods are using this framework, but when they do this mod may be required. And this mod can be used by itself with the override funds option to play with a very different play style.

As a mod developer, why do I want this?


There are numerous reasons you might want to integrate with ScrapYard (with a hard dependency or a soft dependency, both options are offered), here are just a few that I can think of off the top of my head:

- ScrapYard provides a way to uniquely track a part during its entire life cycle, from the moment it is placed in the editor until the time it is removed from the game. That includes surviving through multiple recoveries and launches. I imagine part failure mods might get the most use out of this, but surprise me!
- By using a developed, common system you don’t need to worry about implementing your own part inventory and automatically gain support with other mods. Spend more time writing new features instead of rewriting something that exists.
- Fine control over the modules that are stored with a part. Once Module Manager support for module templates is added, you can create a new module and a module manager patch to automatically store your module and its data with a part through its entire lifecycle. Module templates use MagiCore’s MathParser to allow for logic processing within the config file (currently limited to just numbers, strings will likely be added soon). Until Module Manager is supported, you can just edit the ModuleTemplates.cfg file directly. ﻿
- Get information about how often parts are used on a total used and number of builds basis. This is referred to as either the Part Tracker or the "Like" Part Tracker since it just tracks parts that are like each other (same name).
- Many more that I can’t think of off the top of my head


Mods using ScrapYard:

[Kerbal Construction Time](https://forum.kerbalspaceprogram.com/index.php?/topic/62900-*) by [@linuxgurugamer][LINK:linuxgurugamer] / [@magico13][LINK:magico13]

[Oh Scrap!](https://forum.kerbalspaceprogram.com/index.php?/topic/160854-*) by [@severedsolo][LINK:severedsolo]
***

<a href="https://github.com/zer0Kerbal/ScrapYard/releases/latest" target="_blank"><img src="https://i.imgur.com/RE4Ppr9.png"/></a>
<a href="https://spacedock.info/mod/1746" target="_blank"><img src="https://i.imgur.com/m0a7tn2.png"/></a>
<a href="https://www.curseforge.com/kerbal/ksp-mods/scrapyard" target="_blank"><img src="https://i.postimg.cc/RZNyB5vP/Download-On-Curse.png"/></a>

*Be Kind: Lithobrake, not jakebrake! Keep your Module Manager up to date*

###### v2.0.1.0 original: 01 Oct 2019 zed'K | updated: 14 Mar 2020 zed'K

[MOD:license]:         https://github.com/zer0Kerbal/ScrapYard/blob/master/LICENSE
[MOD:contributing]:    https://github.com/zer0Kerbal/ScrapYard/blob/master/.github/CONTRIBUTING.md
[MOD:issues]:          https://github.com/zer0Kerbal/ScrapYard/issues
[MOD:wiki]:            https://github.com/zer0Kerbal/ScrapYard/
[MOD:known]:           https://github.com/zer0Kerbal/ScrapYard/wiki/Known-Issues
[MOD:forum]:           https://forum.kerbalspaceprogram.com/index.php?/topic/178641-*
[MOD:spacedock]:       https://spacedock.info/mod/1746
[MOD:github:repo]:     https://github.com/zer0Kerbal/ScrapYard/
[MOD:github:releases]: https://github.com/zer0Kerbal/ScrapYard/releases/latest
[MOD:curseforge]:      https://www.curseforge.com/kerbal/ksp-mods/scrapyard
[MOD:changelog]:       https://github.com/zer0Kerbal/ScrapYard/Changelog.cfg

[KSP:website]: http://kerbalspaceprogram.com/

[SHIELD:mod:latest]: https://img.shields.io/github/v/release/zer0Kerbal/ScrapYard?include_prereleases?style=plastic
[SHIELD:mod]: https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/zer0Kerbal/ScrapYard/master/json/mod.json
[SHIELD:ksp]: https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/zer0Kerbal/ScrapYard/master/json/ksp.json
[SHIELD:license]: https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/zer0Kerbal/ScrapYard/master/json/license.json
[LOGO:mit]: https://i.postimg.cc/bvjfsMP5/MIT-17x17.png
[SHIELD:kspavc]:     https://img.shields.io/badge/KSP-AVC--supported-brightgreen.svg?style=plastic
[SHIELD:spacedock]:  https://img.shields.io/badge/SpaceDock-listed-blue.svg?style=plastic
[SHIELD:ckan]:       https://img.shields.io/badge/CKAN-Indexed-blue.svg?style=plastic
[SHIELD:github]:     https://img.shields.io/github-Indexed-blue.svg?style=plastic
[SHIELD:curseforge]: https://img.shields.io/badge/CurseForge-listed-blue.svg?style=plastic
[SHIELD:avcvalid]:    https://github.com/zer0Kerbal/ScarpYard/workflows/Validate%20AVC%20.version%20files/badge.svg


[thread:mm]: http://forum.kerbalspaceprogram.com/index.php?/topic/50533-*
[thread:arp]: http://forum.kerbalspaceprogram.com/index.php?/topic/54876-*
[thread:warp]: http://forum.kerbalspaceprogram.com/index.php?/topic/90899-*
[thread:crp]: http://forum.kerbalspaceprogram.com/index.php?/topic/83007-*
[thread:di]: http://forum.kerbalspaceprogram.com/index.php?/topic/73920-*
[thread:dr]: http://forum.kerbalspaceprogram.com/index.php?/topic/50296-*
[thread:epl]: http://forum.kerbalspaceprogram.com/index.php?/topic/54284-*
[thread:fs]: http://forum.kerbalspaceprogram.com/index.php?/topic/22583-*
[thread:ics]: http://forum.kerbalspaceprogram.com/index.php?/topic/74182-*
[thread:kspi]: http://forum.kerbalspaceprogram.com/index.php?/topic/100190-*
[thread:mc]: http://forum.kerbalspaceprogram.com/index.php?/topic/40183-*
[thread:nr]: http://forum.kerbalspaceprogram.com/index.php?/topic/121597-*
[thread:snacks]: https://github.com/Angel-125/Snacks
[thread:ls]: http://forum.kerbalspaceprogram.com/index.php?/topic/105202-*
[thread:bm]: http://forum.kerbalspaceprogram.com/index.php?/topic/48629-*
[thread:df]: http://forum.kerbalspaceprogram.com/index.php?/topic/112328-*

[shield:support-mm]: http://img.shields.io/github/v/release/sarbian/ModuleManager?include_prereleases?style=plastic
[shield:support-arp]: http://img.shields.io/github/v/release/TriggerAu/AlternateResourcePanel?include_prereleases?style=plastic
[shield:support-warp]: http://img.shields.io/github/v/release/BobPalmer/WarpDrive/releases/latest?include_prereleases?style=plastic
[shield:support-crp]: http://img.shields.io/github/v/release/BobPalmer/CommunityResourcePack/releases/latest?include_prereleases?style=plastic
[shield:support-di]: http://img.shields.io/badge/Dang%20It-v0.6.2-blue.svg
[shield:support-dr]: http://img.shields.io/badge/Deadly%20Reentry-v7.4.7.1-red.svg
[shield:support-epl]: http://img.shields.io/badge/Extraplanetary%20Launchpads-v5.4.0-orange.svg
[shield:support-fs]: http://img.shields.io/badge/Firespitter-v7.4.1-red.svg
[shield:support-ics]: http://img.shields.io/badge/Ioncross%20Crew%20Support-v1.25.0-34c566.svg
[shield:support-kspi]: http://img.shields.io/badge/KSP%20Interstellar%20Expanded-v1.10.7-c5a79f.svg
[shield:support-mc]: http://img.shields.io/badge/Mission%20Controller%202-v1.4.3-50b2bc.svg
[shield:support-nr]: http://img.shields.io/badge/'Project%20Orion'%20Nuclear%20Pulse%20Engine-v0.3.0.0-3cdc28.svg
[shield:support-snacks]: http://img.shields.io/badge/Snacks-v1.4.0-a99b13.svg
[shield:support-ls]: http://img.shields.io/badge/USI%20Life%20Support-v0.5.0.0-green.svg
[shield:support-bm]: http://img.shields.io/badge/BioMass-v0.9.2.1-green.svg
[shield:support-df]: http://img.shields.io/badge/DeepFreeze%20Continued-v0.23.0.0-acdadf.svg

[LINK:magico13]:       https://forum.kerbalspaceprogram.com/index.php?/profile/73338-magico13/
[LINK:severedsolo]:    https://forum.kerbalspaceprogram.com/index.php?/profile/80345-severedsolo/
[LINK:zer0Kerbal]:     https://forum.kerbalspaceprogram.com/index.php?/profile/190933-zer0kerbal/
[LINK:linuxgurugamer]: https://forum.kerbalspaceprogram.com/index.php?/profile/129964-linuxgurugamer/
[LINK:siriussame]:  https://forum.kerbalspaceprogram.com/index.php?/profile/116426-siriussam/
[LINK:enneract]:    https://forum.kerbalspaceprogram.com/index.php?/profile/56759-enneract/

[IMG:hero:0]: https://i.imgur.com/DVDdgU1.png
[IMG:hero:1]: https://i.imgur.com/y0vd6WS.png)

<!--
this file: GPLv2
zer0Kerbal-->