using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
{
    interface Operations
    {
        void Open_door();
        void Close_door();
        void Open_window();
        void Close_window();
        void Light_on();
        void Light_off();
    }
}
