using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.DepartmentDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL.DepartmentBL
{
    public class DepartmentBL : BaseBL<Department>, IDepartmentBL
    {
        #region Field

        private IDepartmentDL _departmentDL;

        #endregion

        #region Constructor

        public DepartmentBL (IDepartmentDL departmentDL) : base (departmentDL)
        {
            _departmentDL= departmentDL;
        }

        #endregion
    }
}
