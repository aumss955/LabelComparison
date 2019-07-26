using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceabilityNew
{
    class User
    {
        public string operator_id { get; set; }

        public User(string id)
        {
            this.operator_id = id;
        }
    }
}
