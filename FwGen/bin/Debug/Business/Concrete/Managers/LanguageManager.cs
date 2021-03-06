﻿
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NewGenFramework.Business.Abstract;
using NewGenFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using NewGenFramework.Core.Aspects.Postsharp.CacheAspects;
using NewGenFramework.Core.Aspects.Postsharp.TransactionAspects;
using NewGenFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using NewGenFramework.DataAccess.Abstract;
using NewGenFramework.Entities.Concrete;
using NewGenFramework.Core.CrossCuttingConcerns.Transaction;

namespace NewGenFramework.Business.Concrete.Managers
{
    public class LanguageManager : ManagerBase, ILanguageService
    {
        private ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }
        
         // [LogAspect(typeof(DatabaseLogger))]
        [CacheAspect(typeof(MemoryCacheManager))]
        // [PerformanceCounterAspect(1)]      
        public List<Language> GetAll()
        {
            return _languageDal.GetList();
        }

        public Language GetById(int languageId)
        {
            return _languageDal.Get(u => u.LanguageId == languageId);
        }      

        //[FluentValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Language Add(Language language)
        {
            return _languageDal.Add(language);
        }
        //[FluentValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Language language)
        {
              _languageDal.Update(language);
        }

        public void Delete(Language language)
        {
            _languageDal.Delete(language);
        }    

        public List<Language> GetByLanguage(int languageId)
        {
            return _languageDal.GetList(filter: t => t.LanguageId == languageId).ToList();
        }
    }
}
