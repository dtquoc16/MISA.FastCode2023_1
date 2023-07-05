using Microsoft.AspNetCore.Mvc;

using MISA.QLTS.DEMO.Web04.DTQUOC.BL.DiscussBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Resource;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.API.Controllers
{
    [ApiController]
    public class DiscussController : BaseController<Discuss>
    {
        #region Field

        private IDiscussBL _discussBL;

        #endregion

        #region Constructor
        public DiscussController(IDiscussBL discussBL) : base(discussBL)
        {
            _discussBL = discussBL;
        }

        #endregion

        /// <summary>
        /// API Thêm mới 1 tài sản
        /// </summary>
        /// <param name="asset">Đối tượng tài sản cần thêm mới</param>
        /// <returns>ID của tài sản vừa thêm mới</returns>
        /// Created by: DTQUOC (6/6/2023)
        [HttpPost]
        public IActionResult InsertDiscuss([FromBody] Discuss discuss)
        {
            try
            {
                var res = _discussBL.InsertDiscuss(discuss);

               
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
