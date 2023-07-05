using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using MySqlConnector;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.DL.AnswerDL
{
    public class AnswerDL : BaseDL<Answer>, IAnswerDL
    {
        public Response InsertAnswer(Answer answer)
        {


            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.ANSWER_ADD;

            // Chuẩn bị tham số đầu vào
            var newAssetId = Guid.NewGuid();
            var parameters = answer;
            parameters.DiscussId = newAssetId;
            parameters.CreatedBy = "DTQUOC";
            parameters.CreatedDate = DateTime.Now;

            int numberOfRecordAffect = 0;

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                numberOfRecordAffect = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            }

            //Xử lý kết quả trả về
            return new Response
            {
                IdRecord = newAssetId,
                NumberOfRecordAffect = numberOfRecordAffect,
            };
        }
    }
}
