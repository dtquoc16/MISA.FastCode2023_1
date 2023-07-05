
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.DL.AssetDL
{
    public interface IAssetDL : IBaseDL<Asset>
    {
        /// <summary>
        /// API Thêm mới 1 tài sản
        /// </summary>
        /// <param name="asset">Đối tượng tài sản cần thêm mới</param>
        /// <returns>
        ///     true: thành công
        ///     false: lỗi
        /// </returns>
        /// Created by: DTQUOC (6/6/2023)
        public Response InsertAsset(Asset asset);

        /// <summary>
        /// API sửa tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn sửa</param>
        /// <param name="asset">Đối tượng tài sản muốn sửa</param>
        /// <returns>
        ///     true: thành công
        ///     false: lỗi
        /// </returns>
        /// Created by: DTQUOC (6/6/2023)
        public Response UpdateAsset(Guid assetId, Asset asset);

        /// <summary>
        /// API xóa 1 tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn xóa</param>
        /// <returns>Status code 200</returns>
        /// Created by: DTQUOC (6/6/2023)
        public int DeleteAsset(Guid assetId);

        /// <summary>
        /// API xóa nhiều tài sản theo danh sách ID
        /// </summary>
        /// <param name="listAssetId">Danh sách ID tài sản</param>
        /// <returns>StatusCode200</returns>
        /// Created by: DTQUOC (11/6/2023)
        public int DeleteMultipleAssetById(List<Guid> listAssetId);

        /// <summary>
        /// API lấy danh sách tài sản theo bộ lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <param name="departmentId">ID phòng ban</param>
        /// <param name="assetTypeId">ID loại tài sản</param>
        /// <param name="limit">Số bản ghi cần lấy</param>
        /// <param name="offset">Bản ghi bắt đầu lấy</param>
        /// <returns>Danh sách bản ghi + số bản ghi thỏa mãn</returns>
        /// Created by: DTQUOC (11/6/2023)
        public PagingResult GetAssetByFilterAndPaging(string? keyFilter, Guid? departmentId, Guid? assetTypeId, int? pageIndex, int? pageNum);

        /// <summary>
        /// Hàm lấy danh sách tài sản để xuất dữ liệu
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="departmentId">ID phòng ban</param>
        /// <param name="assetTypeId">ID loại tài sản</param>
        /// <returns>Danh sách tài sản</returns>
        /// Created by: DTQUOC (1/7/2023)
        public PagingResult ExportAssetData(string? keyWord, Guid? departmentId, Guid? assetTypeId);

        /// <summary>
        /// API lấy mã tài sản lớn nhất + 1
        /// </summary>
        /// <returns>Trả về mã tài sản lớn nhất + 1</returns>
        /// Created by: DTQUOC (11/6/2023)
        public string GetMaxAssetCode();

        /// <summary>
        /// API kiểm tra trùng mã tài sản
        /// </summary>
        /// <param name="assetCode">Mã tài sản</param>
        /// <returns>
        ///     true: trùng
        ///     false: không trùng
        /// </returns>
        /// Created by: DTQUOC (11/6/2023)
        public bool CheckDuplicateCode(Guid assetId, string assetCode);
    }
}
