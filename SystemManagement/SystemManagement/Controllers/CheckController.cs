using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.DAO;
using SystemManagement.Models;
using SystemManagement.Services;

namespace SystemManagement.Controllers
{
    public class CheckController : BaseController
    {
        private readonly CheckDao _checkDao;
        private readonly HeaderService _headerService;

        public CheckController(CheckDao checkDao, HeaderService headerService)
        {
            _checkDao = checkDao;
            _headerService = headerService;
        }

        [HttpPost("CloseCheck")]
        public IActionResult CloseCheck([FromBody] Table table)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            if (_checkDao.CloseCheck(table) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpGet("GetPaymetValue")]
        public IActionResult GetPaymentValue()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            int value = _checkDao.GetCheckValue(new Table() { Store = new Store() { Cnpj = cnpj }, TableNumber = 1 });
            return Ok(value);

        }
    }
}
