<!-- Readme.md v1.0.1.0
ScrapYard (SYD)
created: 01 Oct 19
updated: 2020 03 16 -->
<!-- # KerbGuise Experimental engineering (KGEx)
#### Brings you: -->
<!-- Download on SpaceDock or Github or Curseforge. Also available on CKAN. -->

# ScrapYard (SYD)
## The Common Part Inventory
![Mod Version][shield:mod:latest] 
![KSP version][shield:ksp] ![KSP-AVC][shield:kspavc] ![License MIT][shield:license] ![][LOGO:mit]   
![SpaceDock][shield:spacedock] ![CKAN][shield:ckan] ![GitHub][shield:github] ![Curseforge][shield:curseforge]  
![Validate AVC .version files][shield:avcvalid]  

### Preamble by [@severedsolo][LINK:severedsolo]: 
> So you may have heard that @magico13 is giving up modding KSP. I've got the honour of taking over support for ScrapYard, because it makes sense as I have my own mod that depends on it (Oh Scrap!). I want to take this opportunity to thank magico13 for all his hard work and contributions to the community over the years, as I know that my own KSP experience would be much poorer without his mods. Anyway, enough from me.

### The bit you are actually interested in

ScrapYard is a mod that provides a part inventory that can be shared between multiple mods. Parts are added to the inventory when you recover a vessel and are removed from the inventory when you build a new vessel. If you have ever played with Kerbal Construction Time, it's a significantly improved version of the part inventory that KCT had, that is also able to be used by other mods.

### As of writing, ScrapYard does the following:
- Parts are added to the inventory automatically upon vessel recovery
- Parts are applied in the editor (not automatically like with KCT)
- Parts are then pulled from the inventory on build (mods can change when this happens)
- Parts are stored individually in the inventory along with any modules that “define” the part (think TweakScale and Procedural Parts)
- The number of times “like” parts are used is tracked and available for mods, both total uses and number of builds (KCT’s part tracker feature, expanded)
- Parts are trackable from the moment they are placed in the editor until they are removed from the game via a unique ID that transcends recovery and new builds
- The number of times an individual part is recovered is tracked, perfect for consumption by part failure mods
- (WIP) Funds can be overridden so that using parts from the inventory do not contribute to the cost of the vessel. You do still need to have the full amount of funds (for now).
- ContractConfigurator support for adding or removing parts from the inventory as part of contracts
***
### Installation Directions:
- Use CKAN
### Changelog Summary
*See [ChangeLog][MOD:changelog] for full details of mod changes*
***
### Dependencies
- [x] [Kerbal Space Program][KSP:website] [![][shield:ksp]][KSP:website] ***may*** work on other versions (YMMV)
- [x] [Module Manager][thread:mm]  
### Recomends  
- [x] [OhScrap!][thread:ohscrap]  
- [x] [Kerbal Change Log][thread:kcl]  
### Suggests
- [x] [StageRecovery][thread:sr]  
- [x] [Kerbal Construction Time][thread:kct]  
### Supports
- [x] [KRASH][thread:krash]  
- [x] [TweakScale][thread:tweakscale]  
- [x] [RemoteTech][thread:remotetech]  
- [x] [FAR][thread:far]  
- [x] [ContractConfigurator][thread:contractconfigurator]  
### Conflicts
- none known
***
![hero shot][IMG:hero:0]  
![hero shot][IMG:hero:1]  
***
Special thanks to [@SiriusSam][LINK:siriussame] for the original idea of creating a separate part inventory way back in 2014 and for the name, and to [@enneract][LINK:enneract] for discussion and design help.

### As a player, why do I want this?
If you are using Kerbal Construction Time, all balance is assumed you have this mod. It will substantially reduce build times for both vessels that use parts from the inventory and new vessels that use frequently used parts due to the part tracker. As of writing, no other mods are using this framework, but when they do this mod may be required. And this mod can be used by itself with the override funds option to play with a very different play style.

### As a mod developer, why do I want this?
There are numerous reasons you might want to integrate with ScrapYard (with a hard dependency or a soft dependency, both options are offered), here are just a few that I can think of off the top of my head:

