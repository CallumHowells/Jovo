# Jovo.

Jovo is a multi-functional tool for consolidating modules until one centralised menu for easy access via the Windows system tray.

## Installation

TODO

## Addons / Modules

The module's `manifest.json` file is used to configure the module with the json file below. See the table below for info on each JSON item to correctly configure the Module.

```json
{
   "Name":"testModule",
   "Icon":"TestModule.ico",
   "Text":"Test Module",
   "Tag":"testmodule",
   "Category":0,
   "Version":"1.0.0.0",
   "PublishDate":"01/01/2018 12:00:00",
   "Info":"Test Module.",
   "HasSettings": "false",
   "CreateMenuItem": "true",
   "IsActive": "true",
   "RequiresNetwork": "192.168.0.1",
   "KeyboardShortcut": "Control+Shift+NumPad1"
}
```
JSON Item | Use
------------ | -------------
Name | Used by Jovo to recall the Module.
Icon | Icon shown in the context menu.
Text | Display Name of the Module shown to the user.
Tag | Internal use only.
Category | Seperates items into different groups on the context menu.
Version | Version number of the Module.
PublishDate | Date at which the Module was published.
Info | General information about the Module.
HasSettings | Does the Module have a settings file. Default FALSE.
CreateMenuItem | Should Jovo generate a menu item for this Module? Default TRUE.
IsActive | Toggled if used chooses not to use this Module. Default TRUE.
RequiresNetwork | Value should be IP Address, PC Name or URL, Module cannot be opened if connection is not live. Default ''. IP Address format -> x.x.x.x, PC Name format -> \\\\PCName, URL format -> http://google.com
KeyboardShortcut | Keyboard shortcut keys seperated by plus sign (+). Supports upto 4 keys.

The module's `settings.json` file is modified using Jovo then read by the Module. See the table below for info on settings configuration.

```json
[  
   {  
      "Name":"Server_IP",
      "Text":"Server IP Address",
      "Domain":"string",
      "Value":"192.168.16.5"
   }
]
```
JSON Item | Use
------------- | -------------
Name | Used by Jovo to handle the setting.
Text | Display Name of the setting shown to the user.
Domain | Data type to be stored. `string, password, integer, path, boolean`
Value | Value of the setting.

The module's `changelog.json` file is read by Jovo to produce a readable changelog to display to the user. See the table below for info on changelog configuration.

```json
[
   {
      "Version":"1.0.0.0",
      "VersionDate":"03/07/2018 15:12:00",
      "Title":"Initial Release",
      "Description":"Initial Release",
      "Author":"Callum Howells",
      "Tags":"initial release,contains bugs",
      "Changes":[
         {
            "Title":"First non-dev release of CallModule, without 4Sight integration",
            "Type":"misc"
         }
      ]
   },
   {
      "Version":"1.0.1.0",
      "VersionDate":"09/07/2018 11:32:00",
      "Title":"4Sight Integration & More...",
      "Description":"Some more info",
      "Author":"Callum Howells",
      "Tags":"bug fix,stable",
      "Changes":[
         {
            "Title":"Added 4Sight Integration",
            "Type":"added"
         },
         {
            "Title":"Changed to new SettingsHandler for better configuration accross Jovo and Module.",
            "Type":"changed"
         }
      ]
   }
]
```
JSON Item | Use
------------- | -------------
Version | Version code for the changelog.
VersionDate | Date of the version.
Title | Changelog title.
Description | Description of the bulk changes and general overview.
Author | Who wrote the changelog and/or the update to the Module.
Tags | Tags to highlight certain updates. `initial release, bug fix, stable, contains bugs`
Changes > Title | Explanation of the change and possible inpacts of it.
Changes > Type | Type of change, split in user view to display better. `added, changed, deprecated, removed, fixed, security, misc`

## Built With

* [Newtonsoft.Json](https://www.newtonsoft.com/json) - Popular high-performance JSON framework for .NET

## Versioning / Changelog

* We use [SemVer](http://semver.org/) for versioning.
* Module Changelogs use a JSON variant of [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## Authors

* **Callum Howells** - *Initial work & Ongoing development* - [CallumHowells](https://github.com/CallumHowells)
* **Connor Thursfield** - *Initial work & Ongoing development* - [conamatic](https://github.com/conamatic)

See also the list of [contributors](https://github.com/CallumHowells/Jovo/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
