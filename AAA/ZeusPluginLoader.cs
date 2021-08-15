using System;
using System.Diagnostics;
using System.IO;
using YoYoStudio.Core.Utils;
using YoYoStudio.GUI.Gadgets;
using YoYoStudio.Plugins;

namespace AAA
{
    public class ZeusPluginLoader : IPlugin
    {
        public void LoadPlugins()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Custom Plugins");
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                    MessageDialog.ShowUnlocalisedWarning("Zeus Plugin Loader", "Welcome! Since this is your first time, a custom plugins directory has been created. Place all your plugins there and restart the IDE.");
                }
                catch (Exception exc)
                {
                    MessageDialog.ShowUnlocalisedWarning("Zeus Plugin Loader", "Failed to create a custom plugins directory. Reason: " + exc.Message);
                }
            }
            else
            {
                foreach (var f in Directory.EnumerateFiles(path, "*.dll", SearchOption.TopDirectoryOnly))
                {
                    Log.WriteLine(eLog.Default, "Zeus Plugin Loader is loading " + f);

                    try
                    {
                        if (PluginManager.LoadAssembly(f) is null) throw new Exception("Return value of LoadAssembly is null?!");
                    }
                    catch
                    {
                        MessageDialog.ShowUnlocalisedWarning("Zeus Plugin Loader", "Fatal error when loading plugin " + f);
                    }
                }
            }
        }

        public PluginConfig Initialise()
        {
            Log.WriteLine(eLog.Default, "Zeus Plugin Loader v2.0 - Open Source early startup...");

            PluginConfig config = new PluginConfig("Zeus Plugin Loader v2.0 - OSE", "Zeus Plugin Loader, now open source!", false);
            config.AddCommand("cmd_zeuspluginloader_deactivator", "ide_loaded", "A command that deactivates itself", "create", typeof(ZeusPluginLoaderCommand));

            LoadPlugins();

            return config;
        }
    }
}
