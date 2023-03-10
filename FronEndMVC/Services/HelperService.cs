using FronEndMVC.Contracts;

namespace FronEndMVC.Services
{
    public class HelperService : IHelperService
    {
        public static  string ApiRoot = "";
        public static  string DropDownDataUrl = "";
        public static  string GetMarkSheetUrl = "";
        public static  string GetAllStudentUrl = "";
        public static  string EditStudentUrl = "";
        public static  string AddStudentUrl = "";
        public static  string GetAllCourseUrl = "";
        public static  string EditCourseUrl = "";
        public static  string AddCourseUrl = "";
        public static  string AddMarkUrl = "";
        public readonly  IConfiguration _config;
        public HelperService(IConfiguration config)
        {
            _config = config;
            ApiRoot = _config["ApiRoot"];
            DropDownDataUrl = _config["DropDownData"];
            GetMarkSheetUrl = _config["GetMarkSheet"];
            GetAllStudentUrl = _config["GetAllStudent"];
            EditStudentUrl = _config["EditStudent"];
            AddStudentUrl = _config["AddStudent"];
            GetAllCourseUrl = _config["GetAllCourse"];
            EditCourseUrl = _config["EditCourse"];
            AddCourseUrl = _config["AddCourse"];
            AddMarkUrl = _config["AddMark"];
        }
    }
}
