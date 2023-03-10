namespace FronEndMVC.Models
{

    public class MarkVM
    {
        public string Id { get; set; } = "bb";
        public string StudentId { get; set; } = null!;
        public string CourseId { get; set; } = null!;
        public int Mark1 { get; set; }
    }
    public class Mark
    {
        public string Id { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
        public int Mark1 { get; set; }
    }

    public class MarkApiModelVm
    {
        public string Id { get; set; } = null!;
        public string StudentId { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string CourseId { get; set; } = null!;
        public int Mark1 { get; set; }
    }
    public class MarkApiModelPage
    {
        public List<MarkApiModelVm> AllMark { get; set; }
        public List<Student> AllStudent { get; set; }
        public List<Course> AllCourse { get; set; }
    }

    public class MarkSheetApiModel
    {
        public string StudentName { get; set; }

        public List<string> Courses { get; set; }
        public int MaxMark { get; set; }

        public int AverageMark { get; set; }

    }



}
