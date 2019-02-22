using AutoMapper;

using ninja.Mapping.Interfaces;
using ninja.Mapping.Profiles.Invoice;
//using Falabella.Cmr.SumaT.Business.Mapping.Profiles.Originacion;
//using Falabella.Cmr.SumaT.Business.Mapping.Profiles.PagoAutomatico;
//using Falabella.Cmr.SumaT.Business.Mapping.Profiles.Shared;
using System;

namespace ninja.Mapping
{
  
    public class BusinessTransformMapper : ITransformMapper
    {
        public static IMapper _Mapper;
        private static MapperConfiguration _Config;

        public BusinessTransformMapper()
        {
            _Config = new MapperConfiguration(cfg =>
            {
                #region Invoice

                cfg.AddProfile<InvoiceMapper>();
               
                #endregion

              
            });
            _Mapper = _Config.CreateMapper();
        }

        public TResult Transform<TInput, TResult>(TInput input)
        {
            try
            {
                return _Mapper.Map<TInput, TResult>(input);
            }
            catch (Exception)
            {
                throw new NonTransformableException(String.Format("Type {0} can't be casted to Type {1}", typeof(TInput).Name, typeof(TResult).Name));
            }
        }
    }
}