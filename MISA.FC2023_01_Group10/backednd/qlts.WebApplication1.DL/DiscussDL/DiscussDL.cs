using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.DL.DiscussDL
{
    public class DiscussDL : BaseDL<Discuss>, IDiscussDL
    {
        /// <summary>
        /// API Thêm mới 1 tài sản
        /// </summary>
        /// <param name="asset">Đối tượng tài sản cần thêm mới</param>
        /// <returns>ID của tài sản vừa thêm mới</returns>
        /// Created by: DTQUOC (5/6/2023)
        public Response InsertDiscuss(Discuss discuss)
        {


            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedures.DISCUSS_ADD;

            // Chuẩn bị tham số đầu vào
            var newAssetId = Guid.NewGuid();
            var parameters = discuss;
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
