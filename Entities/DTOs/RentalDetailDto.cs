﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalDetailDto
    {
        public int RentId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string UserName { get; set; }
        
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }


    }
}
