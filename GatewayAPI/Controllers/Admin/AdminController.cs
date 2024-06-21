using GatewayAPI.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GatewayAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly Organization.OrganizationClient _organizationClient;

        public AdminController(Organization.OrganizationClient organizationClient)
        {
            _organizationClient = organizationClient;
        }

        [HttpGet("SaveOrganization")]
        public async Task<OrganizationReply> SaveOrganization(string name)
        {
            var request = new OrganizationRequest { OrganizationName = name,IsActive=true };
            var reply =  _organizationClient.GetOrganization(request);
            return reply;
        }
    }
}
