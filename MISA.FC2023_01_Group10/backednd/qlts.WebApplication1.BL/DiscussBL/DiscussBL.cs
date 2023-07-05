using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Resource;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.DiscussDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL.DiscussBL
{
    public class DiscussBL : BaseBL<Discuss>, IDiscussBL
    {
        #region Field

        private IDiscussDL _discussDL;

        #endregion


        #region Contrustor

        public DiscussBL(IDiscussDL discussDL) : base(discussDL)
        {
            _discussDL = discussDL;
        }

        #endregion

        /// <summary>
        /// API Thêm mới 1 tài sản
        /// </summary>
        /// <param name="asset">Đối tượng tài sản cần thêm mới</param>
        /// <returns>ID của tài sản vừa thêm mới</returns>
        /// Created by: DTQUOC (6/6/2023)
        public Response InsertDiscuss(Discuss discuss)
        {
            

            Response res = _discussDL.InsertDiscuss(discuss);
            return new Response
            {
                IsSuccess = true,
                NumberOfRecordAffect = res.NumberOfRecordAffect,
                IdRecord = res.IdRecord,
            };

        }

    }
}
