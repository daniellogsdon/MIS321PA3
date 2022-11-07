using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.Models;
using api.Models.Interfaces;




namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class driversController : ControllerBase
    {
        // GET: api/drivers
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Driver> Get()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Read");
            Console.ForegroundColor = ConsoleColor.White;
            ReadDriverData dataAccess = new ReadDriverData();
            return dataAccess.GetAllDrivers();
          
        }

        // GET: api/drivers/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Driver Get(int id)
        {
            IGetDriver dataAccess = new ReadDriverData();
            return dataAccess.GetDriver(id);
        }

        // POST: api/drivers
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Driver value)
        {
            IInsertDriver insertObject = new SaveDriver();
            insertObject.InsertDriver(value);
        }

        // PUT: api/drivers/5
        [EnableCors("OpenPolicy")]
        [HttpPut]
        public void Put([FromBody] Driver value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EDIT");
            Console.ForegroundColor = ConsoleColor.White;
            IEditDriver editObject = new EditDriver();
            editObject.EditTheDriver(value);

        }

        // DELETE: api/drivers/5
        [EnableCors("OpenPolicy")]
        [HttpDelete]
        public void Delete([FromBody] Driver value)
        {
            IDeleteDriver deleteObject = new DeleteDriver();
            deleteObject.DeleteTheDriver(value);
        }
    }


}
