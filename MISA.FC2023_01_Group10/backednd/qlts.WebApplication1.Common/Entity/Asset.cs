using System.ComponentModel.DataAnnotations;
namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity
{
    /// <summary>
    /// Thuộc tính của tài sản
    /// Author: DTQUOC (9/6/2023)
    /// </summary>
    public class Asset : BaseEntity
    {

        #region Property

        // ID tài sản
        public Guid AssetId { get; set; }

        // Mã tài sản
        [Required(ErrorMessage = "Mã tài sản không được để trống")]
        public string AssetCode { get; set; }


        // Tên tài sản
        [Required(ErrorMessage = "Tên tài sản không được để trống")]
        public string AssetName { get; set; }


        // Mã phòng ban

        public Guid DepartmentId { get; set; }
        public string? DepartmentCode { get; set; }

        // Tên phòng ban
        public string? DepartmentName { get; set; }

        public Guid AssetTypeId { get; set; }

        // Mã loại tài sản

        public string? AssetTypeCode { get; set; }

        // Tên loại tài sản
        public string? AssetTypeName { get; set; }

        // Số lượng
        public int Quantity { get; set; }

        // Nguyên giá
        public int Cost { get; set; }

        // Số năm sử dụng
        [Required(ErrorMessage = "Số năm sử dụng không được để trống")]
        public int LifeTime { get; set; }

        // Tỉ lệ hao mòn
        [Required(ErrorMessage = "Tỉ lệ hao mòn không được để trống")]
        public float PercenAtrophy { get; set; }

        // Năm theo dõi
        public int YearFollow { get; set; }

        // Ngày mua
        public DateTime PurchaseDate { get; set; }

        // Ngày bắt đầu sử dụng
        public DateTime UsingDate { get; set; }

       
        #endregion
    }
}
