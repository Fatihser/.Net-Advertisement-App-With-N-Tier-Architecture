using FluentValidation;
using FSE.AdvertisementApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator:AbstractValidator<UserCreateModel>
    {
        [Obsolete]
        public UserCreateModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola bos olamaz.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola min 3 karakter olmalidir.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eslesmiyor.");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad bos olamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad bos olamaz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanici adi bos olamaz.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanici adi 3 karakterden az olamaz.");
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFisrtName(x.Username, x.Firstname)).WithMessage("Kullaniciadi adinizi iceremez!").
            When(x=>x.Username!=null&&x.Firstname!=null);

            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet secimi zorunludur.");
            
            
        }

        private bool CanNotFisrtName(string username,string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
