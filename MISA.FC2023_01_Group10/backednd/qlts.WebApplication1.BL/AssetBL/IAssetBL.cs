using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL.AssetBL
{
    public interface IAssetBL : IBaseBL<Asset>
    {
        /// <summary>
        /// API Thêm mới 1 tài sản
        /// </summary>
        /// <param name="asset">Đối tượng tài sản cần thêm mới</param>
        /// <returns>ID của tài sản vừa thêm mới</returns>
        /// Created by: DTQUOC (6/6/2023)
        public Response InsertAsset(Asset asset);

        /// <summary>
        /// API sửa tài sản theo ID
        /// </summary>
        /// <param name="assetId">ID tài sản muốn sửa</param>
        /// <param name="asset">Đối tượng tài sản muốn sửa</param>
        /// <returns>ID tài sản muốn sửa</returns>
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
        /// Xóa nhiều tài sản theo ID
        /// </summary>
        /// <param name="listAssetId">Danh sách ID tài sản cần xóa</param>
        /// <returns>StatusCode 200</returns>
        /// Created by: DTQUOC (12/6/2023)
        public int DeleteMultipleAssetById(List<Guid> listAssetId);


        /// <summary>
        /// Lấy mã tài sản lớn nhất + 1
        /// </summary>
        /// <returns>Mã tài sản lớn nhất + 1</returns>
        /// Created by: DTQUOC (12/6/2023)
        public string GetMaxAssetCode();

        /// <summary>
        /// Lấy danh sách tài sản theo bộ lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <param name="departmentId">ID phòng ban</param>
        /// <param name="assetTypeId">ID loại tài sản</param>
        /// <param name="limit">Số bản ghi cần lấy</param>
        /// <param name="offset">Bản ghi bắt đầu lấy</param>
        /// <returns>Danh sách tài sản thỏa mãn</returns>
        /// Created by: DTQUOC (12/6/2023)
        public PagingResult GetAssetByFilterAndPaging(string? keyFilter, Guid? departmentId, Guid? assetTypeId, int? pageIndex, int? pageNum);

        public PagingResult AssetData(string? keyWord, Guid? departmentId, Guid? assetTypeId);
        /// <summary>
        /// Kiểm tra mã trùng
        /// </summary>
        /// <param name="assetCode">Mã tài sản cần kiểm tra</param>
        /// <returns>
        ///     true: trùng
        ///     false: không trùng
        /// </returns>
        /// Created by: DTQUOC (12/6/2023)
        public bool CheckDuplicateAssetCode( Guid assetId, string assetCode);


        public MemoryStream ExportAssetData(List<Asset> listRecord);


    }

}
