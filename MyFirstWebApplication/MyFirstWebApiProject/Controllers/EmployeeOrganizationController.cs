using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFirstWebApiProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeOrganizationController : Controller
    {
       public static List<EmployeeOrganization> employeeOrganizations = new List<EmployeeOrganization>();
        [HttpPost]
        public ActionResult PostEmpOrgByUri([System.Web.Http.FromUri] EmployeeOrganization emporg)
        {
            employeeOrganizations.Add(new EmployeeOrganization { EmpId = emporg.EmpId, OrgName = emporg.OrgName, YOW = emporg.YOW });
            return Ok(employeeOrganizations);
        }
        [HttpPost]
        public ActionResult PostEmpOrgByBody([System.Web.Http.FromBody] EmployeeOrganization emporg)
        {
            employeeOrganizations.Add(new EmployeeOrganization { EmpId = emporg.EmpId, OrgName = emporg.OrgName, YOW = emporg.YOW });
            return Ok(employeeOrganizations);
        }
        [HttpGet]
        public ActionResult GetEmpOrgByUriID([System.Web.Http.FromUri] int EmpId)
        {
            var emplorg = employeeOrganizations.FirstOrDefault(x => x.EmpId == EmpId);
            if (emplorg == null)
                return Ok("Wrong Employee ID");
            else
            {
                var SerializedOutput = JsonConvert.SerializeObject(emplorg);
                return Ok(SerializedOutput);
            }
        }
        [HttpGet]
        public ActionResult GetEmpOrgByBodyID([System.Web.Http.FromBody] int EmpId)
        {
            var emplorg = employeeOrganizations.FirstOrDefault(x => x.EmpId == EmpId);
            if (emplorg == null)
                return Ok("Wrong Employees ID");
            else
            {
                var SerializedOutput = JsonConvert.SerializeObject(emplorg);
                return Ok(SerializedOutput);
            }
        }
        [HttpGet]
        public ActionResult GetAllEmpOrgByBody()
        {
            return Ok(employeeOrganizations);
        }
        [HttpPut]
        public ActionResult PutEmpOrgByBody([System.Web.Http.FromBody] EmployeeOrganization emporg)
        {
            var emplorg = employeeOrganizations.Where(o => o.EmpId == emporg.EmpId).FirstOrDefault();
            if (emplorg == null)
                return Ok("Wrong Employees ID");
            else
            {
                emplorg.EmpId = emporg.EmpId;
                emplorg.OrgName = emporg.OrgName;
                emplorg.YOW = emporg.YOW;
                var SerializedOutput = JsonConvert.SerializeObject(emplorg);
                return Ok(SerializedOutput);
            }
        }
        [HttpPut]
        public ActionResult PutEmpOrgByUri([System.Web.Http.FromUri] EmployeeOrganization emporg)
        {
            var emplorg = employeeOrganizations.Where(o => o.EmpId == emporg.EmpId).FirstOrDefault();
            if (emplorg == null)
                return Ok("Wrong Employees ID");
            else
            {
                emplorg.EmpId = emporg.EmpId;
                emplorg.OrgName = emporg.OrgName;
                emplorg.YOW = emporg.YOW;
                var SerializedOutput = JsonConvert.SerializeObject(emplorg);
                return Ok(SerializedOutput);
            }
        }
        [HttpDelete]
        public ActionResult DeleteEmpOrg(int EmpId)
        {
            var emplorg = employeeOrganizations.FirstOrDefault(x => x.EmpId == EmpId);
            if (emplorg == null)
                return Ok("Wrong Employees ID");
            else
                employeeOrganizations.Remove(emplorg);
            return Ok(employeeOrganizations);
        }
        [HttpPatch]
        public ActionResult PatchEmpOrgByBody([System.Web.Http.FromBody] int EmpId, [System.Web.Http.FromBody] string OrgName)
        {
            var emplorg = employeeOrganizations.FirstOrDefault(x => x.EmpId == EmpId);
            if (emplorg == null)
                return Ok("Wrong Employees ID");
            else
            {
                emplorg.OrgName = OrgName;
            }
            return Ok(emplorg);
        }
        [HttpPatch]
        public ActionResult PatchEmpOrgByUri([System.Web.Http.FromUri] int EmpId, [System.Web.Http.FromUri] string OrgName)
        {
            var emplorg = employeeOrganizations.FirstOrDefault(x => x.EmpId == EmpId);
            if (emplorg == null)
                if (emplorg == null)
                return Ok("Wrong Employees ID");
            else
            {
                    emplorg.OrgName = OrgName;
                }
            return Ok(emplorg);
        }

    }
}
