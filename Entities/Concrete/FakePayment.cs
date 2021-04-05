using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class FakePayment:ICarEntity
    {
        [Key]
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string CardCvv { get; set; }
        public string ExpirationDate { get; set; }
        public decimal MoneyInCard { get; set; }
    }
}
