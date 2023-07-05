using Dapper;
using MySqlConnector;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using System.Data;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.DL.AssetDL
{
    public class AssetDL : BaseDL<Asset>, IAssetDL
    {
        /// <summary>
        /// API Thêm mới 1 tài sản
        /// </summary>
        /// <param name="asset">Đối tượng tài sản cần thêm mới</param>
        /// <returns>ID của tài sản vừa thêm mới</returns>
        /// Created by: DTQUOC (5/6/2023)
        public Response InsertAsset(Asset asset)
        {


            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.ASSET_ADD;

            // Chuẩn bị tham số đầu vào
            var newAssetId = Guid.NewGuid();
            var parameters = asset;
            parameters.AssetId = newAssetId;
            parameters.CreatedBy = "DTQUOC";
            parameters.CreatedDate = DateTime.Now;

            int numberOfRecordAffect = 0;

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                numberOfRecordAffect = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            }

            //Xử lý kết quả trả về
            return new Response
            {
                IdRecord = newAssetId,
                NumberOfRecordAffect = numberOfRecordAffect,
            };
        }



        /// <summary>
        /// API sửa tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn sửa</param>
        /// <param name="asset">Đối tượng tài sản muốn sửa</param>
        /// <returns>ID tài sản muốn sửa</returns>
        /// Created by: DTQUOC (5/6/2023)
        public Response UpdateAsset(Guid assetId, Asset asset)
        {

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.ASSET_EDIT;

            // Chuẩn bị tham số đầu vào
            asset.AssetId = assetId;

            var parameters = asset;

            parameters.ModifiedBy = "DTQUOC";
            parameters.ModifiedDate = DateTime.Now;

            // Khởi tạo kết nối đến DB
            int numberOfRecordAffect = 0;
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                numberOfRecordAffect = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            }

            //Xử lý kết quả trả về
            return new Response
            {
                NumberOfRecordAffect = numberOfRecordAffect
            };
        }

        /// <summary>
        /// API xóa 1 tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn xóa</param>
        /// <returns>Status code 200</returns>
        /// Created by: DTQUOC (6/6/2023)
        public int DeleteAsset(Guid assetId)
        {

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.ASSET_DELETE;

            //Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("@assetId", assetId);

            int numberOfRecordAffect = 0;

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                numberOfRecordAffect = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
            //Xử lý kết quả trả về
            return numberOfRecordAffect;
        }

        /// <summary>
        /// API xóa nhiều tài sản theo danh sách ID
        /// </summary>
        /// <param name="listAssetId">danh sách ID tài sản cần xóa</param>
        /// <returns>StatusCode200</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// Created by: DTQUOC (11/6/2023)
        public int DeleteMultipleAssetById(List<Guid> listAssetId)
        {
            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.ASSET_DELETE_MULTI;

            // Chuẩn bị tham số đầu vào
            string listId = string.Join(",", listAssetId.Select(s => "'" + s + "'"));

            var parameters = new DynamicParameters();
            parameters.Add("@listId", listId);
            int numberOfRecordAffect = 0;

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                using (var transaction = mySqlConnection.BeginTransaction())
                {
                    // Thực hiện gọi vào DB
                    numberOfRecordAffect = mySqlConnection.Execute(storedProcedureName, parameters, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);

                    if (numberOfRecordAffect == listAssetId.Count)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
            }
            // Xử lí kết quả trả về
            return (int)numberOfRecordAffect;
        }

        /// <summary>
        /// API lấy danh sách tài sản theo bộ lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <param name="assetTypeId">Mã loại tài sản</param>
        /// <param name="limit">Số bản ghi muốn lấy</param>
        /// <param name="offset">Vị trí bản ghi muốn lấy</param>
        /// <returns>Danh sách tài sản thỏa mãn và tổng số bản ghi</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// Created by: DTQUOC (6/6/2023)
        public PagingResult GetAssetByFilterAndPaging(string? keyFilter, Guid? departmentId, Guid? assetTypeId, int? pageIndex, int? pageNum)
        {
            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.ASSET_FILTER;

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("@keyFilter", keyFilter);
            parameters.Add("@departmentId", departmentId);
            parameters.Add("@assetTypeId", assetTypeId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageNum", pageNum);

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                var result = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                long total = result.Read<long>().Single();
                var assets = result.Read<Asset>().ToList();
                long quantity = result.Read<long>().Single();
                long cost = result.Read<long>().Single();
                long percenAtrophyValue = result.Read<long>().Single();
                long percenAccumulated = result.Read<long>().Single();
                long value = cost - percenAtrophyValue;

                // Xử lí kết quả trả về
                if (assets != null)
                {
                    return new PagingResult
                    {
                        ListAsset = assets,
                        TotalRecord = total,
                        Quantity = quantity,
                        Cost = cost,
                        PercenAccumulated = percenAccumulated,
                        Value = value,
                    };
                }

                // Không có bản ghi nào trong DB thỏa mãn
                return new PagingResult
                {
                    TotalRecord = 0,
                    ListAsset = new List<Asset>(),
                };

            }
        }

        /// <summary>
        /// Hàm lấy danh sách tài sản để xuất dữ liệu
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="departmentId">ID phòng ban</param>
        /// <param name="assetTypeId">ID loại tài sản</param>
        /// <returns>Danh sách tài sản</returns>
        /// Created by: DTQUOC (1/7/2023)
        public PagingResult ExportAssetData(string? keyWord, Guid? departmentId, Guid? assetTypeId)
        {
            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.EXPORT_EXCEL;

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("@keyWord", keyWord);
            parameters.Add("@departmentId", departmentId);
            parameters.Add("@assetTypeId", assetTypeId);

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                var result = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var assets = result.Read<Asset>().ToList();


                // Xử lí kết quả trả về
                if (assets != null)
                {
                    return new PagingResult
                    {
                        ListAsset = assets,

                    };
                }

                // Không có bản ghi nào trong DB thỏa mãn
                return new PagingResult
                {
                    TotalRecord = 0,
                    ListAsset = new List<Asset>(),
                };

            }
        }

        /// <summary>
        /// API lấy mã tài sản lớn nhất + 1
        /// </summary>
        /// <returns>Mã tài sản lớn nhất + 1</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// Created by: DTQUOC (6/6/2023)
        public string GetMaxAssetCode()
        {
            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.ASSET_GET_CODEMAX;

            // Chuẩn bị tham số đầu vào
            var assetCode = "";

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                assetCode = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
            }
            return assetCode;
        }

        /// <summary>
        /// Hàm kiểm tra mã tài sản có trùng không
        /// </summary>
        /// <param name="assetCode">Mã tài sản</param>
        /// <returns>
        ///     true: trùng
        ///     false: không trùng
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        /// Created by: DTQUOC (6/6/2023)
        public bool CheckDuplicateCode(Guid assetId, string assetCode)
        {
            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.ASSET_CHECK_DUPLICATE_CODE;

            // Chuẩn bị tham số đầu vào
            var parameter = new DynamicParameters();
            parameter.Add("@assetId", assetId);
            parameter.Add("@assetCode", assetCode);

            object numberOfRecordAffect = null;

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB

                numberOfRecordAffect = mySqlConnection.QueryFirstOrDefault(storedProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);


            }

            // Xử lí kết quả trả về
            if (numberOfRecordAffect != null)
            {
                return true;

            }
            return false;

        }
    }


}


