namespace EntityLayer
{
    public class clsEntityCircle
    {
        public int CircleID { get; set; } = -1;
        public string CircleName { get; set; } = string.Empty;
        public int TeacherID { get; set; } = -1;
        public byte MaxCapacity { get; set; } = 0;
        public byte CurrentStudentNumbers { get; set; } = 0;
        public bool CannAdded { get => MaxCapacity > CurrentStudentNumbers; }

    }
}