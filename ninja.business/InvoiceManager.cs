using ninja.business.Interfaces;
using ninja.common.Exception;
using ninja.dataAcces.Interfaces;
using ninja.dataAcces.Mock;
using ninja.model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ninja.business
{
    /// <summary>
    /// Clase responsable por centralizar los metodos y Logicas de Invoice FACADE
    /// </summary>
    public class InvoiceManager : IInvoiceManager
    {

        private IInvoiceMock _mock;

        public InvoiceManager()
        {

            this._mock = InvoiceMock.GetInstance();

        }

        /// <summary>
        /// Metedo responsable en obtener todas la facturas existentes en la DB(mock)
        /// </summary>
        /// <returns>Return un listado de facturas</returns>
        public IList<Invoice> GetAll()
        {

            return this._mock.GetAll();

        }

        /// <summary>
        /// Metodo Responsable en obtner una unica factura pr Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve la factura buscada</returns>
        public Invoice GetById(long id)
        {

            return this._mock.GetById(id);

        }

        /// <summary>
        /// Inserta una nueva Factura en la DB
        /// </summary>
        /// <param name="item"></param>
        public void Insert(Invoice item)
        {
            try
            {
                item.Id = item.Id == 0 ? GenereteId() : item.Id;

                this._mock.Insert(item);
            }
            catch (Exception)
            {

                throw new MockRepositoryInsertException();
            }


        }

        /// <summary>
        /// Elimina Factura por Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            try
            {
                Invoice invoice = this.GetById(id);
                this._mock.Delete(invoice);
            }
            catch (Exception)
            {

                throw new MockRepositoryDeleteException();
            }
        }

        /// <summary>
        /// Verifica si la Factura ya existe en la Db por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean Exists(long id)
        {

            return this._mock.Exists(id);

        }

        /// <summary>
        /// Actualiza Factura en la Db por Id
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateInvoiceById(Invoice invoice)
        {

            #region Escribir el código dentro de este bloque
            try
            {
                _mock.UpdateInvoiceById(invoice);

            }

            catch (Exception)
            {

                throw new MockRepositoryUpdateException();
            }

            #endregion Escribir el código dentro de este bloque
        }

        /// <summary>
        /// Actualizar Detalles de la factura por id y su Listado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="detail"></param>
        public void UpdateDetail(long id, IList<InvoiceDetail> detail)
        {

            #region Escribir el código dentro de este bloque

            try
            {
                _mock.UpdateDetail(id, detail);

            }

            catch (Exception)
            {

                throw new MockRepositoryUpdateException();
            }

            #endregion Escribir el código dentro de este bloque

        }

        /// <summary>
        /// Inserta una nuevo Iten en la Factura en la DB
        /// </summary>
        /// <param name="detail"></param>
        public void AddDetail(InvoiceDetail detail)
        {

            try
            {
                detail.Id = detail.Id == 0 ? GenereteDetails(detail.InvoiceId) : detail.Id;

                _mock.AddDetailOnlyOne(detail);

            }

            catch (Exception)
            {

                throw new MockRepositoryInsertException();
            }



        }

        /// <summary>
        /// Responsable en eliminar Un item de la factura en la DB
        /// </summary>
        /// <param name="detail"></param>
        public void DeleteDetailById(InvoiceDetail detail)
        {

            try
            {

                _mock.DeleteDetailById(detail);

            }

            catch (Exception)
            {

                throw new MockRepositoryDeleteException();
            }

        }

        /// <summary>
        /// Actualiza Iten de la factura por Id
        /// </summary>
        /// <param name="detail"></param>
        public void UpdateDetailById(InvoiceDetail detail)
        {
            try
            {

                _mock.UpdateDetailById(detail);

            }

            catch (Exception)
            {

                throw new MockRepositoryUpdateException();
            }

        }

        /// <summary>
        /// Metodo Auxiliar para la generacion de un nuevo Id  Invoice simula un Identity de SQL
        /// </summary>
        /// <returns>Nuevo Id</returns>
        private long GenereteId()
        {
            return GetAll().OrderBy(e => e.Id).Last().Id + 1;
        }

        /// <summary>
        /// Metodo Auxiliar para la generacion de un nuevo Id  InvoiceDetails simula un Identity de SQL
        /// </summary>
        /// <param name="idInvoice"></param>
        /// <returns></returns>
        private long GenereteDetails(long idInvoice)
        {
            var Detalles = GetById(idInvoice).GetDetail();
            return Detalles.Any() ? Detalles.OrderBy(e => e.Id).Last().Id + 1 : 1;
        }

    }

}