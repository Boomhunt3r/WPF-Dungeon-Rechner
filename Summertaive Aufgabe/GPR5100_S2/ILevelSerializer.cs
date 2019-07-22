using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPR5100_S2
{
    public interface ILevelSerializer
    {
        void Serialize(Level _level, string _path);

        Level Deserialize(string _path);
    }
}
