using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]

public class MahasiswaController : ControllerBase
{
    private readonly DbManager _dbManager;

    Response response = new Response();

    public MahasiswaController(IConfiguration configuration)
    {
        _dbManager = new DbManager(configuration);
    }


    [HttpGet]
    [Route("GetAllMahasiswa")]
    public IActionResult GetMahasiswas()
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetAllMahasiswas();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetMahasiswaById(int id)
    {
        try
        {
            var mahasiswa = _dbManager.GetMahasiswaById(id);
            if (mahasiswa == null)
            {
                response.status = 404;
                response.message = "Mahasiswa not found";
                response.data = null;
            }
            else
            {
                response.status = 200;
                response.message = "Success";
                response.data = mahasiswa;
            }
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    //create
    [HttpPost]
    [Route("InsertMahasiswa")]

    public IActionResult CreateMahasiswa([FromBody] Mahasiswa mahasiswa)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.CreateMahasiswa(mahasiswa);
        }
        catch (Exception ex)
        {
            
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }


    //update 
    [HttpPut("{id}")]

    public IActionResult UpdateMahasiswa(int id, [FromBody] Mahasiswa mahasiswa)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.UpdateMahasiswa(id, mahasiswa);
        }
        catch (Exception ex)
        {
            
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }


    //delete 
    [HttpDelete("{id}")]

    public IActionResult DeleteMahasiswa(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.DeleteMahasiswa(id);
        }
        catch (Exception ex)
        {
            
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }



}