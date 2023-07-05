using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO
{
    public class ValidateResult
    {
        /// <summary>
        /// Trạng thái sau khi validate
        /// </summary>
        /// <returns>
        ///     true: thành công
        ///     false: lỗi
        /// </returns>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Thông tin trả về
        /// </summary>
        public List<string> Data { get; set; }
    }
}
