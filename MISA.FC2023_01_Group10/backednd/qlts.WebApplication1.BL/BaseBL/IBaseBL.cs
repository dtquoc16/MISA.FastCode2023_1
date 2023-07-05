using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Trả về danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: DTQUOC (5/6/2023)
        public IEnumerable<T> GetAllRecords();

        /// <summary>
        /// Lấy thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordId">ID bản ghi muốn lấy thông tin</param>
        /// <returns>Thông tin bản ghi</returns>
        /// Created by: DTQUOC (5/6/2023)
        public T GetRecordById(Guid recordId);
    }
}
