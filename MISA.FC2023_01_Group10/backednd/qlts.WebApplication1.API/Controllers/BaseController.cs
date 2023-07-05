using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Resource;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.API.Controllers

{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Contrustor


        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        /// <summary>
        /// Lấy danh sách thông tin toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: DTQUOC (6/06/2023)
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {
                var records = _baseBL.GetAllRecords();

                //Thành công: Trả về dữ liệu FE
                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }

                return StatusCode(StatusCodes.Status200OK, new List<T>());

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
                }) ;
            }


        }
        /// <summary>
        /// Lấy thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordId">ID bản ghi muốn lấy thông tin</param>
        /// <returns>Thông tin tài sản</returns>
        /// Created by: DTQUOC (6/6/2023)
        [HttpGet("{recordId:Guid}")]
        public IActionResult GetRecordById([FromRoute] Guid recordId)
        {
            try
            {

                var record = _baseBL.GetRecordById(recordId);

                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
                }

                return StatusCode(StatusCodes.Status404NotFound, new ErrorResult 
                {
                    ErrorCode = ErrorCode.GetDetail,
                    DevMsg = Resource.DevMsg_GetDetail,
                    UserMsg= Resource.UserMsg_GetDetail,
                    TraceId = HttpContext.TraceIdentifier,
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg= Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier,
                });
            }
        }
    }
}
