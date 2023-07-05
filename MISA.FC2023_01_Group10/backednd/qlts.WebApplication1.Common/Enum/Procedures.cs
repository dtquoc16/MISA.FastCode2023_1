using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum
{
    public class Procedures
    {
        /// <summary>
        /// Procedure ở BaseDL
        /// </summary>
        /// Created by: DTQUOC (5/6/2023)
        
        // procedure lấy tất cả bản ghi
        public static string GET_ALL = "Proc_{0}_GetAll";

        //procedure lấy 1 bản ghi theo ID
        public static string GET_BY_ID = "Proc_{0}_GetByID";

        public static string INSERT_RECORD = "Proc_{0}_Insert";
        /// <summary>
        /// Procedure ở AssetDL
        /// </summary>
        /// Created by: DTQUOC (5/6/2023)

        // procedure thêm mới tài sản
        public static string ASSET_ADD = "Proc_Asset_Add";

        // procedurre lấy mã tài sản lớn nhất + 1
        public static string ASSET_GET_CODEMAX = "Proc_Asset_GetCodeMax";

        // procedurre sưả tài sản
        public static string ASSET_EDIT = "Proc_Asset_Edit";

        // procedurre xóa 1 tài sản theo ID
        public static string ASSET_DELETE = "Proc_Asset_Delete";

        // procedurre xóa nhiều tài sản
        public static string ASSET_DELETE_MULTI = "Proc_Asset_DeleteMulti";

        // procedurre kiểm tra mã tài sản trùng
        public static string ASSET_CHECK_DUPLICATE_CODE = "Proc_Asset_CheckDuplicateCode";

        // procedure filter
        public static string ASSET_FILTER = "Proc_Filter";

        public static string EXPORT_EXCEL = "Proc_Export_Excel";

        public static string DISCUSS_ADD = "Proc_Discuss_Add";

        public static string ANSWER_ADD = "Proc_Answer_Add";


    }
}
