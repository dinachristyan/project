using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]

public class TrainerController : ControllerBase
{
    private readonly DbManager _dbManager;

    Response response = new Response();

    public TrainerController(IConfiguration configuration)
    {
        _dbManager = new DbManager(configuration);
    }


    [HttpGet]
    [Route("GetAllTrainer")]
    public IActionResult GetTrainers()
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetAllTrainers();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
     public IActionResult GetTrainerById(int id)
    {
        try
        {
            var trainer = _dbManager.GetTrainerById(id);
            if (trainer == null)
            {
                response.status = 404;
                response.message = "Trainer not found";
                response.data = null;
            }
            else
            {
                response.status = 200;
                response.message = "Success";
                response.data = trainer;
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
    [Route("InsertTrainer")]

    public IActionResult CreateTrainer([FromBody] Trainer trainer)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.CreateTrainer(trainer);
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

    public IActionResult UpdateTrainer(int id, [FromBody] Trainer trainer)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.UpdateTrainer(id, trainer);
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

    public IActionResult DeleteTrainer(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.DeleteTrainer(id);
        }
        catch (Exception ex)
        {
            
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }



}