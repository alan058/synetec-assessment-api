using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System.Threading.Tasks;
using System.Linq;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bonusPoolService = new BonusPoolService();

            return Ok(await bonusPoolService.GetEmployeesAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            var bonusPoolService = new BonusPoolService();
            //Get all Employee List
            var EmpList = bonusPoolService.GetEmployeesAsync();
            //Converting to all Employee list available to a List
            var checkEmp = EmpList.Result.ToList();
            //counting the employee Available in the list
            var CountEmp = checkEmp.Count();
            //checking if the selected Employee id in the list
            var VerifyEmpId = checkEmp.Where(x => x.EmployeeId == request.SelectedEmployeeId).FirstOrDefault();
            
            //returning the values based on the VerifyEmpId
            if (VerifyEmpId!=null)
            { //if verify id is true Return details of the employee
                return Ok(await bonusPoolService.CalculateAsync(
                  request.TotalBonusPoolAmount,
                  request.SelectedEmployeeId));
            }
            else
            {
                //if verify id is not valid means selected is not matching with Employee list, then return message.               
                return Ok("Employee Id Not Found! Please try Employee Id Between 1 to " +CountEmp + "."+ "or please do get request to see the availble Employee List.") ;
            }
           
        }
    }
}
