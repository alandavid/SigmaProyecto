using System.Collections.Generic;
using System.Linq;

namespace ninja.model.Entity
{

    public class Invoice
    {

        public Invoice()
        {

            this.Detail = new List<InvoiceDetail>();

        }

        public enum Types
        {
            A,
            B,
            C
        }

        /// <summary>
        /// Numero de factura
        /// </summary>

        public long Id { get; set; }
        public string Type { get; set; }
        private IList<InvoiceDetail> Detail { get; set; }

        public IList<InvoiceDetail> GetDetail()
        {

            return this.Detail;

        }

        public void AddDetail(InvoiceDetail detail)
        {

            this.Detail.Add(detail);

        }

        public void DeleteDetails()
        {

            this.Detail.Clear();

        }

        public void DeleteDetailsById(long id)
        {

            this.Detail.RemoveAt(this.Detail.IndexOf(this.Detail.Where(e => e.Id == id).FirstOrDefault()));

        }

        public void Update(Invoice obj)
        {

            this.Type = obj.Type;

        }
        public void UpdateDetailsById(InvoiceDetail obj)
        {

            this.Detail.Where(e=>e.Id==obj.Id).ToList().ForEach(x=> {
                x.Description = obj.Description;
                x.UnitPrice = obj.UnitPrice;
                x.Amount = obj.Amount;
            });

        }

        /// <summary>
        /// Sumar el TotalPrice de cada elemento del detalle
        /// </summary>
        /// <returns></returns>
        public double CalculateInvoiceTotalPriceWithTaxes()
        {

            double sum = 0;

            foreach (InvoiceDetail item in this.Detail)
                sum += item.TotalPrice * item.Taxes;

            return sum;

        }

    }

}