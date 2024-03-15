using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]/[action]")]
public class ServiceController : ControllerBase
{
    private readonly ITransientService _transientService;
    private readonly IScopedService _scopedService;
    private readonly ISingletonService _singletonService;

    public ServiceController(ITransientService transientService, ISingletonService singletonService, IScopedService scopedService)
    {
         _transientService = transientService; 
        _scopedService = scopedService;
        _singletonService = singletonService;   
    }

    [HttpGet]
    public IActionResult LogTransient()
    {
         _transientService.LogLifetimeEvent("call transient service from controller");
        return Ok();
    }

    [HttpGet]
    public IActionResult LogScoped()
    {
        _scopedService.LogLifetimeEvent("call Scoped service from controller");
        return Ok();
    }

    [HttpGet]
    public IActionResult LogSingleton()
    {
        _singletonService.LogLifetimeEvent("call Singleton service from controller");
        return Ok();
    }
}
