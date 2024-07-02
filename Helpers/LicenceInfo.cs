using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CustomPhotoConverter.Helpers
{
    public class LicenceInfo
    {

        public string GenerateHardwareID()
        {
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            var mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }

            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoard = "";
            foreach (ManagementObject mo in moc)
            {
                motherBoard = (string)mo["SerialNumber"];
            }

            string myUniqueID = id + motherBoard;
            return myUniqueID.Replace("/", "");
        }
        public bool IsRegistered()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("CustomPhotoResizer");
            key = key.OpenSubKey("CustomPhotoResizer", true);
            return key != null;
            /*
                        key.CreateSubKey("AppVersion");
                        key = key.OpenSubKey("AppVersion", true);

                        key.SetValue("yourkey", "yourvalue");*/

        }
/*        public bool Register(string value)
        {

        }*/
        public string GenerateRegistrationKey()
        {
            var hardwareId = GenerateHardwareID();
            //var values = hardwareId.ToList();
            var license = GenerateUniqueValue(hardwareId);

            return RemoveSpecialCharacters(license);
        }
        public static string GenerateUniqueValue(string value)
        {
            // Create a SHA256 hash for the input string
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));

                // Convert hash bytes to a shorter, base-36 string (for readability)
                string hashString = Convert.ToBase64String(hashBytes).ToLowerInvariant();

                // Combine hash and GUID, ensuring uniqueness
                return $"{hashString}";
            }

        }

        public static string RemoveSpecialCharacters(string str)
        {
            var invalidCharacters = new List<string>()
            {
                "!", "@","#","$","%","^","&","*","(",")","-","=","+","{","}","\\","/",".",",","`","|"
            };
            var values = str.ToList();
            var invlaid = new List<string>();

            foreach (var character in values)
            {
                if (invalidCharacters.Contains(character.ToString()))
                {
                    invlaid.Add(character.ToString());
                }
            }

            var key = string.Join("",values.Select(x => x.ToString()).Except(invlaid));
            return GetResultsWithHyphen(key);
        }
        public static string GetResultsWithHyphen(string str)
        {
            //return Regex.Replace(str, "(.{4})", "$1-");
            //if you don't want trailing -
            return Regex.Replace(str, "(.{4})(?!$)", "$1-");
        }
    }
}