- ScrapYard provides a way to uniquely track a part during its entire life cycle, from the moment it is placed in the editor until the time it is removed from the game. That includes surviving through multiple recoveries and launches. I imagine part failure mods might get the most use out of this, but surprise me!
- By using a developed, common system you don’t need to worry about implementing your own part inventory and automatically gain support with other mods. Spend more time writing new features instead of rewriting something that exists.
- Fine control over the modules that are stored with a part. Once Module Manager support for module templates is added, you can create a new module and a module manager patch to automatically store your module and its data with a part through its entire lifecycle. Module templates use MagiCore’s MathParser to allow for logic processing within the config file (currently limited to just numbers, strings will likely be added soon). Until Module Manager is supported, you can just edit the ModuleTemplates.cfg file directly. ﻿
- Get information about how often parts are used on a total used and number of builds basis. This is referred to as either the Part Tracker or the "Like" Part Tracker since it just tracks parts that are like each other (same name).
- Many more that I can’t think of off the top of my head

Mods using ScrapYard:
- [Kerbal Construction Time][thread:kct] by [@linuxgurugamer][LINK:linuxgurugamer] / [@magico13][LINK:magico13]  
- [Oh Scrap!][thread:ohscrap] by [@severedsolo][LINK:severedsolo] / [@zer0Kerbal][LINK:zer0Kerbal]
***  
*red box below is a link to forum post on how to get support*  
[![How to get support][image:get-support]][thread:getsupport]

### License
#### aka Legal Mumbo Jumbo
Source: [GitHub][MOD:github:repo]  
License: ![License MIT][shield:license] ![][LOGO:mit]    
> *** All bundled mods are distributed under their own licenses***<br>
> *** All art assets (textures, models, animations) are distributed under their own licenses*** 
### Original
[Thread][MOD:original:thread]  
[Download][MOD:original:download]  
Source: [GitHub][MOD:original:source]  
License: ![License MIT][shield:license] ![][LOGO:mit]  
<!-- graphical links to downloads -->
[![][image:rel-github]][MOD:rel-github] [![][image:rel-spacedock]][MOD:rel-spacedock] [![][image:rel-curseforge]][MOD:rel-curseforge]  

*Be Kind: Lithobrake, not jakebrake! Keep your Module Manager up to date*

###### v2.0.1.0 original: 01 Oct 2019 zed'K | updated: 16 Mar 2020 zed'K

[MOD:license]:      https://github.com/zer0Kerbal/ScrapYard/blob/master/LICENSE
[MOD:contributing]: https://github.com/zer0Kerbal/ScrapYard/blob/master/.github/CONTRIBUTING.md
[MOD:issues]:       https://github.com/zer0Kerbal/ScrapYard/issues
[MOD:wiki]:         https://github.com/zer0Kerbal/ScrapYard/
[MOD:known]:        https://github.com/zer0Kerbal/ScrapYard/wiki/Known-Issues
[MOD:forum]:        https://forum.kerbalspaceprogram.com/index.php?/topic/192456-*
[MOD:github:repo]:  https://github.com/zer0Kerbal/ScrapYard/
[MOD:changelog]:    https://github.com/zer0Kerbal/ScrapYard/Changelog.cfg
<!--- original mod stuff -->
[MOD:original:source]: https://github.com/severedsolo/ScrapYard
[MOD:original:thread]: https://forum.kerbalspaceprogram.com/index.php?/topic/178641-*
[MOD:original:download]: https://github.com/severedsolo/ScrapYard/releases/latest

[KSP:website]: http://kerbalspaceprogram.com/
[LOGO:mit]:    https://i.postimg.cc/bvjfsMP5/MIT-17x17.png
[LOGO:gplv3]: https://i.postimg.cc/90kCDs7K/gplv3-48x17.png

[MOD:rel-github]: https://github.com/zer0Kerbal/ScrapYard/releases/latest "GitHub"
[MOD:rel-spacedock]: http://spacedock.info/mod/1746
[MOD:rel-curseforge]: https://www.curseforge.com/kerbal/ksp-mods/scrapyard
[MOD:rel-ckan]: http://forum.kerbalspaceprogram.com/index.php?/topic/90246-*

