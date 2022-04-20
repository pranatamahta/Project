using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitCrudController : ControllerBase
    {
        private string queueName { get; set; } = "qtest1";

        [HttpPost("tambahdata")]
        public Response tambahData([FromBody] Request req)
        {
            Response r = new Response();
            List<Test01> data = new List<Test01>();
            //string queueName = "qtest1";
            ConnectionFactory factory = new ConnectionFactory();
            // "guest"/"guest" by default, limited to localhost connections
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = "localhost";
            factory.Port = 5672;

            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );
            //var req = new
            //{
            //    command = "create",
            //    data = new Test01
            //    {
            //        Nama = "Mahta Rabbbit MQ",
            //        Status = 1
            //    }
            //};

            data.Add(req.data);
            var payload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req));
            channel.BasicPublish("",queueName,null,payload);
            r.message = "Sukses";
            r.data = data;
            return r;
        }
        [HttpPut("editdata")]
        public Response editData([FromBody] Request req)
        {
            Response r = new Response();
            List<Test01> data = new List<Test01>();
            //string queueName = "qtest1";
            ConnectionFactory factory = new ConnectionFactory();
            // "guest"/"guest" by default, limited to localhost connections
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = "localhost";
            factory.Port = 5672;

            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );
            //var req = new
            //{
            //    command = "update",
            //    data = new Test01
            //    {
            //        id=9,
            //        Nama = "Mahta Rabbbit MQ Edit",
            //        Status = 1
            //    }
            //};

            data.Add(req.data);
            var payload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req));
            channel.BasicPublish("", queueName, null, payload);
            r.message = "Sukses";
            r.data = data;
            return r;
        }
        [HttpDelete("deletedata")]
        public Response deleteData([FromBody] Request req)
        {
            Response r = new Response();
            List<Test01> data = new List<Test01>();
            //string queueName = "qtest1";
            ConnectionFactory factory = new ConnectionFactory();
            // "guest"/"guest" by default, limited to localhost connections
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = "localhost";
            factory.Port = 5672;

            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );
            //var req = new
            //{
            //    command = "delete",
            //    data = new Test01
            //    {
            //        id = 9,
            //        Nama = "",
            //        Status = 0
            //    }
            //};

            //Request extractreq = JsonConvert.DeserializeObject<Request>(req);
            data.Add(req.data);
            var payload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req));
            
            channel.BasicPublish("", queueName, null, payload);
            r.message = "Sukses";
            r.data = data;
            return r;
        }
    }
}