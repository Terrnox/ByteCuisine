using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] AccountDTO model)
        {
            try
            {
                var newAccount = new Account
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role,
                    PictureData = model.PictureData
                };
                _dataContext.Accounts.Add(newAccount);
                await _dataContext.SaveChangesAsync();
                return Ok(newAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> Get()
        {
            try
            {
                var list = await _dataContext.Accounts.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}