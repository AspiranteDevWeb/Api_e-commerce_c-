using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController : BaseApiController
{
    private readonly StoreContext _context;
    
    public BuggyController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet("notfound")]

    public ActionResult GetNotFoundRequest()
    {
        var thing = _context.Products.Find();

        if (thing == null)
        {
            return NotFount(new ApiResponse(404));
        }

        return OK();
    }
    
    [HttpGet("servererror")]

    public ActionResult GetServerError()
    {
        var thing = _context.Products.Find();

        var thingToReturn = thing.ToString();

        return OK();
    }
    
    [HttpGet("badrequest")]

    public ActionResult GetBadRequest()
    {
        return Badrequest(new ApiResponse(400));
    }
    
    
    [HttpGet("badrequest/{id}")]

    public ActionResult GetNotFoundRequest(int id)
    {
        return OK();
    }
}