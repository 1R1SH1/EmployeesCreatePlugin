using Newtonsoft.Json;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeesCreatePlugin
{
    public class CreatePlugin
    {
        private const string jsonFilePath = "Resources.resx";
        public List<EmployeesDTO> _employees { get; set; }
        public string SaveInfoLog(List<EmployeesDTO> log)
        {
            return WriteJson(jsonFilePath, log);
        }
        private string WriteJson(string filePath, List<EmployeesDTO> log)
        {
            string json = JsonConvert.SerializeObject(log);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.Write(json);
            }
            return json;
        }
    }
}
