using System;
using System.Runtime.InteropServices;
using System.Linq;
using HarmonyLib;
using System.Diagnostics;

namespace wintrust
{
    public static class WinTrust
    {
        public static bool g_Initialized = false;

        public static bool Prefix(ref bool __result, ref string __0, ref string __1)
        {
            __result = true; // always return true
            return false; // do not execute original method
        }

        public static void PatchIDEInMemory()
        {
            /* For all assemblies, if name starts with "IDE" then
             * For all types, if is class then
             * For all applied attributes, if name starts with DllImport then
             * For all applied attributes, for all arguments, if is "wintrust.dll"
             * For all declared methods, if return type is bool then
             * For all arguments, if all are of type string then
             * we're done =^-^=
             * 
             * PS: cannot hardcode names because they change on every update
             * thanks to SmartAssembly aka ShitAssembly 7
             */

            var wintrustmethod = 
                AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(x => x.FullName.StartsWith("IDE"))
                .FirstOrDefault()
                .DefinedTypes
                .Where(x => x.IsClass)
                .Where(
                    x => x.DeclaredMethods.Any(
                        y => y.CustomAttributes.Any(
                            z => z.AttributeType.Name.StartsWith("DllImportAttribute") && z.ConstructorArguments.Any(w => w.Value.ToString() == "wintrust.dll")
                        )
                    )
                )
                .FirstOrDefault()
                .DeclaredMethods
                .Where(x => x.IsStatic && x.ReturnType.FullName == "System.Boolean")
                .Where(x => x.GetParameters().Length == 2 && x.GetParameters().All(y => y.ParameterType.FullName == "System.String"))
                .FirstOrDefault();

            // get method from our own static class.
            var myprefix = typeof(WinTrust).GetMethod("Prefix");

            // the fun stuff
            var harmony = new Harmony("com.nkrapivindev.zeuspluginloader");
            harmony.Patch(wintrustmethod, new HarmonyMethod(myprefix));
        }

        // LONG WinVerifyTrust(HWND hWnd, GUID *pgActionID, LPVOID pWVTData);
        // LONG in Win32 is four bytes, so an int is fine.
        // an HWND is clearly a handle, so IntPtr.
        // a pointer to GUID can also be an IntPtr.
        // and well... LPVOID... also IntPtr.
        [DllExport(CallingConvention = CallingConvention.Winapi)]
        public static int WinVerifyTrust(IntPtr hWnd, IntPtr pgActionID, IntPtr pWVTData)
        {
            // as per MSDN:
            /* If the trust provider verifies that the subject is trusted for the specified action, the return value is zero. */
            const int TRUST_SUCCESS = 0;

            // so we don't patch it twice by accident.
            if (!g_Initialized)
            {
                PatchIDEInMemory();
                g_Initialized = true;
            }

            return TRUST_SUCCESS;
        }
    }
}
