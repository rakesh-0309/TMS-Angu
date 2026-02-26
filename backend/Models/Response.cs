using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;

namespace TMS.Models
{
    public class Response
    {
        public class Delres
        {
            public int Task_Id { get; set; }
        }

        public class RegRes
        {
            //public int Task_Id;
            //public int Task_Id { get; set; }

            public string? Task_Title { get; set; }
            public string? Task_Discription { get; set; }
            public DateTime? DueDate { get; set; }
            public string? Status { get; set; }
            public string remark { get; set; }
            public DateTime? CreatedOn { get; set; }
            public DateTime LastUpdatedDate { get; set; }
            public string? CreatedBy { get; set; }
            public string? LastUpdatedBy { get; set; }

        }

        public class getrecres
        {
            public int Task_Id { get; set; }
        }

        public class UpdateRes
        {
            public int ? Task_Id { get; set; }

            public string ? Task_Title { get; set; }
            public string?  Task_Discription { get; set; }
            public  DateTime? DueDate { get; set; }
            public string? Status { get; set; }
            public string ?Remark { get; set; }
            public DateTime?  CreatedOn { get; set; }
            public DateTime ?LastUpdatedDate { get; set; }
            public string ?CreatedBy { get; set; }
            public string ? LastUpdatedBy { get; set; }
        }
    }
}
