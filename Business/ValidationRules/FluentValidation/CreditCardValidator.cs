using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.Cvv).Length(3);
            RuleFor(c => c.CardNo).Length(12);
            RuleFor(c => c.SonKullanim).Must(SonKullanimKontrol).WithMessage("Son kullanım tarih formatını kontrol ediniz. mm/yyyy şeklinde olmalı");
        }
        private bool SonKullanimKontrol(string sonKullanim)
        {
            try
            {
                if (sonKullanim.Length == 7)
                {
                    int ay = Convert.ToInt32(sonKullanim.Substring(0, 2));
                    int yil = Convert.ToInt32(sonKullanim.Substring(3, 4));
                    string slash = sonKullanim.Substring(2, 1);
                    if ((ay > 0 && ay <= 12) && slash == "/")
                    {
                        return true;
                    }

                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
