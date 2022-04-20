using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class CrudController : ControllerBase
    {
        public string con { get; set; } = "server=localhost;user=root;database=mysql;port=3306;password=sprint1234";

        [HttpGet("byid/{id}")]
        public Response ById(string id)
        {
            Response r = new Response();
            List<Test01> rt01 = new List<Test01>();
            Test01 tt = new Test01();
            using (MySqlConnection conn = new MySqlConnection(this.con))
            {
                conn.Open();
                string sqlQueue = "SELECT * from Test01 where id=" + id + " ";

                MySqlCommand cmdQueue = new MySqlCommand(sqlQueue, conn);
                cmdQueue.CommandTimeout = 3600;
                MySqlDataReader rdrQueue = cmdQueue.ExecuteReader();
                if (rdrQueue.HasRows)
                {
                    while (rdrQueue.Read())
                    {
                        tt.id = Convert.ToInt32(rdrQueue["ID"]);
                        tt.Nama = rdrQueue["Nama"].ToString();
                        tt.Status = Convert.ToInt32(rdrQueue["Status"]);
                        tt.Created = Convert.ToDateTime(rdrQueue["Created"]);
                        tt.Updated = Convert.ToDateTime(rdrQueue["Updated"]);
                        rt01.Add(tt);
                    }
                    r.message = "sukses";
                    r.data = rt01;
                }
                else
                {
                    r.message = "Data No Rows";
                    r.data = rt01;
                }

                conn.Close();

            }
            return r;
        }

        [HttpGet("listbypage/{page}/{maxrow}")]
        public Response listByPage(int page = 0, int maxrow = 0)
        {
            Response r = new Response();
            List<Test01> rt01 = new List<Test01>();

            using (MySqlConnection conn = new MySqlConnection(this.con))
            {
                if (page == 1)
                    page = 0;
                else
                    page = page - 1;

                conn.Open();
                string sqlQueue = "SELECT * from Test01 limit " + page + "," + maxrow + "";

                MySqlCommand cmdQueue = new MySqlCommand(sqlQueue, conn);
                cmdQueue.CommandTimeout = 3600;
                MySqlDataReader rdrQueue = cmdQueue.ExecuteReader();
                if (rdrQueue.HasRows)
                {
                    while (rdrQueue.Read())
                    {
                        rt01.Add(new Test01
                        {
                            id = Convert.ToInt32(rdrQueue["ID"]),
                            Nama = rdrQueue["Nama"].ToString(),
                            Status = Convert.ToInt32(rdrQueue["Status"]),
                            Created = Convert.ToDateTime(rdrQueue["Created"]),
                            Updated = Convert.ToDateTime(rdrQueue["Updated"])
                        });
                    }
                    r.message = "sukses";
                    r.data = rt01;
                }
                else
                {
                    r.message = "Data No Rows";
                    r.data = rt01;
                }

                conn.Close();

            }
            return r;
        }

        [HttpPost("tambahdata")]
        public Response tambahData([FromBody] Test01 table)
        {
            Response r = new Response();
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection(this.con))
            {
                conn.Open();
                string insert = "insert into Test01 (nama,status) values ('" + table.Nama + "'," + table.Status + ")";

                MySqlCommand cmdQueue = new MySqlCommand(insert, conn);
                cmdQueue.CommandTimeout = 3600;
                result = cmdQueue.ExecuteNonQuery();
                if (result > 0)
                {
                    r.message = "Berhasil Insert";

                }
            }
            return r;
        }
        [HttpPut("editdata")]
        public Response editData([FromBody] Test01 table)
        {
            Response r = new Response();
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection(this.con))
            {
                conn.Open();
                string insert = "update Test01 set nama='" + table.Nama + "',status=" + table.Status + ",updated='" + table.Updated.ToString("yyyy-MM-dd HH:mm:ss") + "' where id=" + table.id + " ";

                MySqlCommand cmdQueue = new MySqlCommand(insert, conn);
                cmdQueue.CommandTimeout = 3600;
                result = cmdQueue.ExecuteNonQuery();
                if (result > 0)
                {
                    r.message = "Berhasil Edit";

                }
            }
            return r;
        }
        [HttpDelete("hapusdata")]
        public Response hapusData([FromBody] int id)
        {
            Response r = new Response();
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection(this.con))
            {
                conn.Open();
                string insert = "delete from Test01 where id=" + id + " ";

                MySqlCommand cmdQueue = new MySqlCommand(insert, conn);
                cmdQueue.CommandTimeout = 3600;
                result = cmdQueue.ExecuteNonQuery();
                if (result > 0)
                {
                    r.message = "Berhasil Hapus Data";

                }
            }
            return r;
        }
    }


}