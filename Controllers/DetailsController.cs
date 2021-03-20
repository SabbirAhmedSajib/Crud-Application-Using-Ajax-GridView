using Crud_Application_Using_Ajax_GridView.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Crud_Application_Using_Ajax_GridView.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details

        Person_InformationEntities db = new Person_InformationEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataSet()

        {
            using (db)
            {
                List<Person_details> personlist = db.Person_details.ToList<Person_details>();
                personlist.ForEach(x => {
                    var gender = db.Gender_detail.FirstOrDefault(y => y.Gender_Id == x.Gender_Id);
                    x.Gender = gender.Info;
                });

                return Json(new {Message=1, data = personlist }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpGet]
        public ActionResult ADDorEDIT(int Id = 0)
        {
            if (Id == 0) {
                var getInfolist = db.Gender_detail.ToList();
                SelectList list = new SelectList(getInfolist, "Gender_Id", "Info");
                ViewBag.list = list;
                return View(new Person_details());
            }
                
            else
            {
                using (db)
                {
                    
                    var getInfolist = db.Gender_detail.ToList();
                    SelectList list = new SelectList(getInfolist, "Gender_Id", "Info");
                    ViewBag.list = list;

                    return View(db.Person_details.Where(x => x.Id== Id).FirstOrDefault<Person_details>());

                }
            }
        }

        [HttpPost]
        public ActionResult ADDorEDIT(Person_details personal_Information)
        {
            using (db)
            {
                try
                {
                    if (personal_Information.Id == 0)
                    {

                        var getGenderlist = db.Gender_detail.ToList();

                        SelectList list = new SelectList(getGenderlist, "Gender_Id", "Gender");
                        ViewBag.list = list;

                        db.Person_details.Add(personal_Information);
                        db.SaveChanges();
                        return Json(new { success = true, message = "Saved Successfully", JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        db.Entry(personal_Information).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
                    }
                }
                catch(Exception ex)
                {
                    return Json(new { success = false, message = "Update Failed", JsonRequestBehavior.AllowGet });
                }

                
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (db)
            {
                Person_details personal_Information = db.Person_details.Where(x => x.Id == id).FirstOrDefault<Person_details>();
                db.Person_details.Remove(personal_Information);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully", JsonRequestBehavior.AllowGet });
            }
        }
    }
}