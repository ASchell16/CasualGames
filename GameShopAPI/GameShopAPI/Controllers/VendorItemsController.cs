using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Common.Models;
using CSWeek3._1.Models;
using GameShopAPI.Models;

namespace GameShopAPI.Controllers
{
    public class VendorItemsController : ApiController
    {
        private GameShopAPIContext db = new GameShopAPIContext();      

        // GET: api/VendorItems/5
        [ResponseType(typeof(List<Item>))]
        public IHttpActionResult GetVendorItem(int id)
        {
            List<Item> items = new List<Item>();
            try
            {
                items = db.VendorItems.
                        Where(vi => vi.VendorID == id).
                        Include("Item").
                        Select(I => I.Item).
                        ToList();
            }
            catch
            {
                return NotFound();
            }
            return Ok(items);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendorItemExists(int id)
        {
            return db.VendorItems.Count(e => e.ID == id) > 0;
        }
    }
}