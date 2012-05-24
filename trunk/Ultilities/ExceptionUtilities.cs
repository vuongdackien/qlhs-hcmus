using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public static class ExceptionUtilities
    {
        public static void Throw(string msg)
        {
            throw new Exception(msg);
        }

        public static void ThrowMsgBox(string msg)
        {
            Utilities.MessageboxUtilities.MessageError(msg);
        }
    }
}
