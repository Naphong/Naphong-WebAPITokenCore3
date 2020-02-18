using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;



namespace WebApi.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("api/TransApi/GetByCurrency/{id}")]
        public string GetByCurrency(string id)
        {
            //var _TransactionDataList = (from t in db.TransactionData.AsEnumerable()
            //                            where t.CurrencyCode == id
            //                            select new TransactionReport { id = t.TransactionId, payment = t.Amount.ToString() + t.CurrencyCode, Status = t.Status }).ToList();
            //string JSONresult = JsonConvert.SerializeObject(_TransactionDataList);
            //return JSONresult;
            return "";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

         [HttpGet("free")]
        public IActionResult GetAllFree()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("adminload")]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("free2")]
        public async Task<IActionResult> GetAll2()
        {
            var users = await _userService.GetAll2();
            return Ok(users);
        }

         [HttpGet("{id}")]     
        public IActionResult GetById(int id)
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user =  _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
