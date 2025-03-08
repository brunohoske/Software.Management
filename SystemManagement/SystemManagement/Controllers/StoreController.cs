using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using System.Net;
using SystemManagement.Dao;
using SystemManagement.DTOs;
using SystemManagement.Models;
using SystemManagement.Services;

namespace SystemManagement.Controllers
{
    public class StoreController : BaseController
    {
        private readonly StoreDao _storeDao;
        private readonly HeaderService _headerService;

        public StoreController(StoreDao storeDao, HeaderService headerService)
        {
            _storeDao = storeDao;
            _headerService = headerService;
        }

        [HttpGet("Check/Store/{cnpj}")]
        public IActionResult CheckExists(string cnpj)
        {
            if (_storeDao.CheckStoreExists(cnpj))
            {
                return Ok(true);
            }
            return BadRequest();
        }

        [HttpGet("Company/{cnpj}")]
        public IActionResult  GetCompanyFromCnpj(string cnpj)
        {
            try
            {
                if (_storeDao.CheckExist(cnpj))
                {
                    return Ok(_storeDao.GetCompanyFromCnpj(cnpj));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
            
           
            
            
        }
    }
}
