using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.DL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Trả về danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: DTQUOC (5/6/2023)
        public IEnumerable<T> GetAllRecords();

        /// <summary>
        /// Lấy thông tin 1 tài sản theo ID
        /// </summary>
        /// <param name="recordId">ID tài sản muốn lấy thông tin</param>
        /// <returns>Thông tin tài sản</returns>
        /// Created by: DTQUOC (5/6/2023)
        public T GetRecordById(Guid recordId);

    }
}
