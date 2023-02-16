using Newtonsoft.Json;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeesCreatePlugin
{
    [Author(Name = "Ivan Petrov")]
    public class Plugin : IPluggable
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private const string jsonFilePath = "Resources.resx";
        public List<EmployeesDTO> _employees { get; set; }
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            logger.Info("Loading employees");

            var employeesList = SaveInfoLog(_employees);

            logger.Info($"Loaded {employeesList.Count()} employees");
            return employeesList.Cast<DataTransferObject>();
        }        
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
