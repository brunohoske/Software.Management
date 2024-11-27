using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using SystemManagement.Dao;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class StoreController : BaseController
    {
        StoreDao storeDao = new StoreDao();
        [HttpGet("Company/{cnpj}")]
        public IActionResult  GetCompanyFromCnpj(string cnpj)
        {
            if(storeDao.CheckExist(cnpj))
            {
                return Ok(storeDao.GetCompanyFromCnpj(cnpj));
            }
            else
            {
                return BadRequest("Loja não encontrada");
            }
            
            
        }
    }
}
