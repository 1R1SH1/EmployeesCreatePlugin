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
        private const string jsonFilePath = "C:\\Users\\Rishat\\Downloads\\PhonePluginsApplication-master\\EmployeesLoaderPlugin\\Properties\\Resources.resx";
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            var employeesList = args.Cast<EmployeesDTO>().ToList();

            var list = new EmployeesDTO() { Name = "Rishat" };

            employeesList.Add(list);
            Create(employeesList);

            return employeesList.Cast<DataTransferObject>();
        }

        private void Create(IEnumerable<DataTransferObject> args)
        {
            WriteJson(jsonFilePath, JsonConvert.SerializeObject(args, Formatting.Indented));
        }
        private void WriteJson(string filePath, string log)
        {
            string json = JsonConvert.SerializeObject(log);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.Write(json);
            }
        }
    }
}
