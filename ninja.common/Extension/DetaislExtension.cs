
using ninja.model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ninja.common.Extension
{
   public static class DetaislExtension
    {
        public static List<InvoiceDetail> GetDetailsRef(this IList<Invoice> obj, long id)
        {
            var test = obj.ToList().Where(f => f.Id == id).FirstOrDefault();
            return test.GetDetail().ToList();
        }

    }
}
