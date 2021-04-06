using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Order :IEntity
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int Money { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
