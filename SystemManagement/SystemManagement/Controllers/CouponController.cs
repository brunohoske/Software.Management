using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using SystemManagement.Dao;
using SystemManagement.Models;
using SystemManagement.Services;

namespace SystemManagement.Controllers
{
    public class CouponController : BaseController
    {

        private readonly CouponDao _coupanDao;
        private readonly HeaderService _headerService;

        public CouponController(CouponDao coupanDao, HeaderService headerService)
        {
            _coupanDao = coupanDao;
            _headerService = headerService;
        }

        [HttpGet("SearchCoupon/{code}")]
        public IActionResult SearchCouponFromCode(string code)
        {
            Store store = _headerService.GetCnpj();
            Coupon coupon = _coupanDao.SearchCouponFromCode(code,store);

            if (coupon != null)
            {
                return Ok(coupon);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
