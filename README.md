# Zeus Plugin Loader - OSE Edition
Please YoYo don't patch this.

UPD: 2.3.3 still unpatched, thanks YYG!

UPD 2: 2.3.3.574 still unpatched, man YoYo you're the best _!_

UPD 3: Zeus Plugin Loader is now ***O P E N - S O U R C E !*** go tell your cats!!!

## How do I build muh own?

The ZPL joke (all my projects are unfunny jokes to some extent) consists of two parts:
- `wintrust.dll` - WinTrust check disabler/pretender/tomfooler.
- `AAA.dll` - the loader itself (gets loaded first because of alphabetically first name)

Both are C#, Visual Studio projects, just build them!

(... preferrably in the `Release x64` configuration...)

Then copy `wintrust.dll` and `AAA.dll` into the IDE folder.

Huge thanks to `DllExport` and `Harmony.NET` projects for making my job WAY easier 💙!

## Instructions
- Download the lates ZPL archive from [Releases](https://github.com/ZeusPlugins/ZeusPluginLoader/releases).
- Unpack `wintrust.dll` and `AAA.dll` into the IDE folder.
- Run the IDE
- You should see a warning from ZPL that it's your first time, and that a directory for Custom Plugins has been created.
- Close the IDE
- Place all your custom plugins into the `[where IDE is installed]\Custom Plugins` folder.
- Hope that YoYo won't patch this >:(

## H-Hey! It doesn't work!

Message me on Discord nik#5351 or vk/nkrapivindev.

## Can I pirate GM with this?
**No**, all plugins are loaded after, and ONLY AFTER the license check, sorry!

It's not my code that does the initial plugin bootup, it's YoYo's stuff, and I'm not poking into that.
