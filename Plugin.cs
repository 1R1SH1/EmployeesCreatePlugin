using Newtonsoft.Json;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesCreatePlugin
{
    public class Plugin : IPluggable
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private List<EmployeesDTO> _employees { get; set; }
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            logger.Info("Creating employees");

            var employee = new EmployeesDTO();

            _employees.Add(employee);

            var employees = JsonConvert.SerializeObject(_employees);

            logger.Info($"Created {employees.Count()} employees");
            return employees.Cast<DataTransferObject>();
        }
    }
}
