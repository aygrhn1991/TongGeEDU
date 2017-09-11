using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TongGeEDU.Entity;

namespace TongGeEDU.Controllers
{
    public class AdminController : Controller
    {
        TongGeDB entity = new TongGeDB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
        #region 轮播
        public ActionResult CollapseListView()
        {
            return View();
        }
        public ActionResult CollapseAddView()
        {
            return View();
        }
        public ActionResult CollapseLinkView(int id)
        {
            return View();
        }
        public ActionResult Collapse_Add()
        {
            HttpPostedFileBase file = Request.Files[0];
            string filename = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            file.SaveAs(HttpContext.Server.MapPath("~/Attachments/collapse") + "\\" + filename);
            tg_collapse collapse = new tg_collapse() { filename = filename };
            entity.tg_collapse.Add(collapse);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Collapse_Delete(int id)
        {
            tg_collapse item = entity.tg_collapse.FirstOrDefault(p => p.id == id);
            entity.tg_collapse.Remove(item);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Collapse_Query()
        {
            var list = entity.tg_collapse;
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CollapseLink_Edit(int id, string content)
        {
            tg_collapse item = entity.tg_collapse.FirstOrDefault(p => p.id == id);
            item.content = content;
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CollapseLink_Query(int id)
        {
            tg_collapse item = entity.tg_collapse.FirstOrDefault(p => p.id == id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 广告
        public ActionResult CompanyListView()
        {
            return View();
        }
        public ActionResult CompanyAddView()
        {
            return View();
        }
        public ActionResult Company_Add(string url)
        {
            HttpPostedFileBase file = Request.Files[0];
            string filename = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            file.SaveAs(HttpContext.Server.MapPath("~/Attachments/company") + "\\" + filename);
            tg_company company = new tg_company() { filename = filename, url = url };
            entity.tg_company.Add(company);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Company_Delete(int id)
        {
            tg_company item = entity.tg_company.FirstOrDefault(p => p.id == id);
            entity.tg_company.Remove(item);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Company_Edit(int id, string url)
        {
            tg_company item = entity.tg_company.FirstOrDefault(p => p.id == id);
            item.url = url;
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Company_Query()
        {
            var list = entity.tg_company;
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 视频课程
        public ActionResult CourseListView()
        {
            return View();
        }
        public ActionResult CourseAddView()
        {
            return View();
        }
        public ActionResult CourseSourceView(int id)
        {
            return View();
        }
        public ActionResult Course_Add()
        {
            HttpPostedFileBase file = Request.Files[0];
            string filename = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            file.SaveAs(HttpContext.Server.MapPath("~/Attachments/collapse") + "\\" + filename);
            tg_collapse collapse = new tg_collapse() { filename = filename };
            entity.tg_collapse.Add(collapse);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Course_Delete(int id)
        {
            tg_collapse item = entity.tg_collapse.FirstOrDefault(p => p.id == id);
            entity.tg_collapse.Remove(item);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Course_Query()
        {
            var list = entity.tg_course;
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Add(int id, string content)
        {
            tg_collapse item = entity.tg_collapse.FirstOrDefault(p => p.id == id);
            item.content = content;
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Delete(int id, string content)
        {
            tg_collapse item = entity.tg_collapse.FirstOrDefault(p => p.id == id);
            item.content = content;
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Edit(int id, string content)
        {
            tg_collapse item = entity.tg_collapse.FirstOrDefault(p => p.id == id);
            item.content = content;
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Query(int id)
        {
            tg_collapse item = entity.tg_collapse.FirstOrDefault(p => p.id == id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}