using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity.DTO;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using MySqlConnector;


namespace MISA.QLTS.DEMO.Web04.DTQUOC.DL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        
        /// <summary>
        /// Trả về danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: DTQUOC (5/6/2023)
        public IEnumerable<T> GetAllRecords()
        {

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedures.GET_ALL, typeof(T).Name);


            var records = new List<T>();

            // Khởi tạo kết nối DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                records = (List<T>)mySqlConnection.Query<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
            }

            // Xử lí kết quả trả vê
            return records;

        }
        
        /// <summary>
        /// Lấy thông tin 1 tài sản theo ID
        /// </summary>
        /// <param name="recordId">ID tài sản muốn lấy thông tin</param>
        /// <returns>Thông tin tài sản</returns>
        /// Created by: DTQUOC (5/6/2023)
        public T GetRecordById(Guid recordId)
        {
            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedures.GET_BY_ID, typeof(T).Name);

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"@{Regex.Replace(typeof(T).Name, "[A-Z]", "_$0").ToLower()[1..]}Id", recordId);

            // Khởi tạo kết nối đến DB
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.ConnectionString))
            {
                // Thực hiện gọi vào DB
                var record = mySqlConnection.QueryFirstOrDefault<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return record;
            }
        }

       

    }
}


