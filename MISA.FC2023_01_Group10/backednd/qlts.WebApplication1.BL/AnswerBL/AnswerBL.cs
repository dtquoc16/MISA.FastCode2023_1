using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.AnswerDL;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.DiscussDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL.AnswerBL
{
    public class AnswerBL : BaseBL<Answer>, IAnswerBL
    {
        #region Field

        private IAnswerDL _answerDL;

        #endregion


        #region Contrustor

        public AnswerBL(IAnswerDL answerDL) : base(answerDL)
        {
            _answerDL = answerDL;
        }

        #endregion

        public Response InsertAnswer(Answer answer)
        {


            Response res = _answerDL.InsertAnswer(answer);
            return new Response
            {
                IsSuccess = true,
                NumberOfRecordAffect = res.NumberOfRecordAffect,
                IdRecord = res.IdRecord,
            };

        }
    }
}
