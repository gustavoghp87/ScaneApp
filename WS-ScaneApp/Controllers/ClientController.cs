using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WS_ScaneApp.Models;
using WS_ScaneApp.Models.ProjectRequests;
using WS_ScaneApp.Models.ProjectResponses;

namespace WS_ScaneApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            ClientResponse response = new();
            try
            {
                using (ScaneAppContext db = new())
                {
                    var lst = db.Clients.OrderByDescending(x => x.Id).ToList();
                    response.Success = 1;
                    response.Data = lst;
                }
            }
            catch (Exception exc)
            {
                response.ErrorMessage = exc.Message;
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            ClientResponse response = new();
            try
            {
                using (ScaneAppContext db = new())
                {
                    Client client = db.Clients.Find((long)id);
                    if (client == null) response.ErrorMessage = "Client doesn't exist";
                    else
                    {
                        response.Success = 1;
                        response.Data = client;
                    }
                }
            }
            catch (Exception exc)
            {
                response.ErrorMessage = exc.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(ClientRequest request)
        {
            ClientResponse response = new();
            try
            {
                using (ScaneAppContext db = new())
                {
                    Client client = new();
                    client.Name = request.Name;
                    if (request.Phone != null) client.Phone = request.Phone;
                    db.Clients.Add(client);
                    db.SaveChanges();
                    response.Success = 1;
                    response.Data = client;
                }
            }
            catch (Exception exc)
            {
                response.ErrorMessage = exc.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(ClientRequest request)
        {
            ClientResponse response = new();
            try
            {
                using (ScaneAppContext db = new())
                {
                    Client client = db.Clients.Find((long)request.Id);
                    if (request.Name != null) client.Name = request.Name;
                    if (request.Phone != null) client.Phone = request.Phone;

                    db.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    response.Success = 1;
                    response.Data = client;
                }
            }
            catch (Exception exc)
            {
                response.ErrorMessage = exc.Message;
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ClientResponse response = new();
            try
            {
                using (ScaneAppContext db = new())
                {
                    Client client = db.Clients.Find((long)id);
                    if (client == null) {
                        response.ErrorMessage = "Client doesn't exist";
                    }
                    else
                    {
                        db.Clients.Remove(client);
                        db.SaveChanges();
                        response.Success = 1;
                        response.Data = client;
                    }
                }
            }
            catch (Exception exc)
            {
                response.ErrorMessage = exc.Message;
            }
            return Ok(response);
        }
    }
}
