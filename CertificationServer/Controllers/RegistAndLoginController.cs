using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CertificationServer.Models;
using CertificationServer.Models.Query;
using CertificationServer.Services;
using CertificationServer.Services.RDB;
using CertificationServer.Services.RDB.Query.Postgres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CertificationServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistAndLoginController : ControllerBase
    {
        private readonly ILogger<RegistAndLoginController> _logger;
        private readonly AppSettings _appSettings;
        public RegistAndLoginController(IOptions<AppSettings> optionAccessor)
        {
            _appSettings = optionAccessor.Value;
        }
        public RegistAndLoginController(ILogger<RegistAndLoginController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public ReturnCertEntity PostRegistData(RegistEntity registData)
            => PostgresService.ExecuteAsync(new RegistQuery(), registData, _appSettings.Postgres).Result as ReturnCertEntity;
        [HttpPost]
        public ReturnCertEntity PostLoginData(LoginEntity loginData)
            => PostgresService.ExecuteAsync(new LoginQuery(), loginData, _appSettings.Postgres).Result as ReturnCertEntity;
    }
}
