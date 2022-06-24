using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public List<Employee> Employees = new List<Employee>()
        {
             new Employee()
               {
                   Id =001, Name="Sachin", Address ="Kerala"
               },
             new Employee()
               {
                   Id =002, Name="Dhnanjay" ,Address="Kolkata"
               },
             new Employee()
               {
                   Id =003, Name="Ravish", Address="Raipur"
               },
             new Employee()
               {
                   Id =004, Name="Amit" ,Address="Channai"
               },
        };

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
        public ActionResult PostEmployee()
        {
            Employees.Add(new Employee { Id = 10001, Name = "PostEmployeeName", Address = "PostEmployeeAddress" });

            return Ok(Employees);
        }
        [HttpGet]
        public ActionResult GetEmployee()
        {
            return Ok(Employees);
        }
        [HttpPut]
        public ActionResult PutEmployee()
        { 
            Employees.Add(new Employee { Id = 1005, Name = "PutEmployeeName", Address = "PutEmployeeAddress" });
            return Ok(Employees);
        }
        [HttpDelete]
        public ActionResult DeleteEmployee()
        {
            Employees.RemoveAt(0);
            return Ok(Employees);
        }
        [HttpPatch]
        public ActionResult PatchEmployee(int Id, [FromBody] string Name)
        {
            var employee = Employees.FirstOrDefault(x => x.Id == Id);
            if (employee == null)
                return Ok("Wrong Employee ID");
            else
                employee.Name = Name;
            return Ok(employee);
        }
    }
}
