using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPhotoConverter.Helpers
{
    public class RegistryHelper
    {
        string regName = "CustomPhotoResizer";
        public void InitializeRegistry()
        {
            WriteToRegistry("Initialized", "True");
        }
        public void WriteToRegistry(string name, string value)
        {
            RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            var reg = localMachine.OpenSubKey($"Software\\{regName}", true);
            if (reg == null)
            {
                reg = localMachine.CreateSubKey($"Software\\{regName}");
            }
            reg.SetValue(name, value);
        }
        public bool ValueExists(string name)
        {
            RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            var reg = localMachine.OpenSubKey($"Software\\{regName}", true);
            if (reg == null)
            {
                return false;
            }
            return reg.GetValue(name) != null;
        }
        public string GetValue(string name)
        {
            RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            var reg = localMachine.OpenSubKey($"Software\\{regName}", true);
            var value = reg.GetValue(name).ToString();
            return value;
        }
    }
}
