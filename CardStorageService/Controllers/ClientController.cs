using CardStorageService.Data;
using CardStorageService.Models.Requests;
using CardStorageService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardStorageService.Controllers
{
    public class ClientController : Controller
    {
        #region Services

        private readonly ILogger<ClientController> _logger;
        private readonly IClientRepositoryService _clientRepositoryService;

        #endregion

        #region Constructors

        public ClientController(ILogger<ClientController> logger, IClientRepositoryService clientRepositoryService)
        {
            _logger = logger;
            _clientRepositoryService = clientRepositoryService;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateClientResponse), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody]CreateClientRequest request) 
        {
            try
            {
                var clientId = _clientRepositoryService.Create(new Client
                {
                    Firstname = request.Firstname,
                    Surname= request.Surname,
                    Patronymic = request.Patronymic
                });
                return Ok(new CreateClientResponse
                {
                    ClientId = clientId
                });
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Create client error");
                return Ok(new CreateClientResponse
                {
                    ErrorCode = 912,
                    ErrorMessage = "Create client error"
                });
            }
        }
        #endregion
    }
}
