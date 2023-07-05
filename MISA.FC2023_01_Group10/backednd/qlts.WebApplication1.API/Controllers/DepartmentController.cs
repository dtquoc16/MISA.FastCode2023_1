using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.DepartmentBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.API.Controllers
{
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        #region Field

        IDepartmentBL _departmentBL;

        #endregion

        #region Constructor

        public DepartmentController (IDepartmentBL departmentBL) : base(departmentBL)
        {
            _departmentBL = departmentBL;
        }
        #endregion
    }
}
