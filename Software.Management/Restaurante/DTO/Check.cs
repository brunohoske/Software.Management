using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.DTO
{
    internal class Check
    {

        public double Check_number { get; set; }
        
        public string CNPJ { get; set; }


        public Check(double check_number, string cnpj)
        {
            Check_number = check_number;
            CNPJ = cnpj;
        }

        public Check(double check_number)
        {
            Check_number = check_number;
        }
    }
}
