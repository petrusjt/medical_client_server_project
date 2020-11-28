using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using medical_common.Models;
using System.IO;
using System.Text;

namespace medical_server.Repositories
{
    public static class PatientRepository
    {
        static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string filePath = appDataPath + "\\" + "PatientData\\data.json";

        public static void WritePatients(IList<Patient> patients)
        {
            if(!Directory.Exists(appDataPath + "\\" + "PatientData"))
            {
                Directory.CreateDirectory(appDataPath + "\\" + "PatientData");
            }
            string jsonString = JsonSerializer.Serialize(patients);
            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }

        public static IList<Patient> LoadPatients()
        {
            if (Directory.Exists(appDataPath + "\\" + "PatientData"))
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath, Encoding.UTF8);
                    if(!string.IsNullOrWhiteSpace(json))
                    {
                        List<Patient> patients = JsonSerializer.Deserialize<List<Patient>>(json);
                        return patients;
                    }
                }
            }
            return new List<Patient>();
        }
    }
}
