﻿using FluentValidation;
using BayiPuan.Entities.Concrete;
using BayiPuan.Business.DependencyResolvers.Ninject;
using BayiPuan.Business.Abstract;

namespace BayiPuan.Business.ValidationRules.FluentValidation
{
  public class SellerValidator : AbstractValidator<Seller>
  {
    public SellerValidator()
    {
      //Eğer CustomRule yazmak istenirse service interfacelerini çözer custom rule için gerekli metodlara ulaşmanızı sağlar
      var sellerService = DependencyResolver<ISellerService>.Resolve();
      //Sadece Boş Olamaz Kontrolü Yapar
      RuleFor(x => x.SellerId).NotEmpty();
      RuleFor(x => x.UserTypeId).NotEmpty();
      RuleFor(x => x.SellerName).NotEmpty();
      RuleFor(x => x.CityId).NotEmpty();
      RuleFor(x => x.SellerCode).NotEmpty();


      //Custom Rule Kullanımı Aşağıdaki gibidir
      //Custom(rm =>
      //{
      //var useremail = userService.UniqueEmail(rm.Email);
      //    if (rm.Agreement != true /*&& useremail.Email != null*/)
      //    {
      //        return new ValidationFailure(/*you must type the property name here, you must type the error message here */);
      //    }
      //    return null;
      //});
    }
  }
}