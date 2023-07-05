
using MISA.QLTS.DEMO.Web04.DTQUOC.Common;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Resource;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.AssetDL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL.AssetBL
{
    public class AssetBL : BaseBL<Asset>, IAssetBL
    {
        #region Field

        private IAssetDL _assetDL;

        #endregion


        #region Contrustor

        public AssetBL(IAssetDL assetDL) : base(assetDL)
        {
            _assetDL = assetDL;
        }

        #endregion


        #region Method

        /// <summary>
        /// Hàm kiểm tra mã có trùng không
        /// </summary>
        /// <param name="assetId">ID tài sản</param>
        /// <param name="assetCode">Mã tài sản</param>
        /// <returns>
        ///     - true: trùng
        ///     - false: không trùng
        /// </returns>
        public bool CheckDuplicateAssetCode(Guid assetId, string assetCode)
        {
            return _assetDL.CheckDuplicateCode(assetId, assetCode);
        }

        /// <summary>
        /// API Thêm mới 1 tài sản
        /// </summary>
        /// <param name="asset">Đối tượng tài sản cần thêm mới</param>
        /// <returns>ID của tài sản vừa thêm mới</returns>
        /// Created by: DTQUOC (6/6/2023)
        public Response InsertAsset(Asset asset)
        {
            var validateResult = new List<string>();
            // Check trường bắt buộc
            CheckRequired(asset, validateResult);

            // Check mã trùng
            if (_assetDL.CheckDuplicateCode(asset.AssetId, asset.AssetCode))
            {
                string error = Resource.AssetCode + asset.AssetCode + Resource.AssetCodeDuplicate;
                validateResult.Add(error);
            }

            // Check nghiệp vụ
            CheckMajor(asset, validateResult);

            if (validateResult.Count > 0)
            {
                return new Response
                {
                    IsSuccess = false,
                    Data = validateResult

                };
            }

            Response res = _assetDL.InsertAsset(asset);
            return new Response
            {
                IsSuccess = true,
                NumberOfRecordAffect = res.NumberOfRecordAffect,
                IdRecord = res.IdRecord,
            };

        }



        /// <summary>
        /// API sửa tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn sửa</param>
        /// <param name="asset">Đối tượng tài sản muốn sửa</param>
        /// <returns>ID tài sản muốn sửa</returns>
        /// Created by: DTQUOC (6/6/2023) 
        public Response UpdateAsset(Guid assetId, Asset asset)
        {
            var validateResult = new List<string>();
            // Check trường bắt buộc
            CheckRequired(asset, validateResult);

            // Check mã trùng
            if (_assetDL.CheckDuplicateCode(asset.AssetId, asset.AssetCode))
            {
                string error = Resource.AssetCode + asset.AssetCode + Resource.AssetCodeDuplicate;
                validateResult.Add(error);
            }

            // Check nghiệp vụ
            CheckMajor(asset, validateResult);

            if (validateResult.Count > 0)
            {
                return new Response
                {
                    IsSuccess = false,
                    Data = validateResult

                };
            }

            Response res = _assetDL.UpdateAsset(assetId, asset);
            return new Response
            {
                IsSuccess = true,
                NumberOfRecordAffect = res.NumberOfRecordAffect,
                IdRecord = res.IdRecord,
            };

        }

        /// <summary>
        /// hàm xóa 1 tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn xóa</param>
        /// <returns>Status code 200</returns>
        /// Created by: DTQUOC (6/6/2023)
        public int DeleteAsset(Guid assetId)
        {
            return _assetDL.DeleteAsset(assetId);
        }

        /// <summary>
        /// Hàm xóa nhiều tài sản theo danh sách id tài sản
        /// </summary>
        /// <param name="listAssetId">danh id tài sản cần xóa</param>
        /// <returns>xóa thành công</returns>
        /// Created by: DTQUOC (10/6/2023)
        public int DeleteMultipleAssetById(List<Guid> listAssetId)
        {
            return _assetDL.DeleteMultipleAssetById(listAssetId);

        }

        /// <summary>
        /// Hàm sinh ra mã mới 
        /// </summary>
        /// <returns>mã tài sản mới</returns>
        /// Created by: DTQUOC (21/6/2023)
        public string GetMaxAssetCode()
        {
            string assetCodeMax = _assetDL.GetMaxAssetCode();
            string assetCodeMaxNew = ConvertCodeNew(assetCodeMax);
            return assetCodeMaxNew;
        }

        /// <summary>
        /// Hàm phân trang theo từ khóa tìm kiếm và lọc
        /// </summary>
        /// <param name="keyFilter">từ khóa tìm kiếm</param>
        /// <param name="departmentId">id phòng ban</param>
        /// <param name="assetTypeId">id loại tài sản</param>
        /// <param name="pageIndex">vị trí trang</param>
        /// <param name="pageNum">số bản ghi trên một trang</param>
        /// <returns>danh sách tài sản thảo mãn yêu cầu</returns>
        /// Created by: DTQUOC (10/6/2023)
        public PagingResult GetAssetByFilterAndPaging(string? keyFilter, Guid? departmentId, Guid? assetTypeId, int? pageIndex, int? pageNum)
        {
            return _assetDL.GetAssetByFilterAndPaging(keyFilter, departmentId, assetTypeId, pageIndex, pageNum);

        }

        /// <summary>
        /// Hàm lấy danh sách tài sản để xuất dữ liệu
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="departmentId">ID phòng ban</param>
        /// <param name="assetTypeId">ID loại tài sản</param>
        /// <returns>Danh sách tài sản</returns>
        /// Created by: DTQUOC (1/7/2023)
        public PagingResult AssetData(string? keyWord, Guid? departmentId, Guid? assetTypeId)
        {
            return _assetDL.ExportAssetData(keyWord, departmentId, assetTypeId);
        }

        /// <summary>
        /// Hàm để xuất dữ liệu ra file excel
        /// </summary>
        /// <param name="listRecord">Danh sách dữ liệu cần xuất</param>
        /// <returns>File excel</returns>
        /// Created by: DTQUOC (1/7/2023)
        public MemoryStream ExportAssetData(List<Asset> listRecord)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                package.Workbook.Properties.Author = "DTQUOC";

                var workSheet = package.Workbook.Worksheets.Add("DANH_SACH_TAI_SAN");

                // Tạo title
                workSheet.Cells["A1"].Value = "DANH SÁCH TÀI SẢN";
                workSheet.Cells["A1:I1"].Merge = true;
                workSheet.Cells["A1:I1"].Style.Font.SetFromFont("Arial", 16, bold: true);
                workSheet.Cells["A1:I1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //Tạo header
                workSheet.Cells[3, 1].Value = "STT";
                workSheet.Cells[3, 2].Value = "Mã tài sản";
                workSheet.Cells[3, 3].Value = "Tên tài sản";
                workSheet.Cells[3, 4].Value = "Id phòng ban";
                workSheet.Cells[3, 5].Value = "Mã phòng ban";
                workSheet.Cells[3, 6].Value = "Tên phòng ban";
                workSheet.Cells[3, 7].Value = "Id loại tài sản";
                workSheet.Cells[3, 8].Value = "Mã loại tài sản";
                workSheet.Cells[3, 9].Value = "Tên loại tài sản";
                workSheet.Cells[3, 10].Value = "Số lượng";
                workSheet.Cells[3, 11].Value = "Nguyên giá";
                workSheet.Cells[3, 12].Value = "Số năm sử dụng";
                workSheet.Cells[3, 13].Value = "Tỉ lệ hao mòn";
                workSheet.Cells[3, 14].Value = "Năm theo dõi";
                workSheet.Cells[3, 15].Value = "Ngày mua";
                workSheet.Cells[3, 16].Value = "Ngày bắt đầu sử dụng";
                workSheet.Cells[3, 17].Value = "Người tạo";
                workSheet.Cells[3, 18].Value = "Thời gian tạo";
                workSheet.Cells[3, 19].Value = "Người sửa";
                workSheet.Cells[3, 20].Value = "Thời gian sửa";

                // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
                using (var range = workSheet.Cells["A3:T3"])
                {
                    // Set PatternType
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    // Set Màu cho Background
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    // Canh giữa cho các text
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    // Set Font cho text  trong Range hiện tại
                    range.Style.Font.SetFromFont("Arial", 10, bold: true);
                    // Set Border
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Top.Color.SetColor(Color.Black);
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Color.SetColor(Color.Black);
                }

                // Đỗ dữ liệu từ list vào 
                int recorddRow = 4;
                for (int i = 0; i < listRecord.Count; i++)
                {

                    var item = listRecord[i];
                    workSheet.Cells[recorddRow, 1].Value = i + 1;
                    workSheet.Cells[recorddRow, 2].Value = item.AssetCode;
                    workSheet.Cells[recorddRow, 3].Value = item.AssetName;
                    workSheet.Cells[recorddRow, 4].Value = item.DepartmentId;
                    workSheet.Cells[recorddRow, 5].Value = item.DepartmentCode;
                    workSheet.Cells[recorddRow, 6].Value = item.DepartmentName;
                    workSheet.Cells[recorddRow, 7].Value = item.AssetTypeId;
                    workSheet.Cells[recorddRow, 8].Value = item.AssetTypeCode;
                    workSheet.Cells[recorddRow, 9].Value = item.AssetTypeName;
                    workSheet.Cells[recorddRow, 10].Value = item.Quantity;
                    workSheet.Cells[recorddRow, 11].Value = item.Cost;
                    workSheet.Cells[recorddRow, 12].Value = item.LifeTime;
                    workSheet.Cells[recorddRow, 13].Value = item.PercenAtrophy;
                    workSheet.Cells[recorddRow, 14].Value = item.YearFollow;
                    workSheet.Cells[recorddRow, 15].Value = ConvertDate(item.PurchaseDate);
                    workSheet.Cells[recorddRow, 16].Value = ConvertDate(item.UsingDate);

                    workSheet.Cells[recorddRow, 17].Value = item.CreatedBy;
                    workSheet.Cells[recorddRow, 18].Value = item.CreatedDate;
                    workSheet.Cells[recorddRow, 19].Value = item.ModifiedBy;
                    workSheet.Cells[recorddRow, 20].Value = item.ModifiedDate;


                    workSheet.Row(recorddRow).Style.Font.SetFromFont("Times New Roman", 11);
                    workSheet.Row(recorddRow).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    workSheet.Cells[$"A{recorddRow}:$I{recorddRow}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A{recorddRow}:$I{recorddRow}"].Style.Border.Bottom.Color.SetColor(Color.Black);
                    recorddRow++;
                }
                //make all text fit the cells
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();

                // căm giữa ngày 
                workSheet.Column(15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //i use this to make all columms just a bit wider, text would sometimes still overflow after AutoFitColumns(). Bug?
                for (int col = 1; col <= workSheet.Dimension.End.Column; col++)
                {
                    workSheet.Column(col).Width = workSheet.Column(col).Width + 1;
                    workSheet.Cells[3, col, recorddRow - 1, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[3, col, recorddRow - 1, col].Style.Border.Right.Color.SetColor(Color.Black);
                }
                package.Save();
            }
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Hàm validate theo nghiệp vụ
        /// </summary>
        /// <param name="asset">tài sản cần validate</param>
        /// <param name="validateResult">danh sách lỗi validate</param>
        /// Created by: DTQUOC (10/6/2023)
        private static void CheckMajor(Asset asset, List<string> validateResult)
        {
            /* if(1/(asset.LifeTime)*100 != asset.PercenAtrophy)
             {
                 validateResult.Add(Resource.CheckLifeTimeAndPercenAtrophy);
             }*/

            if (asset.PurchaseDate > DateTime.Now)
            {
                validateResult.Add(Resource.CheckPurchaseDate);
            }
            if (asset.UsingDate > DateTime.Now)
            {
                validateResult.Add(Resource.CheckUsingDate);
            }
            if (asset.PurchaseDate > asset.UsingDate)
            {
                validateResult.Add(Resource.ChechUsingDateAndPurchaseDate);
            }


        }

        
        /// <summary>
        /// Hàm check rỗng
        /// </summary>
        /// <param name="asset">tài sản cần kiểm tra</param>
        /// <param name="validateResult">danh sách các lỗi</param>
        /// Created by: DTQUOC (10/6/2023)
        private static void CheckRequired(Asset asset, List<string> validateResult)
        {
            var property = typeof(Asset).GetProperties();

            foreach (var item in property)
            {
                var propertyValue = item.GetValue(asset);
                var required = (RequiredAttribute?)Attribute.GetCustomAttribute(item, typeof(RequiredAttribute));
                if (required != null && string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    validateResult.Add(required.ErrorMessage);
                }
            }
        }

        /// <summary>
        /// Hàm convert mã lớn nhất rồi + 1
        /// </summary>
        /// <param name="assetCodeMax">mã lớn nhất</param>
        /// <returns>mã sinh ra đúng yêu cẩu</returns>
        /// Created by: DTQUOC (22/6/2023)
        private static string ConvertCodeNew(string assetCodeMax)
        {
            // Chuỗi phần số trong mã
            string check = "";

            // Vị trí cuối cùng của phần tử là số 
            int index = 0;

            // Kết quả phần số
            string result = "";

            // Mã tài sản mới thỏa mãn yêu cầu
            string assetCodeMaxNew = "";
            /*char[] checkArray = check.ToCharArray();*/
            for (int i = assetCodeMax.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(assetCodeMax[i]))
                {
                    check += assetCodeMax[i];
                }
                else if (i == assetCodeMax.Length - 1)
                {
                    return (assetCodeMax + 1);
                }
                else
                {
                    break;
                }
                index = i;
            }
            char[] checkArray = check.ToCharArray();
            Array.Reverse(checkArray);
            string reverse = new string(checkArray);
            int checkCode = Int32.Parse(reverse) + 1;
            int lenCheckCode = checkCode.ToString().Length;
            result = checkCode.ToString();
            for (int i = 0; i < (reverse.Length - lenCheckCode); i++)
            {
                result = result.Insert(0, "0");
            }

            assetCodeMaxNew = assetCodeMax.Substring(0, index) + result;

            return assetCodeMaxNew;
        }

        private string ConvertDate(DateTime? date)
        {
            if (date.HasValue)
            {
                DateTime dateTime = (DateTime)date;
                return dateTime.ToString("dd/MM/yyyy");
            }
            else return "";
        }

        #endregion
    }
}
