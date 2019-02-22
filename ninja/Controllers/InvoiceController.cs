using ninja.business.Interfaces;
using ninja.Mapping.Interfaces;
using ninja.model.Entity;
using ninja.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ninja.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceManager _manager;
        private ITransformMapper _transform;

        public InvoiceController(IInvoiceManager manager, ITransformMapper transform)
        {
            _manager = manager;
            _transform = transform;
        }
        // GET: Invoice
        public ActionResult Index()
        {
            List<InvoiceDto> result =
                _transform.Transform<List<Invoice>, List<InvoiceDto>>(_manager.GetAll().ToList());

            return View(result);

        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            InvoiceDto result =
              _transform.Transform<Invoice, InvoiceDto>(_manager.GetById(id));

            return View(result);
        }

        // POST: Invoice/Details
        [HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {
            try
            {
                var List = new List<InvoiceDetail>();

                _manager.UpdateDetail(id, List);

                return RedirectToAction("Details", id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _manager.Insert(new model.Entity.Invoice { Type = Convert.ToString(collection["Type"]) });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_transform.Transform<Invoice, InvoiceDto>(_manager.GetById(id)));
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                _manager.UpdateInvoiceById(new Invoice
                {
                    Id = id,
                    Type = Convert.ToString(collection["Type"])
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_transform.Transform<Invoice, InvoiceDto>(_manager.GetById(id)));
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _manager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Invoice/SaveDetails
        [HttpPost]
        public void SaveDetails(InvoiceDetailDto Detail)
        {

            _manager.AddDetail(_transform.Transform<InvoiceDetailDto, InvoiceDetail>(Detail));
        }

        // POST: Invoice/UpdateDetailById
        [HttpPost]
        public void UpdateDetailById(InvoiceDetailDto Detail)
        {

            _manager.UpdateDetailById(_transform.Transform<InvoiceDetailDto, InvoiceDetail>(Detail));

        }

        // POST: Invoice/DeleteDetailById
        [HttpPost]
        public void DeleteDetailById(InvoiceDetailDto Detail)
        {

            _manager.DeleteDetailById(_transform.Transform<InvoiceDetailDto, InvoiceDetail>(Detail));

        }
    }
}
