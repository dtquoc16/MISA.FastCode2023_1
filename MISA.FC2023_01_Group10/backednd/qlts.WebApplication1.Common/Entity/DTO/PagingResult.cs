using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO
{
    public class PagingResult
    {
        /// <summary>
        /// Danh sách tài sản
        /// </summary>
        public List<Asset> ListAsset { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public long TotalRecord { get; set; }

        public long Quantity { get; set; }

        public long Cost { get; set; }

        public long PercenAccumulated { get; set; }

        public long PercenAtrophyValue { get; set; }

        public long Value { get; set; }
    }
}
