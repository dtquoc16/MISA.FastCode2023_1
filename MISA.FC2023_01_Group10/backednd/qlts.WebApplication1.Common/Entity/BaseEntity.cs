using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity
{
    public class BaseEntity
    {
        #region Property

        // Thời gian tạo
        public DateTime? CreatedDate { get; set; }

        // Người tạo
        public String? CreatedBy { get; set; }

        // Thời gian sửa
        public DateTime? ModifiedDate { get; set; }

        public String? ModifiedBy { get; set; }

        #endregion
    }
}
