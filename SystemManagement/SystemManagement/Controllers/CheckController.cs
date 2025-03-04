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

        [HttpGet("CheckExists/{id}")]
        public IActionResult CheckExists(int id)
        {
            Store store = _headerService.GetCnpj();
            if (_checkDao.CheckExists(id,store))
            {
                return Ok(true);
            }
            return BadRequest();
        }

        [HttpPost("CloseCheck")]
        public IActionResult CloseCheck([FromBody] Table table)
        {
            Store store = _headerService.GetCnpj();
            if (_checkDao.CloseCheck(table,store) == 1)
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
            Store store = _headerService.GetCnpj();
            int value = _checkDao.GetCheckValue(new Table() { Store = store, TableNumber = 1 });
            return Ok(value);

        }
    }
}
