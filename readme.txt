1.api untuk crud Task 1
  - untuk api 
	-GET by Id : url api/Crud/byid/{id} 
	-GET list by page (dibatasi 1 page 20 data) : url listbypage/1/{page}/{maxrow}
	-POST tambah data : url api/Crud/tambahdata 
         sample json 
          {
		"Nama": "Ini Budi",
		"Status": 1
		}
	-PUT edit data : url api/Crud/editdata
	sample json
	{	"id":1,
		"Nama": "Ini Budi",
		"Status": 1
	}
	-DELETE hapus data : url api/Crud/hapusdata
	sample json : 3(id yang akan di delete)

2. api untuk crud rabbitmq Task 3
 - untuk api 
  -POST tambah data. kirim message command: create ke rabbitmq queue qtest1 (task 2) : url api/RabbitCrud/tambahdata
   json
   {
	"command": "create",
	"data":{
	
		"Nama": "Ini Budi tambah",
		"Status": 1
		}
   }
  -PUT edit data. kirim message command: update ke rabbitmq queue qtest1 (task 2) : url api/RabbitCrud/editdata
	json   
	{
          "command": "update",
             "data":{
	     "id":13,
	     "Nama": "Ini Budi editss",
	     "Status": 1
	 }
       }
  -DELETE hapus data. kirim message command: delete ke rabbitmq queue qtest1 (task 2 : url api/RabbitCrud/deletedata
   json
   {
   "command": "delete",
   "data":{
	"id":12,
	"Nama": "Ini Budi editss",
	"Status": 1
	}
    }

