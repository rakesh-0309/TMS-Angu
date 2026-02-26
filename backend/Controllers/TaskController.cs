using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using static TMS.Models.Response;
using static TMS.Models.Request;
namespace TMS.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] regreq)
        //{
        //    try
        //    {
        //        using var db = Connection;
        //        await db.ExecuteAsync("Procedure",
        //            regres,
        //            CommandType: CommandType.StoredProcedure);

        //        return Ok("Task Added!!");
        //    }
        //    catch (Exception ex) {
        //        {
        //            return BadRequest("DB error");
        //        }
        //    }


        //}

        [HttpPost("listOfTask")]
        public async Task<IActionResult> listOfTask([FromBody] GetRecReq request)
        {
            try
            {
                using var db = Connection;

                var param = new DynamicParameters();
                param.Add("@Task_Id", request.Task_Id, DbType.Int32);
                param.Add("@Task_Title", string.IsNullOrWhiteSpace(request.Task_Title) ? null : request.Task_Title, DbType.String);
                var res = await db.QueryAsync<UpdateRes>("getTaskList",
                    param,
                    commandType: CommandType.StoredProcedure);

                return Ok(new
                {
                    mssg = "Task list!!",
                    Data = res
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new { error =ex.Message,
                inner = ex.InnerException?.Message});

            }
        }


        

        [HttpPost("UpdateTASK")]
        public async Task<IActionResult> UpdateTASK([FromBody] Updatereq req)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Task_Id", req.Task_Id, DbType.Int32);
                param.Add("@Task_Title", string.IsNullOrWhiteSpace(req.Task_Title) ? null : req.Task_Title, DbType.String);
                param.Add("@Task_Discription", string.IsNullOrWhiteSpace(req.Task_Title) ? null : req.Task_Title, DbType.String);
                param.Add("@DueDate", req.DueDate);
                param.Add("@Status", string.IsNullOrWhiteSpace(req.Status) ? null : req.Status, DbType.String);
                param.Add("@remark", string.IsNullOrWhiteSpace(req.remark) ? null : req.remark, DbType.String);
                param.Add("@CreatedBy", string.IsNullOrWhiteSpace(req.CreatedBy) ? null : req.CreatedBy, DbType.String);
                param.Add("@LastUpdatedBy", string.IsNullOrWhiteSpace(req.LastUpdatedBy) ? null : req.LastUpdatedBy, DbType.String);





                using var db = Connection;
                var res=await db.QueryAsync<UpdateRes>("updateTaskList",
                    param,
                    commandType: CommandType.StoredProcedure);

                return Ok(new {mssg= "Task Updated!!",
                    Data=res });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }


        }


        [HttpPost("registerTASK")]
        public async Task<IActionResult> registerTASK([FromBody] RegReq req)
        {
            try
            {
                var param = new DynamicParameters();
                //param.Add("@Task_Id", req.Task_Id, DbType.Int32);
                param.Add("@Task_Title", string.IsNullOrWhiteSpace(req.Task_Title) ? null : req.Task_Title, DbType.String);
                param.Add("@Task_Discription", string.IsNullOrWhiteSpace(req.Task_Discription) ? null : req.Task_Discription, DbType.String);
                param.Add("@DueDate", req.DueDate, DbType.DateTime);
                param.Add("@status", string.IsNullOrWhiteSpace(req.status) ? null : req.status, DbType.String);
                param.Add("@remark", string.IsNullOrWhiteSpace(req.remark) ? null : req.remark, DbType.String);
                param.Add("@CreatedBy", string.IsNullOrWhiteSpace(req.CreatedBy) ? null : req.CreatedBy, DbType.String);
                param.Add("@LastUpdatedBy", string.IsNullOrWhiteSpace(req.LastUpdatedBy) ? null : req.LastUpdatedBy, DbType.String);





                using var db = Connection;
                var res = await db.ExecuteScalarAsync<int>("createTaskList",
                    param,
                    commandType: CommandType.StoredProcedure);

                return Ok(new
                {
                    mssg = "Task listed!!",
                    Data = res
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }


        }

        [HttpPost("DeleteTASK")]
        public async Task<IActionResult> DeleteTASK(delreq req)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Task_Id", req.Task_Id, DbType.Int32);

                using var db = Connection;
                var res = await db.ExecuteScalarAsync<int>("delTaskList",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (res == null)
                {
                    return BadRequest("dosn't exist");
                }
                else
                {
                    return Ok(new
                    {
                        deta = res,
                        mssg = "record deleted succssfully!"
                    });
                }
            }
            catch(Exception ex)
            {
                return BadRequest("DB error");
            }
        }

    }
}