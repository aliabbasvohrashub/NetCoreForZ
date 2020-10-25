using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sage.challenge.services;
using Microsoft.AspNetCore.Mvc;
using sage.challenge.data.Models;
using sage.challenge.api.Validators;
using sage.challenge.api.Helper;
using sage.challenge.data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sage.challenge.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET: api/<controller>
        [HttpGet("accounts")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _accountRepository.GetAccounts());
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        [HttpGet("accounts/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _accountRepository.GetAccount(id));
        }

        // POST api/<controller>
        [HttpPost("accounts")]
        public IActionResult Post([FromBody] AccountRequestModel account)
        {
            string errors = string.Empty;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetAllValidationErrors());
            }
            _accountRepository.AddAccount(account);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("accounts/{id}")]
        public IActionResult Put(Guid id, [FromBody] AccountRequestModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetAllValidationErrors());
            }

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("accounts/{id}")]
        public void Delete(Guid id)
        {
            _accountRepository.DeleteAccount(id);
        }

        [HttpGet("{accountId}/users")]
        public async Task<IActionResult> GetUsers(Guid accountId)
        {
            return Ok(await _accountRepository.GetUsersByAccountId(accountId));
        }

        [HttpGet("{accountId}/users/{userId}")]
        public async Task<IActionResult> GetUser(Guid accountId, Guid userId)
        {
            return Ok(await _accountRepository.GetUsersByAccountIdAndUserId(accountId, userId));
        }

        [HttpPost("{accountId}/users")]
        public async Task<IActionResult> AddUsers(Guid accountId, [FromBody] UserRequestModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetAllValidationErrors());
            }

            Account account = await _accountRepository.GetAccount(accountId);

            if (account != null)
            {
                _accountRepository.AddUser(accountId, user);
                return Ok();
            }
            else
            {
                return BadRequest("account doesn't exist.");
            }
        }

        [HttpDelete("{accountId}/users/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid accountId, Guid userId)
        {
            Account account = await _accountRepository.GetAccount(accountId);
            
            if (account != null)
            {
                List<User> users = await _accountRepository.GetUsersByAccountId(accountId);
                if (users != null)
                {
                    User user = users.Where(x => x.Id == userId).FirstOrDefault();
                    if (user != null)
                    {
                        _accountRepository.DeleteUser(accountId, userId);
                        return Ok("user deleted.");
                    }
                }
                return BadRequest("user doesn't exist.");
            }
            return BadRequest("account doesn't exist.");
        }
    }
}
