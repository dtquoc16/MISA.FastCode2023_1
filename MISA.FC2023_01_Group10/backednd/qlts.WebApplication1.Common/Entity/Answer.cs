using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity
{
    public class Answer : BaseEntity
    {
        public Guid AnswerId { get; set; }

        public Guid DiscussId { get; set; }

        public string NameAnswer { get; set; }

        public string ContentAnswer { get; set; }

        public DateTime TimeAnsver { get; set; }
    }
}
