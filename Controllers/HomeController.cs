using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OKVGU.Models;
using OKVGU.Services;
using OKVGU.Repositories;
using System.Data.Entity;


namespace OKVGU.Controllers
{
    public class HomeController : Controller
    {
        private IInputRepository inputRepository = new InputRepository();
        private IInputService inputService;

        public HomeController()
        {
            inputService = new InputService(inputRepository);
        }
        public ActionResult Index()
        {
            SelectList semesters = new SelectList(inputService.GetSemesterTotals(), "id", "Title");
            ViewData["Semesters"] = semesters;
            return View();
        }
        
        [Authorize]
        public ActionResult TeacherInfo()
        {
            IEnumerable<Teacher> teachers = inputService.GetTeachers();
            ViewBag.Section = "Teacher";
            return View(teachers);
        }

        [HttpGet]
        public ActionResult ModalTeacher()
        {
            return PartialView("ModalTeacher");
        }
        [HttpGet]
        public ActionResult ModalEditTeacher(int id)
        {
            Teacher teacher = inputService.GetTeacher(id);
            return PartialView("ModalTeacher", teacher);
        }

        public RedirectResult AddTeacher(Teacher teacher)
        {
            if (teacher.id != 0)
            {
                if (inputService.EditTeacher(teacher))
                {
                    return Redirect("TeacherInfo");
                }
                else { return Redirect("TeacherInfo"); }
            }
            else
            {
                if (inputService.AddTeacher(teacher))
                {
                    return Redirect("TeacherInfo");
                }
                else { return Redirect("TeacherInfo"); }
            }
        }
        [Authorize]
        public ActionResult GroupInfo()
        {
            IEnumerable<GroupTotal> groups = inputService.GetGroupTotals();
            ViewBag.Section = "Group";
            return View(groups);
        }
        public ActionResult ModalGroup()
        {
            ViewBag.Specialties = inputService.GetSpecialties();
            return PartialView("ModalGroup");
        }
        [HttpGet]
        public ActionResult ModalEditGroup(int id)
        {
            ViewBag.Specialties = inputService.GetSpecialties();
            Group group = inputService.GetGroup(id);
            return PartialView("ModalGroup", group);
        }
        public RedirectResult AddGroup(Group group)
        {
            if (group.id != 0)
            {
                if (inputService.EditGroup(group))
                {
                    return Redirect("GroupInfo");
                }
                else return Redirect("GroupInfo");
            }
            else
            {
                if (inputService.AddGroup(group))
                {
                    return Redirect("GroupInfo");
                }
                else return Redirect("GroupInfo");
            }
        }
        [Authorize]
        public ActionResult SpecInfo()
        {
            List<Specialty> specialties = inputService.GetSpecialties();
            ViewBag.Section = "Specialty";
            return View(specialties);
        }
        public ActionResult ModalSpecialty()
        {
            return PartialView("ModalSpec");
        }
        public ActionResult ModalEditSpecialty(int id)
        {
            Specialty specialty = inputService.GetSpecialty(id);
            return PartialView("ModalSpec", specialty);
        }
        public RedirectResult AddSpecialty(Specialty specialty)
        {
            if (specialty.id != 0)
            {
                if (inputService.EditSpecialty(specialty))
                {
                    return Redirect("SpecInfo");
                }
                else return Redirect("SpecInfo");
            }
            else
            {
                if (inputService.AddSpecialty(specialty))
                {
                    return Redirect("SpecInfo");
                }
                else return Redirect("SpecInfo");
            }
            

        }
        [Authorize]
        public ActionResult SubjectInfo()
        {
            OkContext cxt = new OkContext();
            cxt.Subjects.Load();
            ViewBag.Section = "Subject";
           
            return View(cxt.Subjects);
        }
        public ActionResult ModalSubject()
        {
            return PartialView("ModalSubject");
        }
        public ActionResult ModalEditSubject(int id)
        {
            Subject subject = inputService.GetSubject(id);
            return PartialView("ModalSubject", subject);
        }

