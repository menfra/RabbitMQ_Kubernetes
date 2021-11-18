using DataAccess.DataModels;
using DataAccess.DataServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                return await MongoDataServices.GetInstance.GetAllData<User>("");
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
        [HttpGet("{id}")]
        public async Task<User> GetById(Guid id)
        {
            try
            {
                return await MongoDataServices.GetInstance.GetDataByID<User>("", id);
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
                MongoDataServices.GetInstance.AddData("", user);
                return Created("User created succesfully", user);
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
                MongoDataServices.GetInstance.UpSertData("", Guid.NewGuid(), user);
                return Created("User updated succesfully", user);
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
        [HttpDelete("deleteuser/{id}")]
        public async Task DeleteUser(Guid id)
        {
            try
            {
                MongoDataServices.GetInstance.DeleteData<User>("", id);
                Ok();

            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
