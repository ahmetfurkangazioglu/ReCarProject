using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : ControllerBase
    {
        IFakePaymentService _fakePaymentService;

        public FakePaymentController(IFakePaymentService fakePaymentService)
        {
            _fakePaymentService = fakePaymentService;
        }


        [HttpPost("update")]
        public IActionResult Update(FakePayment fakePayment)
        {
            var result = _fakePaymentService.Update(fakePayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("checkrule")]
        public IActionResult CheckRule(FakePayment fakePayment)
        {
            var result = _fakePaymentService.CheckCard(fakePayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
