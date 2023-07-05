using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity
{
    /// <summary>
    /// Thuộc tính của loại tài sản
    /// Author: DTQUOC (9/6/2023)
    /// </summary>
    public class AssetType : BaseEntity
    {
        #region Property
        // ID loại tài sản
        public Guid AssetTypeId { get; set; }

        // Mã loại tài sản
        public string AssetTypeCode { get; set; }

        // Tên loại tài sản
        public string AssetTypeName { get; set; }

        // Số năm sử dụng
        public int LifeTime { get; set; }

        // Tỉ lệ hao mòn
        public float PercenAtrophy { get; set; }

        #endregion
    }
}
