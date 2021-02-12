﻿using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Data.Enums;

namespace Xarial.XCad.Toolkit.Utils
{
    public static class AccessTypeHelper
    {
        public static bool GetIsWriting(AccessType_e type)
        {
            switch (type)
            {
                case AccessType_e.Write:
                    return true;

                case AccessType_e.Read:
                    return false;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}