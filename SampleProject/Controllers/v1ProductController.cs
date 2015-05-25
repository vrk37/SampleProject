using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SampleProject.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<v1Product>("v1Product");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class v1ProductController : ODataController
    {
        private ProductsModel db = new ProductsModel();

        // GET: odata/v1Product
        [EnableQuery] //todo
        public IQueryable<v1Product> Getv1Product() //todo
        {
            return db.v1Product;
        }

        // GET: odata/v1Product(5)
        [EnableQuery]
        public SingleResult<v1Product> Getv1Product([FromODataUri] int key)
        {
            return SingleResult.Create(db.v1Product.Where(v1Product => v1Product.ProductID == key));
        }

        // PUT: odata/v1Product(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<v1Product> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            v1Product v1Product = db.v1Product.Find(key);
            if (v1Product == null)
            {
                return NotFound();
            }

            patch.Put(v1Product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!v1ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(v1Product);
        }

        // POST: odata/v1Product
        public IHttpActionResult Post(v1Product v1Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.v1Product.Add(v1Product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (v1ProductExists(v1Product.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(v1Product);
        }

        // PATCH: odata/v1Product(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<v1Product> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            v1Product v1Product = db.v1Product.Find(key);
            if (v1Product == null)
            {
                return NotFound();
            }

            patch.Patch(v1Product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!v1ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(v1Product);
        }

        // DELETE: odata/v1Product(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            v1Product v1Product = db.v1Product.Find(key);
            if (v1Product == null)
            {
                return NotFound();
            }

            db.v1Product.Remove(v1Product);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool v1ProductExists(int key)
        {
            return db.v1Product.Count(e => e.ProductID == key) > 0;
        }
    }
}