        [HttpPost]
        public RedirectResult AddSubject(Subject subject)
        {
            if (subject.id != 0) 
            {
                if (inputService.EditSubject(subject))
                {
                    return Redirect("SubjectInfo");
                }
                else return Redirect("SubjectInfo");
            }
            else
            {
                if (inputService.AddSubject(subject))
                {
                    return Redirect("SubjectInfo");
                }
                else return Redirect("SubjectInfo");
            }
        }
        [HttpPost]
        public JsonResult DropTeacher(int id)
        {
            if (inputService.DropTeacher(id))
            {
                return Json(true);
            }
            return Json(false);
        }
        [HttpPost]
        public JsonResult DropGroup(int id)
        {
            if (inputService.DropGroup(id))
            {
                return Json(true);
            }
            return Json(false);
        }
        [HttpPost]
        public JsonResult DropSubject(int id)
        {
            if (inputService.DropSubject(id))
            {
                return Json(true);
            }
            return Json(false);
        }
        [HttpPost]
        public JsonResult DropSpecialty(int id)
        {
            if (inputService.DropSpecialty(id))
            {
                return Json(true);
            }
            return Json(false);
        }
        [Authorize]
        public ActionResult SemesterInfo()
        {
            ViewBag.Section = "SubjectSemester";
            SelectList groups = new SelectList(inputService.GetSimpleGroups(), "id", "Title");
            ViewData["Groups"] = groups;
            SelectList semesters = new SelectList(inputService.GetSemesterTotals(), "id", "Title");
            ViewData["Semesters"] = semesters;
            return View();
        }
        [HttpPost]
        public ActionResult LoadTableForSemesters(int GroupId, int SemesterId)
        {
            IEnumerable<SubjectSemesterTotal> subjectSemesterTotals = inputService.GetSubSemTotalsFor(GroupId, SemesterId);
            return PartialView("SemesterTable", subjectSemesterTotals);
        }
        [HttpGet]
        public ActionResult ModalSubjectSemester()
        {
            ViewBag.Groups = inputService.GetGroups();
            ViewBag.Semesters = inputService.GetSemesterTotals();
            ViewBag.Subjects = inputService.GetSubjects();
            ViewBag.Teachers = inputService.GetTeacherTotals();
            return PartialView("ModalSubjectSemester");
        }
        public ActionResult ModalEditSubjectSemester(int id)
        {
            ViewBag.Groups = inputService.GetGroups();
            ViewBag.Semesters = inputService.GetSemesterTotals();
            ViewBag.Subjects = inputService.GetSubjects();
            ViewBag.Teachers = inputService.GetTeacherTotals();
            SubjectSemester subjectSemester = inputService.GetSubjectSemester(id);
            return PartialView("ModalSubjectSemester", subjectSemester);
        }
        [HttpPost]
        public ActionResult AddSubjectSemester(SubjectSemester subjectSemester)
        {
            if (subjectSemester.id != 0)
            {
                if (inputService.EditSubjectSemester(subjectSemester))
                {
                    IEnumerable<SubjectSemesterTotal> subjectSemesterTotals = inputService.GetSubSemTotalsFor(subjectSemester.GroupId, subjectSemester.SemesterId);
                    return PartialView("SemesterTable", subjectSemesterTotals);
                }
                else
                {
                    IEnumerable<SubjectSemesterTotal> subjectSemesterTotals = inputService.GetSubSemTotalsFor(subjectSemester.GroupId, subjectSemester.SemesterId);
                    return PartialView("SemesterTable", subjectSemesterTotals);
                }
            }
            else
            {
                if (inputService.AddSubjectSemester(subjectSemester))
                {
                    IEnumerable<SubjectSemesterTotal> subjectSemesterTotals = inputService.GetSubSemTotalsFor(subjectSemester.GroupId, subjectSemester.SemesterId);
                    return PartialView("SemesterTable", subjectSemesterTotals);
                }
                else
                {
                    IEnumerable<SubjectSemesterTotal> subjectSemesterTotals = inputService.GetSubSemTotalsFor(subjectSemester.GroupId, subjectSemester.SemesterId);
                    return PartialView("SemesterTable", subjectSemesterTotals);
                }
            
            }
        }
        [HttpPost]
        public JsonResult DropSubjectSemester(int id)
        {
            if (inputService.DropSubjectSemester(id))
            {
                return Json(true);
            }
            return Json(false);
        }
        public ActionResult ModalSemester()
        {
            return PartialView("ModalSemester");
        }
        public ActionResult ModalEditSemester(int id)
        {
            Semester semester = inputService.GetSemester(id);
            return PartialView("ModalSemester", semester);
        }
        [HttpPost]
        public ActionResult AddSemester(Semester semester)
        {
            if (semester.id != 0)
            {
                if (inputService.EditSemester(semester))
                {
                    ViewData["Semesters"] = new SelectList(inputService.GetSemesters(), "id", "Year");
                    return PartialView("SemesterDropDown");
                }
                else return PartialView("SemesterDropDown");
            }
            else
            {
                if (inputService.AddSemester(semester))
                {
                    ViewData["Semesters"] = new SelectList(inputService.GetSemesters(), "id", "Year");
                    return PartialView("SemesterDropDown");
                }
                else return PartialView("SemesterDropDown");
            }
        }
        [HttpPost]
        public JsonResult DropSemester(int id)
        {
            if (inputService.DropSemester(id))
            {
                return Json(true);
            }
            return Json(false);
        }
        [HttpPost]
        public ActionResult ModalNumberOfWeeks (int groupId, int semesterId)
        {
            GroupSemester groupSemester = inputService.GetGroupSemester(groupId, semesterId);
            return PartialView("ModalNumOfWeeks", groupSemester);
        }

        [HttpPost]
        public ActionResult AddNumberOfWeeks(GroupSemester groupSemester)
        {
            if (groupSemester.id == 0)
            {
                if (inputService.AddGroupSemester(groupSemester))
                {
                    return PartialView("NumberOfWeeks", inputService.GetGroupSemester(groupSemester.GroupId, groupSemester.SemesterId));
                }
            }
            else
            {
                if (inputService.EditGroupSemester(groupSemester))
                {
                    return PartialView("NumberOfWeeks", inputService.GetGroupSemester(groupSemester.GroupId, groupSemester.SemesterId));
                }
            }
            return PartialView("NumberOfWeeks", inputService.GetGroupSemester(groupSemester.GroupId, groupSemester.SemesterId));
        }
        [HttpPost]
        public ActionResult LoadNumberOfWeeks(int GroupId, int SemesterId)
        {
            GroupSemester groupSemester = inputService.GetGroupSemester(GroupId, SemesterId);
            if (groupSemester != null)
            {
                return PartialView("NumberOfWeeks", groupSemester);
            } else
            {
                groupSemester = new GroupSemester { GroupId = GroupId, SemesterId = SemesterId, NumberOfWeeks = 0};
                return AddNumberOfWeeks(groupSemester);
            }

        }
        public ActionResult Info()
        {
            return View();
        }
    }
}