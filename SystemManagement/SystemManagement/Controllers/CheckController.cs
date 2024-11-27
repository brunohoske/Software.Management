using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using SystemManagement.Dao;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class CheckController : BaseController
    {

        [HttpPost("CloseCheck")]
        public IActionResult CloseCheck([FromBody] Table table)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            CheckDao checkDao = new CheckDao();
            if (checkDao.CloseCheck(table) == 1)
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
            CheckDao checkDao = new CheckDao();
            int value = checkDao.GetCheckValue(new Table() { Store = new Store() { Cnpj = cnpj }, TableNumber = 1 });
            return Ok(value);

        }
    }
}
