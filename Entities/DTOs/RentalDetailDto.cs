using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalDetailDto
    {
        public int RentId { get; set; }
       
       
        public string UserName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }


    }
}
