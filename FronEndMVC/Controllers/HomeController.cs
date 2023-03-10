using FronEndMVC.Contracts;
using FronEndMVC.Models;
using FronEndMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace FronEndMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        HttpClient client = new HttpClient();
        private readonly IHelperService _helper;
        public HomeController(ILogger<HomeController> logger, IConfiguration config,IHelperService helper)
        {
            _logger = logger;
            _config = config;
            _helper = helper;
        }

        #region Student

        public async Task<IActionResult> Student()
        {

            string apiUrl = HelperService.ApiRoot + HelperService.GetAllStudentUrl;
            var response = await client.GetAsync(apiUrl);
            var result = response.Content.ReadFromJsonAsync<List<Student>>().Result;
            ViewBag.Students = result;
            return View();
        }
        public async Task<IActionResult> EditStudent(string id, string name)
        {

            Student student = new Student();
            student.Id = id;
            student.Name = name;
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            var serializedStudent = JsonConvert.SerializeObject(student);
            var requestContent = new StringContent(serializedStudent, Encoding.UTF8, "application/json");
            string apiUrl = HelperService.ApiRoot + HelperService.EditStudentUrl;
            var response = await client.PostAsync(apiUrl, requestContent);

            var result = response.Content.ReadFromJsonAsync<List<Student>>().Result;
            ViewBag.Students = result;

            return RedirectToAction("Student");
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {

            var serializedStudent = JsonConvert.SerializeObject(student);
            var requestContent = new StringContent(serializedStudent, Encoding.UTF8, "application/json");
            string apiUrl = HelperService.ApiRoot + HelperService.AddStudentUrl;
            var response = await client.PostAsync(apiUrl, requestContent);

            var result = response.Content.ReadFromJsonAsync<List<Student>>().Result;
            ViewBag.Students = result;
            return RedirectToAction("Student");
        }



        #endregion

        #region Course
        public async Task<IActionResult> Course()
        {
            string apiUrl = HelperService.ApiRoot + HelperService.GetAllCourseUrl;
            var response = await client.GetAsync(apiUrl);
            var result = response.Content.ReadFromJsonAsync<List<Course>>().Result;
            ViewBag.Courses = result;
            return View();
        }
        public async Task<IActionResult> EditCourse(string id, string name)
        {

            Course Course = new Course();
            Course.Id = id;
            Course.Name = name;
            return View(Course);
        }
        [HttpPost]
        public async Task<IActionResult> EditCourse(Course Course)
        {
            var serializedCourse = JsonConvert.SerializeObject(Course);
            var requestContent = new StringContent(serializedCourse, Encoding.UTF8, "application/json");
            string apiUrl = HelperService.ApiRoot + HelperService.EditCourseUrl;
            var response = await client.PostAsync(apiUrl, requestContent);

            var result = response.Content.ReadFromJsonAsync<List<Course>>().Result;
            ViewBag.Courses = result;

            return RedirectToAction("Course");
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course Course)
        {

            var serializedCourse = JsonConvert.SerializeObject(Course);
            var requestContent = new StringContent(serializedCourse, Encoding.UTF8, "application/json");
            string apiUrl = HelperService.ApiRoot + HelperService.AddCourseUrl;
            var response = await client.PostAsync(apiUrl, requestContent);

            var result = response.Content.ReadFromJsonAsync<List<Course>>().Result;
            ViewBag.Courses = result;
            return RedirectToAction("Course");
        }


        #endregion


        #region Mark
        public async Task<IActionResult> Marks()
        {

            // COURSE  LIST + STUDENT LIST
            string apiUrl = HelperService.ApiRoot + HelperService.DropDownDataUrl;
            var response = await client.GetAsync(apiUrl);
            var result = response.Content.ReadFromJsonAsync<MarkApiModelPage>().Result;
            ViewBag.AllStudent = GetStudentDropDownList(result?.AllStudent);
            ViewBag.AllCourse = GetCourseDropDownList(result?.AllCourse);




            ///  MARK SHEET
            string apiUrlMarkSheet = HelperService.ApiRoot + HelperService.GetMarkSheetUrl;
            var markSheet = await client.GetAsync(apiUrlMarkSheet);
            var resultMarksheet = markSheet.Content.ReadFromJsonAsync<List<MarkSheetApiModel>>().Result;


            ViewBag.MarkSheet = resultMarksheet.ToList();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMark(MarkVM mark)
        {
            Mark markPost = GetMark(mark);

            var serializedMark = JsonConvert.SerializeObject(mark);
            var requestContent = new StringContent(serializedMark, Encoding.UTF8, "application/json");
            string apiUrl = HelperService.ApiRoot + HelperService.AddMarkUrl;
            var response = await client.PostAsync(apiUrl, requestContent);
            return RedirectToAction("Marks");
        }
        Mark GetMark(MarkVM Mark)
        {
            return new Mark
            {
                Course = new Course
                {
                    Id = Mark.CourseId
                },
                Student = new Student
                {
                    Id = Mark.StudentId
                },
                Mark1 = Mark.Mark1
            };
        }


        List<SelectListItem> GetCourseDropDownList(List<Course> list)
        {
            List<SelectListItem> listCourse = new List<SelectListItem>();
            foreach (var item in list)
            {
                SelectListItem itemDD = new SelectListItem();
                itemDD.Text = item.Name;
                itemDD.Value = item.Id;
                listCourse.Add(itemDD);
            }
            return listCourse;
        }
        List<SelectListItem> GetStudentDropDownList(List<Student> list)
        {
            List<SelectListItem> listCourse = new List<SelectListItem>();
            foreach (var item in list)
            {
                SelectListItem itemDD = new SelectListItem();
                itemDD.Text = item.Name;
                itemDD.Value = item.Id;
                listCourse.Add(itemDD);
            }
            return listCourse;
        }


        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}