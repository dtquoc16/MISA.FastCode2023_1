using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.AnswerBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.DiscussBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Resource;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.API.Controllers
{
    [ApiController]
    public class AnswerController : BaseController<Answer>
    {
        #region Field

        private IAnswerBL _answerBL;

        #endregion

        #region Constructor
        public AnswerController(IAnswerBL answerBL) : base(answerBL)
        {
            _answerBL = answerBL;
        }

        #endregion

        [HttpPost]
        public IActionResult InsertAnswer([FromBody] Answer answer)
        {
            try
            {
                var res = _answerBL.InsertAnswer(answer);


                if (res.NumberOfRecordAffect == 1)
                {
                    return StatusCode(StatusCodes.Status201Created, res.IdRecord);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.InsertError,
                    DevMsg = Resource.DevMsg_InsertError,
                    UserMsg = Resource.UserMsg_InsertError,
                    TraceId = HttpContext.TraceIdentifier,

                });



            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier,
                });
            }
        }

    }
}
