namespace FronEndMVC.Contracts
{
    public interface IHelperService
    {
        public static string ApiRoot {get;set;}=  "";
        public static string DropDownDataUrl {get;set;}=  "";
        public static string GetMarkSheetUrl {get;set;}=  "";
        public static string GetAllStudentUrl {get;set;}=  "";
        public static string EditStudentUrl {get;set;}=  "";
        public static string AddStudentUrl {get;set;}=  "";
        public static string GetAllCourseUrl {get;set;}=  "";
        public static string EditCourseUrl {get;set;}=  "";
        public static string AddCourseUrl {get;set;}=  "";
        public static string AddMarkUrl {get;set;}=  "";


    }
}
