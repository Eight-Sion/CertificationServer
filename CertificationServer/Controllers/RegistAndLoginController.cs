using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CertificationServer.Models;
using CertificationServer.Models.Query;
using CertificationServer.Services;
using CertificationServer.Services.Crypt;
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
        {
            var result = BCryptService.Regist(registData, _appSettings);
            return (result.err == true)? new ReturnCertEntity() : result.data;
        }
        [HttpPost]
        public ReturnCertEntity PostLoginData(LoginEntity loginData)
        {
            var result = BCryptService.Verify(loginData, _appSettings);
            return (result.err == true) ? new ReturnCertEntity() : result.data;
        }
    }
}
