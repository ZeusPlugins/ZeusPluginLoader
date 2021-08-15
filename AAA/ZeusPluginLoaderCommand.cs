using System;
using YoYoStudio.Core.Utils;
using YoYoStudio.Plugins;

namespace AAA
{
    public class ZeusPluginLoaderCommand : IModule, IDisposable
    {
        private bool disposedValue;
        private ModulePackage IdeInterface;

        public ModulePackage Package => IdeInterface;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                IdeInterface = null;
                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        ~ZeusPluginLoaderCommand()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(false);
        }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Initialise(ModulePackage _ide)
        {
            IdeInterface = _ide;
            PluginManager.DeactivatePlugin(typeof(ZeusPluginLoaderCommand), this);
            Log.WriteLine(eLog.Default, "Zeus Plugin Loader is deactivating itself...");
        }
    }
}
