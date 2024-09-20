using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.DTO
{
    public class FeedBack
    {
        public int FeedbackId { get; set; }
        public Order? Order { get; set; }
        public string? Description { get; set; }
    }
}
