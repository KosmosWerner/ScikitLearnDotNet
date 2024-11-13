using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Nodes
{
    public class NodeAttribute
    {
        public NodeAttribute()
        {
            Return = typeof(void);
            Name = string.Empty;
        }

        public Type Return { get; set; }
        public string Name { get; set; }
        public bool IsValid => Return != typeof(void) && Name != string.Empty;
    }
}
