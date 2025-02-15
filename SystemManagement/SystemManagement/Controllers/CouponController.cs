using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using SystemManagement.Dao;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class CouponController : BaseController
    {
        [HttpGet("SearchCoupon/{code}")]
        public IActionResult SearchCouponFromCode(string code)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            CouponDao couponDao = new CouponDao();
            Coupon coupon = couponDao.SearchCouponFromCode(code);

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
