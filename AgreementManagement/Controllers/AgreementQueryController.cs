using ams.DataAccess.Database.Entity;
using ams.DataAccess.Repository.Agreement;
using ams.Models;
using ams.Models.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgreementManagement.Controllers
{
    [Route("api/Agreement")]
    [ApiController]
    public class AgreementQueryController : ControllerBase
    {
        private readonly IAgreementRepository _agreementRepository;
        private readonly IMapper _mapper;
        public AgreementQueryController(IAgreementRepository agreementRepository, IMapper mapper)
        {
            _agreementRepository = agreementRepository;
            _mapper = mapper;
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetAgreementList()
        {
            var result = await _agreementRepository.GetAll();
            var model = _mapper.Map<List<VendorAgreementVM>>((List<VendorAgreement>?)result.Data);
            if (result.Success)
                return Ok(new HttpResponseModel(model));
            return BadRequest(result);
        }
    }
}
