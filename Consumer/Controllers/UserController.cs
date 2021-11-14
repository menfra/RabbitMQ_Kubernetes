using DataAccess;
using DataAccess.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Gets all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<User>> Get()
        {
            try
            {
                return await DataServices.GetInstance.GetAllData<User>("");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Get a user by Id
        /// </summary>
        /// <param name="id">The submitted user id</param>
        /// <returns>returns action result</returns>
        [HttpGet("{Id}")]
        public async Task<User> GetById(Guid id)
        {
            try
            {
                return await DataServices.GetInstance.GetDataByID<User>("", id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user">The submitted user details</param>
        /// <returns>returns action result</returns>
        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                return Created("User created succesfully", await DataServices.GetInstance.AddData("", user));
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="user">The submitted user details</param>
        /// <returns>returns action result</returns>
        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                return Created("User updated succesfully", await DataServices.GetInstance.UpdateData("", user));
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="user">The submitted user details</param>
        /// <returns>returns action result</returns>
        [HttpDelete("deleteuser")]
        public async Task DeleteUser(Guid id)
        {
            try
            {
                var IsDeleted = await DataServices.GetInstance.DeleteData<User>("", id);
                if (IsDeleted)
                    Ok();
                else
                    NotFound();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
