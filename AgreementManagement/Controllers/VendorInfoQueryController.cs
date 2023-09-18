using ams.DataAccess.Repository.VendorInfo;
using Microsoft.AspNetCore.Mvc;

namespace AgreementManagement.Controllers
{
    [Route("api/vendor-information")]
    [ApiController]
    public class VendorInfoQueryController : ControllerBase
    {
        private readonly IVendorInfoRepository _vendorInfoRepository;
        public VendorInfoQueryController(IVendorInfoRepository vendorInfoRepository)
        {
            _vendorInfoRepository = vendorInfoRepository;
        }
        [HttpGet("get-ids")]
        public async Task<IActionResult> GetVendorIds()
        {
            var result = await _vendorInfoRepository.GetAllIds();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
