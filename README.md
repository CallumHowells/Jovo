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
   "RequiresNetwork": "192.168.0.1"
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


The module's `settings.json` file is modified using Jovo then read by the Module. See the table below for info on settings configuration.

```json
{  
   "Server_IP":{  
      "Name":"Server_IP",
      "Text":"Server IP Address",
      "Domain":"string",
      "Value":"192.168.16.5"
   }
}
```
JSON Item | Use
------------- | -------------
First Value | Should be the same as the Name.
Name | Used by Jovo to handle the setting.
Text | Display Name of the setting shown to the user.
Domain | Data type to be stored. `string, password, integer, path, boolean`
Value | Value of the setting.

## Built With

* [Newtonsoft.Json](https://www.newtonsoft.com/json) - Popular high-performance JSON framework for .NET

## Versioning

We use [SemVer](http://semver.org/) for versioning.

## Authors

* **Callum Howells** - *Initial work & Ongoing development* - [CallumHowells](https://github.com/CallumHowells)
* **Connor Thursfield** - *Initial work & Ongoing development* - [conamatic](https://github.com/conamatic)

See also the list of [contributors](https://github.com/CallumHowells/Jovo/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
