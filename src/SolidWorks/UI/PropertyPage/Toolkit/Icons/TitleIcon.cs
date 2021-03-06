﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://xcad.xarial.com/license/
//*********************************************************************

using System.Collections.Generic;
using System.Drawing;
using Xarial.XCad.SolidWorks.Base;
using Xarial.XCad.UI;

namespace Xarial.XCad.SolidWorks.UI.PropertyPage.Toolkit.Icons
{
    internal class TitleIcon : IIcon
    {
        internal IXImage Icon { get; private set; }

        public Color TransparencyKey
        {
            get
            {
                return Color.White;
            }
        }

        internal TitleIcon(IXImage icon)
        {
            Icon = icon;
        }

        public IEnumerable<IIconSpec> GetIconSizes()
        {
            yield return new IconSpec(Icon, new Size(22, 22));
        }
    }
}