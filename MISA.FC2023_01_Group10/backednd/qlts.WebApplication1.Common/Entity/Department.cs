using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity
{
    /// <summary>
    /// Thuộc tính của phòng ban
    /// Author: DTQUOC (9/6/2023)
    /// </summary>
    public class Department : BaseEntity
    {
        #region Property
        // ID phòng ban
        public Guid DepartmentId { get; set; }

        // Mã phòng ban
        public string DepartmentCode { get; set; }

        // Tên phòng ban
        public string DepartmentName { get; set; }

        #endregion
    }
}
