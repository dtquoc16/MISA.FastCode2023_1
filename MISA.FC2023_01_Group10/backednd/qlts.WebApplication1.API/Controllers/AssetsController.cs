using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.AssetBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Resource;
using Mysqlx.Crud;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.API.Controllers
{
    [ApiController]
    public class AssetsController : BaseController<Asset>
    {
        #region Field

        private IAssetBL _assetBL;

        #endregion

        #region Contrustor

        public AssetsController(IAssetBL assetBL) : base(assetBL)
        {
            _assetBL = assetBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API kiểm tra mã tài sản có trùng không
        /// </summary>
        /// <param name="assetCode">mã tài sản</param>
        /// <returns>
        ///     0 - không trùng
        ///     1 - trùng
        /// </returns>
        /// Created by: DTQUOC (28/6/2023)
        [HttpGet("{assetCode}")]
        public IActionResult CheckDuplicateAssetCode([FromRoute] Guid assetId, [FromRoute] string assetCode)
        {
            try
            {
                var res = _assetBL.CheckDuplicateAssetCode(assetId, assetCode);
                if (res == false)
                {
                    return StatusCode(StatusCodes.Status404NotFound, 0);
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, 1);
                }
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

        /// <summary>
        /// API Thêm mới 1 tài sản
        /// </summary>
        /// <param name="asset">Đối tượng tài sản cần thêm mới</param>
        /// <returns>ID của tài sản vừa thêm mới</returns>
        /// Created by: DTQUOC (6/6/2023)
        [HttpPost]
        public IActionResult InsertAsset([FromBody] Asset asset)
        {
            try
            {
                var res = _assetBL.InsertAsset(asset);

                if (res.IsSuccess == true)
                {
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
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = ErrorCode.InsertError,
                        DevMsg = Resource.DevMsg_InsertError,
                        UserMsg = Resource.UserMsg_InsertError,
                        MoreInfo = res.Data,
                        TraceId = HttpContext.TraceIdentifier,
                    });
                }

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



        /// <summary>
        /// API sửa tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn sửa</param>
        /// <param name="asset">Đối tượng tài sản muốn sửa</param>
        /// <returns>ID tài sản muốn sửa</returns>
        /// Created by: DTQUOC (6/6/2023)
        [HttpPut("{assetId}")]
        public IActionResult UpdateAsset([FromRoute] Guid assetId,
            [FromBody] Asset asset)
        {
            try
            {
                Response res = _assetBL.UpdateAsset(assetId, asset);

                //Xử lý kết quả trả về
                if (res.IsSuccess == true)
                {
                    if (res.NumberOfRecordAffect == 1)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResult
                    {
                        ErrorCode = ErrorCode.UpdateError,
                        DevMsg = Resource.DevMsg_UpdateError,
                        UserMsg = Resource.UserMsg_UpdateError,
                        TraceId = HttpContext.TraceIdentifier,
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = ErrorCode.UpdateError,
                        DevMsg = Resource.DevMsg_UpdateError,
                        UserMsg = Resource.UserMsg_UpdateError,
                        MoreInfo = res.Data,
                        TraceId = HttpContext.TraceIdentifier,
                    });
                }
            }


            // Thất bại --> trả về lỗi
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API xóa 1 tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn xóa</param>
        /// <returns>Status code 200OK</returns>
        /// Created by: DTQUOC (6/6/2023)
        [HttpDelete("{assetId:Guid}")]
        public IActionResult DeleteAsset([FromRoute] Guid assetId)
        {
            try
            {
                var res = _assetBL.DeleteAsset(assetId);

                //Xử lý kết quả trả về
                if (res > 0)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }

                return StatusCode(StatusCodes.Status404NotFound, new ErrorResult
                {
                    ErrorCode = ErrorCode.DeleteError,
                    DevMsg = Resource.DevMsg_DeleteError,
                    UserMsg = Resource.UserMsg_DeleteError,
                    TraceId = HttpContext.TraceIdentifier
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
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Hàm xóa nhiều tài sản theo mảng các id (dùng transaction)
        /// </summary>
        /// <param name="listAssetId">mảng các id của các tài sản muốn xóa</param>
        /// <returns>số lượng tài sản bị xóa</returns>
        /// Created by: DTQUOC (6/6/2023)

        [HttpDelete("deleteMultiple")]
        public IActionResult DeleteMultipleAsset([FromBody] List<Guid> listAssetId)
        {
            try
            {
                int res = _assetBL.DeleteMultipleAssetById(listAssetId);

                if (res == listAssetId.Count)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status404NotFound, new ErrorResult
                {
                    ErrorCode = ErrorCode.DeleteError,
                    DevMsg = Resource.DevMsg_DeleteError,
                    UserMsg = Resource.UserMsg_DeleteError,
                    TraceId = HttpContext.TraceIdentifier
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
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }


        /// <summary>
        /// Hàm lấy mã tài sản lớn nhất + 1
        /// </summary>
        /// <returns>mã tài sản lớn nhất + 1</returns>
        /// Created by: DTQUOC (6/6/2023)
        [HttpGet("assetCodeMax")]
        public IActionResult GetAssetCodeMax()
        {
            try
            {
                string assetCode = _assetBL.GetMaxAssetCode();

                return StatusCode(StatusCodes.Status200OK, assetCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Hàm phân trang và tìm kiếm theo từ khóa, id phòng ban, id loại tài sản
        /// </summary>
        /// <param name="keyFilter">từ khóa cần tìm kiếm</param>
        /// <param name="departmentId">id phòng ban</param>
        /// <param name="assetTypeId">id loại tài sản</param>
        /// <param name="pageIndex">vị trí trang</param>
        /// <param name="pageNum">số bản ghi trên một trang</param>
        /// <returns>danh sách bản ghi thỏa mãn yêu cầu</returns>
        /// Created by: DTQUOC (6/6/2023)
        [HttpGet("filter")]
        public IActionResult GetAssetByFilterAndPaging(
            [FromQuery] string? keyFilter,
            [FromQuery] Guid? departmentId,
            [FromQuery] Guid? assetTypeId,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageNum = 20)
        {
            try
            {
                var res = _assetBL.GetAssetByFilterAndPaging(keyFilter, departmentId, assetTypeId, pageIndex, pageNum);

                return StatusCode(StatusCodes.Status200OK, res);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API xuất file excel
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="departmentId">ID phòng ban</param>
        /// <param name="assetTypeId">ID loại tài sản</param>
        /// <returns>File excel danh sách tài sản</returns>
        /// Created by: DTQUOC (1/7/2023)
        [HttpGet("export")]
        public IActionResult ExportAssetData([FromQuery] string? keyWord,
            [FromQuery] Guid? departmentId,
            [FromQuery] Guid? assetTypeId)
        {
            try
            {
                var records = _assetBL.AssetData(keyWord, departmentId, assetTypeId);
                if (records.ListAsset == null)
                {
                    records.ListAsset = new List<Asset>();
                }

                MemoryStream stream = _assetBL.ExportAssetData(records.ListAsset);
                string excelName = "Danh_Sach_Tai_San" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ".xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);


            }
            //Try catch exception 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        #endregion
    }
}