[image:rel-github]:       https://i.imgur.com/RE4Ppr9.png
[image:rel-spacedock]: https://i.imgur.com/m0a7tn2.png
[image:rel-curseforge]: https://i.postimg.cc/RZNyB5vP/Download-On-Curse.png
[image:get-support]:    https://i.postimg.cc/vHP6zmrw/image.png

[image:rel-ckan]:    https://i.postimg.cc/x8XSVg4R/sj507JC.png
[image:changelog]: https://i.postimg.cc/qM9p4V0C/changelog.png
[image:source]:      https://i.postimg.cc/tJ8GqW0H/source.png

[image:rel-github-sm]:      https://i.postimg.cc/1XXy5yfD/github.png
[image:rel-spacedock-sm]: https://i.postimg.cc/DZ22Hrhj/spacedock.png
[image:rel-curseforge-sm]: https://i.postimg.cc/ZRVTSWKT/UVVt0OP.png
  
[shield:mod:latest]: https://img.shields.io/github/v/release/zer0Kerbal/ScrapYard?include_prereleases?style=plastic
[shield:mod]: https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/zer0Kerbal/ScrapYard/master/json/mod.json
[shield:ksp]: https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/zer0Kerbal/ScrapYard/master/json/ksp.json
[shield:license]: https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/zer0Kerbal/ScrapYard/master/json/license.json
[shield:kspavc]:     https://img.shields.io/badge/KSP-AVC--supported-brightgreen.svg?style=plastic
[shield:spacedock]:  https://img.shields.io/badge/SpaceDock-listed-blue.svg?style=plastic
[shield:ckan]:       https://img.shields.io/badge/CKAN-Indexed-blue.svg?style=plastic
[shield:github]:     https://img.shields.io/badge/Github-Indexed-blue.svg?style=plastic&logo=github
[shield:curseforge]: https://img.shields.io/badge/CurseForge-listed-blue.svg?style=plastic
[shield:avcvalid]:    https://github.com/zer0Kerbal/ScrapYard/workflows/Validate%20AVC%20.version%20files/badge.svg

[thread:mm]: http://forum.kerbalspaceprogram.com/index.php?/topic/50533-*
[thread:mc]: https://forum.kerbalspaceprogram.com/index.php?/topic/178484-*
[thread:ohscrap]:https://forum.kerbalspaceprogram.com/index.php?/topic/192360-*
[thread:kcl]: https://forum.kerbalspaceprogram.com/index.php?/topic/179207-*
[thread:sr]: https://forum.kerbalspaceprogram.com/index.php?/topic/179306-*
[thread:kct]: https://forum.kerbalspaceprogram.com/index.php?/topic/182877-*

[thread:krash]:                http://forum.kerbalspaceprogram.com/index.php?/topic/133082-*
[thread:tweakscale]:           https://forum.kerbalspaceprogram.com/index.php?/topic/179030-*
[thread:remotetech]:           http://remotetechnologiesgroup.github.io/RemoteTech/
[thread:far]:                  https://forum.kerbalspaceprogram.com/index.php?/topic/179445-*
[thread:contractconfigurator]: https://forum.kerbalspaceprogram.com/index.php?/topic/91625--

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
[thread:getsupport]: https://forum.kerbalspaceprogram.com/index.php?/topic/83212-*

[LINK:magico13]:       https://forum.kerbalspaceprogram.com/index.php?/profile/73338-magico13/
[LINK:severedsolo]:    https://forum.kerbalspaceprogram.com/index.php?/profile/80345-severedsolo/
[LINK:linuxgurugamer]: https://forum.kerbalspaceprogram.com/index.php?/profile/129964-linuxgurugamer/
[LINK:siriussame]:     https://forum.kerbalspaceprogram.com/index.php?/profile/116426-siriussam/
[LINK:enneract]:       https://forum.kerbalspaceprogram.com/index.php?/profile/56759-enneract/
[LINK:zer0Kerbal]:     https://forum.kerbalspaceprogram.com/index.php?/profile/190933-zer0kerbal/

[IMG:hero:0]: https://i.imgur.com/DVDdgU1.png
[IMG:hero:1]: https://i.imgur.com/y0vd6WS.png

<!--
this file: GPLv2
zer0Kerbal-->
