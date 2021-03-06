﻿using FluentValidation;
using NewGenFramework.Entities.Concrete;
using NewGenFramework.Business.DependencyResolvers.Ninject;
using NewGenFramework.Entities.Concrete;
using NewGenFramework.Business.Abstract;

namespace NewGenFramework.Business.ValidationRules.FluentValidation
{
   public class UserRoleValidator:AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
        //Eğer CustomRule yazmak istenirse service interfacelerini çözer custom rule için gerekli metodlara ulaşmanızı sağlar
        var userRoleService = DependencyResolver<IUserRoleService>.Resolve();
        //Sadece Boş Olamaz Kontrolü Yapar
            RuleFor(x => x.UserRoleId).NotEmpty();
RuleFor(x => x.RoleId).NotEmpty();
RuleFor(x => x.Role).NotEmpty();
RuleFor(x => x.User).NotEmpty();
RuleFor(x => x.UserId).NotEmpty();


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