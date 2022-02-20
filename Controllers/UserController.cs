using DentalDDS_Api.Common;
using DentalDDS_Api.DataAccess;
using DentalDDS_Api.DataAccess.Interface;
using DentalDDS_Api.DataAccess.Repository;
using DentalDDS_Api.DbContext;
using DentalDDS_Api.Models;
using DentalDDS_Api.BindingModels;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DentalDDS_Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : BaseApiController
    {
        private Log _lg = null;
        private UnitOfWork unitOfWork = new UnitOfWork();

        private ITasksRepository _tasksRepository;
        private IUserProfileRepository _userprofileRepository;


        public UserController()
        {
            _tasksRepository = new TasksRepository(new ApplicationDbContext());
            _userprofileRepository = new UserProfileRepository(new ApplicationDbContext());
        }


        /// <summary>      
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSelectedTaskByID")]
        public IHttpActionResult GetSelectedTaskByID(long taskID)
        {
            if (taskID <= 0)
            {
                return Content(HttpStatusCode.NotFound, "Missing taskID.");
            }
            try
            {
                var task = _tasksRepository.GetSelectedTaskByTaskID(taskID);
                if (task != null)
                {
                    return Ok(task);
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, "Please contact support.");
            }
        }

        /// <summary>      
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTasksListByUser")]
        public IHttpActionResult GetTasksListByUser(string UserName)
        {
            if (String.IsNullOrEmpty(UserName))
            {
                return Content(HttpStatusCode.NotFound, "Missing userID.");
            }
            try
            { 
                var task = _tasksRepository.GetTasksListByUserName(UserName);
                if (task != null)
                {                  
                    return Ok(task);
                }
                else
                {                  
                    return StatusCode(HttpStatusCode.NoContent);
                }

            }
            catch (Exception ex)
            {
                //await _lg.LogErrorAsync(userID.ToString(), ex.Message, ex.Source, ex.InnerException.ToString(), "GetTasksListByUser");
                return Content(HttpStatusCode.NotFound, "Please contact support.");
            }
        }

        /// <summary>      
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostNewTask")]
        public async Task<IHttpActionResult> PostNewTask(TasksBM model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            var tasks = new Tasks
            {
                TaskName = model.TaskName,
                TaskDetail = model.TaskDetail,
                TaskDateTime = model.TaskDateTime,
                UserName = model.UserName,
                Created = DateTime.Now

            };
            if (tasks == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            try
            {
                var InsertedID = unitOfWork.TasksRepository.Insert(tasks);
                await unitOfWork.SaveAsync();
                var nReturnID = InsertedID.TasksID;
                if (nReturnID > 0)
                {
                    return Content(HttpStatusCode.Created, tasks);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, "Please contact support.");
            }

            return Content(HttpStatusCode.NotFound, "Invalid model.");

        }

        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateTasks")]
        public async Task<IHttpActionResult> UpdateTasks(UpdateTasksBM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tk = _tasksRepository.GetSelectedTaskByTaskID(model.TasksID);
                    if (tk == null)
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }                    
                    tk.TasksID = model.TasksID;
                    tk.TaskName = model.TaskName;
                    tk.TaskDetail = model.TaskDetail;
                    tk.TaskDateTime = model.TaskDateTime;
                    tk.UserName = model.UserName;
                    tk.Created = DateTime.Now;

                    await unitOfWork.TasksRepository.UpdateAsync(tk);
                    await unitOfWork.SaveAsync();

                    return Content(HttpStatusCode.OK, "Task updated.");
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.NotFound, "Please contact support.");
                }
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Invalid model.");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteSelectedTask")]
        public async Task<IHttpActionResult> DeleteSelectedTask(long taskID)
        {
            if (taskID <= 0)
            {
                return Content(HttpStatusCode.NotFound, "Missing taskID.");
            }
            try
            {
                var tk = _tasksRepository.GetSelectedTaskByTaskID(taskID);
                if (tk == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }

                unitOfWork.TasksRepository.Delete(tk);
                await unitOfWork.SaveAsync();
                return Content(HttpStatusCode.Accepted, "Task Removed.");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, "Please contact support.");
            }
        }
    }
}