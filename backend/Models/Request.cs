using Microsoft.AspNetCore.Http.HttpResults;

namespace TMS.Models
{
    public class Request
    {
        public class delreq
        {
            public int Task_Id { get; set; }
        }

        public class Updatereq
        {
            //public int Task_Id;
            public int Task_Id { get; set; }

            public string? Task_Title { get; set; }
            public string? Task_Discription { get; set; }
            public DateTime? DueDate { get; set; }
            public string? Status { get; set; }
            public string? remark { get; set; }
            //public DateTime? CreatedOn { get; set; }
            //public DateTime LastUpdatedDate { get; set; }
            public string? CreatedBy { get; set; }
            public string? LastUpdatedBy { get; set; }

        }

        public class GetRecReq
        {
            public int? Task_Id { get; set; }

            public string? Task_Title { get; set; }
        }

        public class RegReq
        {
            //public int Task_Id { get; set; }

            public string? Task_Title { get; set; }
            public string? Task_Discription { get; set; }
            public DateTime? DueDate { get; set; }
            public string? status { get; set; }
            public string ?remark { get; set; }
            //public DateTime? CreatedOn { get; set; }
            //public DateTime LastUpdatedDate { get; set; }
            public string? CreatedBy { get; set; }
            public string? LastUpdatedBy { get; set; }
        }
    }
}
