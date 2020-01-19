using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementMVCLinq.Models;

namespace StudentManagementMVCLinq.Controllers
{
    public class StudentController : Controller
    {
        StudentClassesDataContext dbContext = new StudentClassesDataContext();
        // GET: Student
        public ActionResult Index()
        {
            var query = from student in dbContext.Students
                        select student;
            var studentList = query.ToList();
            return View(studentList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student collection)
        {
            try
            {
                // TODO: Add insert logic here
                dbContext.Students.InsertOnSubmit(collection);
                dbContext.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = dbContext.Students.Single(x => x.studId == id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student collection)
        {
            try
            {
                // TODO: Add update logic here
                var toBeEdited = dbContext.Students.Single(x => x.studId == id);
                toBeEdited.studFirstName = collection.studFirstName;
                toBeEdited.studLastName = collection.studLastName;
                toBeEdited.studYear = collection.studYear;
                dbContext.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = dbContext.Students.Single(x => x.studId == id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student collection)
        {
            try
            {
                // TODO: Add delete logic here
                var toBeDeleted = dbContext.Students.Single(x => x.studId == id);
                dbContext.Students.DeleteOnSubmit(toBeDeleted);
                dbContext.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
