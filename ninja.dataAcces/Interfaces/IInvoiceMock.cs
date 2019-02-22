using System.Collections.Generic;
using ninja.model.Entity;

namespace ninja.dataAcces.Interfaces
{
    public interface IInvoiceMock
    {
        void AddDetail(long id, IList<InvoiceDetail> detail);
        void AddDetailOnlyOne( InvoiceDetail detail);
        void Delete(Invoice invoice);
        void DeleteDetail(long id);
        void DeleteDetailById(InvoiceDetail detail);
        bool Exists(long id);
        IList<Invoice> GetAll();
        Invoice GetById(long id);
        void Insert(Invoice item);
        void UpdateDetail(long id, IList<InvoiceDetail> detail);
        void UpdateDetailById(InvoiceDetail detail);
        void UpdateInvoiceById(Invoice invoice);
    }
}