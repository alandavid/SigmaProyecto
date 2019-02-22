using AutoMapper;
using Castle.MicroKernel.Registration;
using ninja.common.Abstract;
using ninja.model.Entity;
using ninja.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.Mapping.Profiles.Invoice
{
 
    public class InvoiceMapper : AutoMapper.Profile
    {
        public InvoiceMapper()
        {
            MapDtoToDomain();
            MapDomainToDto();
        }

        private void MapDtoToDomain()
        {
            CreateMap<InvoiceDetailDto, InvoiceDetail>();
            CreateMap<InvoiceDto, ninja.model.Entity.Invoice>();
        }

        private void MapDomainToDto()
        {
            CreateMap<InvoiceDetail, InvoiceDetailDto>();
            CreateMap<ninja.model.Entity.Invoice, InvoiceDto>();
        }
    }
}