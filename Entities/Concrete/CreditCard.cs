using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardNo { get; set; }
        public string Cvv { get; set; }
        public string SonKullanim { get; set; }
        public string CardName { get; set; }
    }
}
