﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logowanie
{
    class ranga
    {
       [Flags] public enum Ranga
        {
            User = 0,
            Moderator,
            Administrator = 99,
        }
    }
}
