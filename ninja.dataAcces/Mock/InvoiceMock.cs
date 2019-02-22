using ninja.common.Extension;
using ninja.dataAcces.Interfaces;
using ninja.model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ninja.dataAcces.Mock
{

    public class InvoiceMock : IInvoiceMock
    {

        #region Singleton

        private static InvoiceMock _instance = null;

        public static InvoiceMock GetInstance()
        {

            if (_instance == null)
                _instance = new InvoiceMock();

            return _instance;

        }

        #endregion Singleton

        /// <summary>
        /// Mock DB
        /// </summary>
        private IList<Invoice> _db;

        private InvoiceMock()
        {

            this._db = new List<Invoice>();

            this.Init();

        }

        private void Init()
        {

            this._db.Add(new Invoice()
            {
                Id = 1000,
                Type = Invoice.Types.A.ToString()
            });

            this._db.Add(new Invoice()
            {
                Id = 1002,
                Type = Invoice.Types.B.ToString()
            });

            Invoice invoice3 = new Invoice()
            {
                Id = 1003,
                Type = Invoice.Types.A.ToString()
            };

            invoice3.AddDetail(new InvoiceDetail() { Id = 1, InvoiceId = 3, Amount = 22, Description = "Venta varias", UnitPrice = 98.1 });

            this._db.Add(invoice3);

            this._db.Add(new Invoice()
            {
                Id = 1004,
                Type = Invoice.Types.A.ToString()
            });


            Invoice invoice5 = new Invoice()
            {
                Id = 1005,
                Type = Invoice.Types.A.ToString()
            };

            invoice5.AddDetail(new InvoiceDetail() { Id = 1001, InvoiceId = 5, Amount = 22, Description = "Venta varias", UnitPrice = 98.1 });
            invoice5.AddDetail(new InvoiceDetail() { Id = 1002, InvoiceId = 5, Description = "Venta insumos varios", Amount = 14, UnitPrice = 4.33 });
            invoice5.AddDetail(new InvoiceDetail() { Id = 1003, InvoiceId = 5, Description = "Venta insumos tóner", Amount = 5, UnitPrice = 87 });

            this._db.Add(invoice5);

        }

        public void Delete(Invoice invoice)
        {

            this._db.Remove(invoice);

        }

        public IList<Invoice> GetAll()
        {

            return this._db;

        }

        public Invoice GetById(long id)
        {

            return this._db.Where(x => x.Id == id).FirstOrDefault();

        }

        public void Insert(Invoice item)
        {

            this._db.Add(item);

        }

        public Boolean Exists(long id)
        {

            return this._db.Where(x => x.Id == id).Any();

        }

        public void DeleteDetail(long id)
        {

            this.GetById(id).DeleteDetails();

        }

        public void AddDetail(long id, IList<InvoiceDetail> detail)
        {

            foreach (InvoiceDetail item in detail)
                this.GetById(id).AddDetail(item);

        }

        public void AddDetailOnlyOne(InvoiceDetail detail)
        {


            this.GetById(detail.InvoiceId).AddDetail(detail);

        }

        public void DeleteDetailById(InvoiceDetail detail)
        {


            this.GetById(detail.InvoiceId).DeleteDetailsById(detail.Id);

        }

        public void UpdateDetailById(InvoiceDetail detail)
        {


            this.GetById(detail.InvoiceId).UpdateDetailsById(detail);

        }

        public void UpdateInvoiceById(Invoice invoice)
        {


            this.GetById(invoice.Id).Update(invoice);

        }

        public void UpdateDetail(long id, IList<InvoiceDetail> detail)
        {

            /*
              Este método tiene que reemplazar todos los items del detalle de la factura
              por los recibidos por parámetro
             */

            #region Escribir el código dentro de este bloque

            Invoice Source = GetById(id);

            detail.ToList().ForEach(e =>
            {
                bool auxExistDetail = _db.GetDetailsRef(id).Any(x => x.Id == e.Id);

                if (auxExistDetail)
                {
                    _db.GetDetailsRef(id).ToList().ForEach(f =>
                    {
                        var objectChange = detail.Where(x => x.Id == e.Id).Select(x => x).FirstOrDefault();
                        f.Description = objectChange.Description;
                        f.Amount = objectChange.Amount;
                        f.InvoiceId = objectChange.InvoiceId;
                        f.UnitPrice = objectChange.UnitPrice;
                    });
                }
                else
                {
                    _db.Where(x => x.Id == id).FirstOrDefault().GetDetail().Add(e);
                }
            });




            #endregion Escribir el código dentro de este bloque

        }

    }

}