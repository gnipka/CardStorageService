using Microsoft.AspNetCore.Mvc;

namespace CardStorageService.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        #region Sevices

        private readonly ILogger<CardController> _logger;

        #endregion

        #region Constructors

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Public Methods

        public IActionResult GetByClientId(string clientId) 
        {
            _logger.LogInformation("GetByClientId ...");
            return Ok();
        }
        #endregion
    }
}
