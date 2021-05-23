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
        static ResetPasswordControl resetControl = null;

        public static RegisterControl GetRegisterControl()
        {
            if(registerControl == null)
            {
                registerControl = new RegisterControl();
            }
            return registerControl;
        }
		
		public static LoginControl GetLoginControl()
        {
            if(loginControl == null)
            {
                loginControl = new LoginControl();
            }
            return loginControl;
        }
        public static ResetPasswordControl GetResetPasswordControl()
        {
            if (resetControl == null)
            {
                resetControl = new ResetPasswordControl();
            }
            return resetControl;
        }
    }
}
