using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.DL.DiscussDL
{
    public interface IDiscussDL : IBaseDL<Discuss>
    {
        /// <summary>
        /// API Thêm mới 1 thảo luận
        /// </summary>
        /// <param name="discuss">Đối tượng tài sản cần thêm mới</param>
        /// <returns>
        ///     true: thành công
        ///     false: lỗi
        /// </returns>
        /// Created by: DTQUOC (6/6/2023)
        public Response InsertDiscuss(Discuss discuss);

    }
}
