using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity
{
    public class Discuss : BaseEntity
    {
        public Guid DiscussId { get; set; }

        public string Tittle { get; set; }

        public string NameUser { get; set; }

        public TypeQuestion TypeQuestion { get; set; }

        public string Content { get; set; }
    }
}
