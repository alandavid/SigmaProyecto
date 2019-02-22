using Microsoft.VisualStudio.TestTools.UnitTesting;
using ninja.business;
using ninja.business.Interfaces;
using ninja.model.Entity;
using ninja.common.Exception;
using System;
using System.Collections.Generic;
using ninja.dataAcces.Mock;

namespace ninja.test
{

    [TestClass]
    public class TestInvoice
    {
        private static IInvoiceManager manager;


        #region StartUp
        /// <summary>
        /// Se ejecuta al inicio de la clase de Test.
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            manager = new InvoiceManager();

        }
        /// <summary>
        /// Se ejecuta antes de cada Test.
        /// </summary>
        [TestInitialize()]
        public void SetUp()
        {


        }


        //Creo el Manager usando el objeto Mock

        #endregion

        [TestMethod]
        public void InsertNewInvoice()
        {
            long id = 1006;
            Invoice invoice = new Invoice()
            {
                Id = id,
                Type = Invoice.Types.A.ToString()
            };

            manager.Insert(invoice);

            Invoice result = manager.GetById(id);

            Assert.AreEqual(invoice, result);

        }

        [TestMethod]
        public void InsertNewDetailInvoice()
        {

           
            long id = 1006;
            Invoice invoice = new Invoice()
            {
                Id = id,
                Type = Invoice.Types.A.ToString()
            };

            invoice.AddDetail(new InvoiceDetail()
            {
                Id = id,
                InvoiceId = id,
                Description = "Venta insumos varios",
                Amount = 14,
                UnitPrice = 4.33
            });

            invoice.AddDetail(new InvoiceDetail()
            {
                Id = id,
                InvoiceId = 6,
                Description = "Venta insumos tóner",
                Amount = 5,
                UnitPrice = 87
            });

            manager.Insert(invoice);

            Invoice result = manager.GetById(id);

            Assert.AreEqual(invoice, result);

        }

        [TestMethod]

        public void DeleteInvoice()
        {
            /*
              1- Eliminar la factura con id=4
              2- Comprobar de que la factura con id=4 ya no exista
              3- La prueba tiene que mostrarse que se ejecuto correctamente
            */

            #region Escribir el código dentro de este bloque

            long id = 4;

            try
            {
                bool Exist = manager.Exists(id);

                if (Exist)
                    manager.Delete(id);

                Invoice result = manager.GetById(id);

                Assert.IsNull(result);

            }
            catch (MockRepositoryDeleteException exCustom)
            {

                Assert.Fail(exCustom.Message);

            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);

            }



            #endregion Escribir el código dentro de este bloque

        }

        [TestMethod]
        public void UpdateInvoiceDetail()
        {

            long id = 1003;

            IList<InvoiceDetail> detail = new List<InvoiceDetail>();

            detail.Add(new InvoiceDetail()
            {
                Id = 1,
                InvoiceId = id,
                Description = "Venta insumos varios",
                Amount = 14,
                UnitPrice = 4.33
            });

            detail.Add(new InvoiceDetail()
            {
                Id = 2,
                InvoiceId = id,
                Description = "Venta insumos tóner",
                Amount = 5,
                UnitPrice = 87
            });

            try
            {
                manager.UpdateDetail(id, detail);

                Invoice result = manager.GetById(id);

                IList<InvoiceDetail> Result = result.GetDetail();

                Assert.AreEqual(2, Result.Count);

            }
            catch (MockRepositoryUpdateException exCustom)
            {

                Assert.Fail(exCustom.Message);

            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);

            }


        }

        [TestMethod]
        public void CalculateInvoiceTotalPriceWithTaxes()
        {

            long id = 1005;

            Invoice invoice = manager.GetById(id);

            double sum = 0;

            foreach (InvoiceDetail item in invoice.GetDetail())
                sum += item.TotalPrice * item.Taxes;

            Assert.AreEqual(sum, invoice.CalculateInvoiceTotalPriceWithTaxes());

        }


    }

}