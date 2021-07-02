# Zeus Plugin Loader
Please YoYo don't patch this.

## Why is it not open-source?
Don't want this to be patched ASAP, just in case.

But the whole process is really simple to figure out.

I don't mind if you reverse-engineer the binaries LOL.

## Instructions
- Download the lates ZPL archive from [Releases](https://github.com/ZeusPlugins/ZeusPluginLoader/releases).
- Unpack `wintrust.dll` and `Payload.zpl` into the IDE folder.
- Run the IDE
- You should see a warning from ZPL that it's your first time, and that a directory for Custom Plugins has been created.
- Close the IDE
- Place all your custom plugins into the `[where IDE is installed]\Custom Plugins` folder.
- Hope that YoYo won't patch this >:(

## H-Hey! It doesn't work!

Uh... try using a compatibility variant from [here](https://github.com/ZeusPlugins/ZeusPluginLoader/releases/tag/v1.1-4nico).

Delete `wintrust.dll` and `Payload.zpl` and unpack two files from the ZPL4Nico archive.

*That* should work.

## Can I pirate GM with this?
**No**, all plugins are loaded after, and ONLY AFTER the license check, sorry!

It's not my code that does the initial plugin bootup, it's YoYo's stuff, and I'm not poking into that.
