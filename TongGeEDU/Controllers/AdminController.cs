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
        public ActionResult CourseAddEditView(int id)
        {
            return View();
        }
        public ActionResult CourseSourceView(int parentid)
        {
            return View();
        }
        public ActionResult VideoFrame(string src, string poster)
        {
            ViewBag.src = src;
            ViewBag.poster = poster;
            return View();
        }
        public ActionResult Course_Add(string grade, string subject, string title, string teacher, double price, string introduction)
        {
            HttpPostedFileBase file = Request.Files[0];
            string filename = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            file.SaveAs(HttpContext.Server.MapPath("~/Attachments/course") + "\\" + filename);
            tg_course course = new tg_course()
            {
                grade = grade,
                subject = subject,
                title = title,
                teacher = teacher,
                filename = filename,
                price = price,
                introduction = introduction,
            };
            entity.tg_course.Add(course);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Course_Delete(int id)
        {
            tg_course item = entity.tg_course.FirstOrDefault(p => p.id == id);
            entity.tg_course.Remove(item);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Course_Edit(int id, string grade, string subject, string title, string teacher, double price, string introduction)
        {
            tg_course item = entity.tg_course.FirstOrDefault(p => p.id == id);
            if (Request.Files.Count != 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                string filename = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
                file.SaveAs(HttpContext.Server.MapPath("~/Attachments/course") + "\\" + filename);
                item.filename = filename;
            }
            item.grade = grade;
            item.subject = subject;
            item.title = title;
            item.teacher = teacher;
            item.price = price;
            item.introduction = introduction;
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Course_Query(string grade, string subject)
        {
            IEnumerable<tg_course> list = entity.tg_course;
            if (!grade.Equals("全部"))
            {
                list = list.Where(p => p.grade == grade);
            }
            if (!subject.Equals("全部"))
            {
                list = list.Where(p => p.subject == subject);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Course_Query_Item(int id)
        {
            var list = entity.tg_course.FirstOrDefault(p => p.id == id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Add(int parentid, int chapter, string title)
        {
            HttpPostedFileBase file = Request.Files[0];
            string filename = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            file.SaveAs(HttpContext.Server.MapPath("~/Attachments/course") + "\\" + filename);
            tg_course_source course_source = new tg_course_source()
            {
                chapter = chapter,
                parentid = parentid,
                title = title,
                filename = filename,
            };
            entity.tg_course_source.Add(course_source);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Delete(int id)
        {
            tg_course_source item = entity.tg_course_source.FirstOrDefault(p => p.id == id);
            entity.tg_course_source.Remove(item);
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Edit(int id, int chapter, string title)
        {
            tg_course_source item = entity.tg_course_source.FirstOrDefault(p => p.id == id);
            item.chapter = chapter;
            item.title = title;
            return Json(entity.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Query(int parentid)
        {
            var list = entity.tg_course_source.Where(p => p.parentid == parentid).OrderBy(p => p.chapter);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CourseSource_Query_Item(int id)
        {
            tg_course_source item = entity.tg_course_source.FirstOrDefault(p => p.id == id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}