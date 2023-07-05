using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum
{
    /// <summary>
    /// Mã lỗi
    /// Author: DTQUOC (9/6/2023)
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Lỗi khi gặp exception
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Lỗi khi validate dữ liệu
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        InvaliData = 2,

        /// <summary>
        /// Lỗi khi mã tài sản bị trùng
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        DuplicateCode = 3,

        /// <summary>
        /// Lỗi khi thêm mới bản ghi
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        InsertError = 4,

        /// <summary>
        /// Lỗi khi update dữ liệu bản ghi
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        UpdateError = 5,

        /// <summary>
        /// Lỗi khi xóa bản ghi
        /// Author: DTQUOC (9/6/2023)
        /// </summary>
        DeleteError = 6,

        GetDetail = 7,

    }
}
