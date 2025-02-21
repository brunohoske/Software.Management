using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.Models;
using SystemManagement.Services;

namespace SystemManagement.Controllers
{
    public class ComboController : BaseController
    {
        private readonly ComboDao _comboDao;
        private readonly HeaderService _headerService;

        public ComboController(ComboDao comboDao, HeaderService headerService)
        {
            _comboDao = comboDao;
            _headerService = headerService;
        }

        [HttpGet("Combos")]
        public IActionResult GetCombos()
        {
            string cnpj = _headerService.GetCnpj();
            List<Combo> combos = _comboDao.GetCombos(cnpj);
            return Ok(combos);
        }
        [HttpGet("Combos/{id}")]
        public IActionResult GetComboFromId(int id)
        {
            string cnpj = _headerService.GetCnpj();
            Combo combo = _comboDao.GetCombosFromId(id, cnpj);
            return Ok(combo);
        }
    }
}
