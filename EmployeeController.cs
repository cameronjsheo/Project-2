using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DimensionData.DAL;
using DimensionData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DimensionData.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {  
        readonly Context dbContext = new Context();
      
        public ActionResult Index()
        {
            List<Employee> emplist = dbContext.GetEmployees().ToList();
            return View(emplist);
        }

     //[Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            AllDisplay allDisplay = dbContext.ReturnAll(id);
            if (allDisplay == null)
            {
                return NotFound();
            }

            return View(allDisplay);
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] AllDisplay allDisplay)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.Insert(allDisplay);
                    return RedirectToAction("Index");
                }

                return View(allDisplay);
            }
            catch
            {
                return View();
            }
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            AllDisplay allDisplay = dbContext.ReturnAll(id);
            if (allDisplay == null)
            {
                return NotFound();
            }

            return View(allDisplay);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] AllDisplay all)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    dbContext.UpdateAll(all, id);
                    return RedirectToAction("Index");
                }

                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {

            if (id <= 0)
            {
                return NotFound();
            }
            AllDisplay allDisplay = dbContext.ReturnAll(id);
            if (allDisplay == null)
            {
                return NotFound();
            }

            return View(allDisplay);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                dbContext.DeleteRecords(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Analysis()
        {
            
            Gender gender = dbContext.GetGender();
            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        public ActionResult Age()
        {
            Age age = dbContext.GetAge();
            if (age == null)
            {
                return NotFound();
            }

            return View(age);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Cost()
        {
            Costs cost = dbContext.GetCosts();
            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }





    }
}
