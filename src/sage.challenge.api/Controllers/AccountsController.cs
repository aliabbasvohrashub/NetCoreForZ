using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sage.challenge.services;
using Microsoft.AspNetCore.Mvc;
using sage.challenge.data.Models;
using sage.challenge.api.Validators;

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
            var validator = new AccountValidator();
            var result = validator.Validate(account);
            if (!result.IsValid)
                return BadRequest(result.Errors);
            _accountRepository.AddAccount(account);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("accounts/{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
        public IActionResult AddUsers(Guid accountId, [FromBody] UserRequestModel user)
        {
            var validator = new UserValidator();
            var result = validator.Validate(user);
            if (!result.IsValid)
                return BadRequest(result.Errors);
            _accountRepository.AddUser(accountId, user);
            return Ok();
        }

        [HttpDelete("{accountId}/users/{userId}")]
        public void DeleteUser(Guid accountId, Guid userId)
        {
            _accountRepository.DeleteUser(accountId, userId);
        }

    }
}
