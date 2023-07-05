using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO
{
    public class Response
    {
        /// <summary>
        /// Trạng thái của response
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Thông tin response trả về
        /// </summary>
        public List<string> Data { get; set; }

        /// <summary>
        /// Số bản ghi bị ảnh hưởng
        /// </summary>
        public int NumberOfRecordAffect { get; set; }

        /// <summary>
        /// ID bản ghi trả về
        /// </summary>
        public Guid IdRecord { get; set; }
    }
}
