using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarRentAndPayDto:IDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CardNo { get; set; }
        public string Cvv { get; set; }
        public string SonKullanim { get; set; }
    }
}
