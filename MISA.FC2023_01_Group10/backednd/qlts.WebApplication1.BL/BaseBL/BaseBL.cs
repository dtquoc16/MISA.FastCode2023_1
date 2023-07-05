using MISA.QLTS.DEMO.Web04.DTQUOC.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion


        #region Contrustor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        /// <summary>
        /// Trả về danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: DTQUOC (5/6/2023)
        public IEnumerable<T> GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }

        /// <summary>
        /// Lấy thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordId">ID bản ghi muốn lấy thông tin</param>
        /// <returns>Thông tin bản ghi</returns>
        /// Created by: DTQUOC (5/6/2023)
        public T GetRecordById(Guid recordId)
        {
            return _baseDL.GetRecordById(recordId);
            throw new NotImplementedException();
        }
    }
}
