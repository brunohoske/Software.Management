using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tablefy.Api.Company.Services;
using Tablefy.Api.Data;

namespace Tablefy.Api.Company
{
    [Route("api/menu/companies")]
    [ApiController]
    public class CompaniesMenuController : ControllerBase
    {
        private readonly CompanyService _service;

        public CompaniesMenuController(CompanyService service)
        {
            _service = service;
        }

        [HttpGet("cnpj/{cnpj}")]
        public async Task<ActionResult<CompanyModel>> GetCompanyByCnpj(string cnpj)
        {
            var companyModel = await _service.GetCompanyByCnpj(cnpj);
            if (companyModel == null)
                return NotFound();
            return Ok(companyModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyModel>> GetCompanyById(int id)
        {
            var companyModel = await _service.GetCompanyById(id);
            if (companyModel == null)
                return NotFound();
            return Ok(companyModel);
        }
    }
}
