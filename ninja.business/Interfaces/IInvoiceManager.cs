using System.Collections.Generic;
using ninja.model.Entity;

namespace ninja.business.Interfaces
{
    public interface IInvoiceManager
    {
        void Delete(long id);
        bool Exists(long id);
        IList<Invoice> GetAll();
        Invoice GetById(long id);
        void Insert(Invoice item);
        void UpdateDetail(long id, IList<InvoiceDetail> detail);
        void AddDetail(InvoiceDetail detail);
        void DeleteDetailById(InvoiceDetail detail);
        void UpdateDetailById(InvoiceDetail detail);
        void UpdateInvoiceById(Invoice invoice);
    }
}