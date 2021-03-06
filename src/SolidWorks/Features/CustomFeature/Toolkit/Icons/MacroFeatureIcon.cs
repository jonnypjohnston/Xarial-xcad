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

namespace Xarial.XCad.SolidWorks.Features.CustomFeature.Toolkit.Icons
{
    internal class MacroFeatureIcon : IIcon
    {
        protected readonly string m_BaseName;
        protected readonly IXImage m_Icon;

        public Color TransparencyKey => Color.White;

        internal MacroFeatureIcon(IXImage icon, string baseName)
        {
            m_BaseName = baseName;
            m_Icon = icon;
        }

        public virtual IEnumerable<IIconSpec> GetIconSizes()
        {
            yield return new IconSpec(m_Icon, MacroFeatureIconInfo.Size, 0, m_BaseName);
        }
    }
}