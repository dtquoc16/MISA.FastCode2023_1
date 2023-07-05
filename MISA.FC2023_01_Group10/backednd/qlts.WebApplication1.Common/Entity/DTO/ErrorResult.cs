using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO
{
    /// <summary>
    /// Danh sách các lỗi
    /// Author: DTQUOC (9/6/2023)
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Mã lỗi
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Message trả về cho dev
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Message trả về cho người dùng
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông tin chi tiết về lỗi
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        public object MoreInfo { get; set; }

        /// <summary>
        /// TraceID
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        public string TraceId { get; set; }
    }
}
