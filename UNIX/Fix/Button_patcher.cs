using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIX_Fixer
{
    public class Button_patcher
    {
        public static int UseType;
        public static bool Button_fixer()
        {
            UseType = UseType + 1;

            if (UseType == 1)
            {
                return true;
            }

            if (UseType == 2)
            {
                UseType = 0;
            }

            return false;
        }
    }
}
