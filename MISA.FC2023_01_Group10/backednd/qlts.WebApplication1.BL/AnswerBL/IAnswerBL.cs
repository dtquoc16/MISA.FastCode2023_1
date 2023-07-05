using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL.AnswerBL
{
    public interface IAnswerBL : IBaseBL<Answer>
    {
        public Response InsertAnswer(Answer answer);
    }
}
