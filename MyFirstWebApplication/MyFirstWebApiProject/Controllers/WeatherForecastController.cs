using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFirstWebApiProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    
    public class WeatherForecastController : ControllerBase
    {
        public static List<Employee> Employees = new List<Employee>();
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult PostEmpByUri([System.Web.Http.FromUri] Employee employees)
        {
            Employees.Add(new Employee { Id = employees.Id, Name = employees.Name, Address = employees.Address });
            return Ok(Employees);
        }
        [HttpPost]
        public ActionResult PostEmpByBody([System.Web.Http.FromBody] Employee employees)
        {
            Employees.Add(new Employee { Id = employees.Id, Name = employees.Name, Address = employees.Address });
            return Ok(Employees);
        }
        [HttpGet]
        public ActionResult GetEmpByUriID([System.Web.Http.FromUri] int Id)
        {
            var employee = Employees.FirstOrDefault(x => x.Id == Id);
            if (employee == null)
                return Ok("Wrong Employees ID");
            else
            {
                var SerializedOutput = JsonConvert.SerializeObject(employee);
                return Ok(SerializedOutput);
            }
        }
        [HttpGet]
        public ActionResult GetEmpByBodyID([System.Web.Http.FromBody] int Id)
        {
            var employee = Employees.FirstOrDefault(x => x.Id == Id);
            if (employee == null)
                return Ok("Wrong Employees ID");
            else
            {
                var SerializedOutput = JsonConvert.SerializeObject(employee);
                return Ok(SerializedOutput);
            }
        }
        [HttpGet]
        public ActionResult GetAllEmpByBody()
        {
                return Ok(Employees);   
        }
        [HttpPut]
        public ActionResult PutEmpByBody([System.Web.Http.FromBody] Employee employees)
        {
            var employee = Employees.Where(o => o.Id == employees.Id).FirstOrDefault();
            if (employee == null)
                return Ok("Wrong Employees ID");
            else
            {
                employee.Id = employees.Id;
                employee.Name = employees.Name;
                employee.Address = employees.Address;
                var SerializedOutput = JsonConvert.SerializeObject(employee);
                return Ok(SerializedOutput);
            }
        }
        [HttpPut]
        public ActionResult PutEmpByUri([System.Web.Http.FromUri] Employee employees)
        {
            var employee = Employees.Where(o => o.Id == employees.Id).FirstOrDefault();
            if (employee == null)
                return Ok("Wrong Employees ID");
            else
            {
                employee.Id = employees.Id;
                employee.Name = employees.Name;
                employee.Address = employees.Address;
                var SerializedOutput = JsonConvert.SerializeObject(employee);
                return Ok(SerializedOutput);
            }
        }
        [HttpDelete]
        public ActionResult DeleteEmployee(int Id)
        {
            var employee = Employees.FirstOrDefault(x => x.Id == Id);
            if (employee == null)
                return Ok("Wrong Employees ID");
            else
                Employees.Remove(employee);
            return Ok(Employees);
        }
        [HttpPatch]
        public ActionResult PatchEmpByBody([System.Web.Http.FromBody] int Id, [System.Web.Http.FromBody] string Address)
        {
            var employee = Employees.FirstOrDefault(x => x.Id == Id);
            if (employee == null)
                return Ok("Wrong Employees ID");
            else
            {
                employee.Address = Address;
            }
            return Ok(employee);
        }
        [HttpPatch]
        public ActionResult PatchEmpByUri([System.Web.Http.FromUri] int Id, [System.Web.Http.FromUri] string Address)
        {
            var employee = Employees.FirstOrDefault(x => x.Id == Id);
            if (employee == null)
                return Ok("Wrong Employees ID");
            else
            {
                employee.Address = Address;
            }
            return Ok(employee);
        }
    }
}