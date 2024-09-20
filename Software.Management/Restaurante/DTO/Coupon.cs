using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.DTO
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public double Discount { get; set; }
        public bool Active { get; set; } 
    }
}
