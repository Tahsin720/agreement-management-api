using AgreementManagement.Dto;
using ams.DataAccess.Database.Entity;
using ams.DataAccess.Repository.Agreement;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgreementManagement.Controllers
{
    [Route("api/Agreement")]
    [ApiController]
    public class AgreementCommandController : ControllerBase
    {
        private readonly IAgreementRepository _agreementRepository;
        private readonly IMapper _mapper;
        public AgreementCommandController(IAgreementRepository agreementRepository, IMapper mapper)
        {
            _agreementRepository = agreementRepository;
            _mapper = mapper;
        }
        [HttpPost("create-agreement")]
        public async Task<IActionResult> CreateAgreement([FromForm] VendorAgreementDto model)
        {
            var agreementDetails = _mapper.Map<VendorAgreement>(model);
            agreementDetails.duration = (agreementDetails.expiry_date!.Value.Year - agreementDetails.start!.Value.Year).ToString() + " Years";
            agreementDetails.create_by = 1; //I don't work with session
            agreementDetails.verify_by = 1; //I don't work with session
            agreementDetails.is_renewed = false;
            agreementDetails.signed_date = DateTime.UtcNow;
            agreementDetails.verify_date = DateTime.UtcNow;
            agreementDetails.create_date = DateTime.UtcNow;
            agreementDetails.status = "Active";

            if (model.File != null)
            {
                string extension = Path.GetExtension(model.File.FileName);
                var fileName = DateTime.Now.ToString("yymmssfff") + extension;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await model.File.CopyToAsync(filestream);
                }
                agreementDetails.AgreementFile = fileName;
            }
            var result = await _agreementRepository.Create(agreementDetails);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
