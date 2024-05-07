using feedbackmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace feedbackmvc.Controllers
{
    public class feedbackfromController : Controller
    {
        // GET: feedbackfrom
        public ActionResult feedbackfromIndex()
        {
            return View();
        }
        public ActionResult DetailsIndex(int Id) 
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult Savefeedbackfrom(FeedbackModel model)
        {
            try
            {
                return Json(new { Message = new FeedbackModel().Savefeedbackfrom(model) },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Getlist(FeedbackModel model)
        {
            try
            {
                return Json(new { model = new FeedbackModel().Getlist() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult deletefeedback(int Id)
        {
            try
            {
                return Json(new { Message = new FeedbackModel().deletefeedback(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult geteditbyId(int Id)
        {
            try
            {
                return Json(new { Message = new FeedbackModel().geteditbyId(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}