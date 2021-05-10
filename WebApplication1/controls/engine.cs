using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.controls
{
    public static class eEngine
    {
        static RegisterControl registerControl = null;
        static LoginControl loginControl = null;

        public static RegisterControl GetRegisterControl()
        {
            if(registerControl == null)
            {
                registerControl = new RegisterControl();
            }
            return registerControl;
        }

        // todo GetLoginControl
    }
}
