﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://xcad.xarial.com/license/
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.UI
{
    /// <summary>
    /// Delegate of <see cref="IXCustomPanel{TControl}.ControlCreated"/> event
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    /// <param name="ctrl">Control</param>
    public delegate void ControlCreatedDelegate<TControl>(TControl ctrl);

    /// <summary>
    /// Represents the panel with custom User Control
    /// </summary>
    /// <typeparam name="TControl">Type of user control</typeparam>
    public interface IXCustomPanel<TControl>
    {
        /// <summary>
        /// Raised when control is created
        /// </summary>
        /// <remarks>Depending on a specific CAD system control might be destroyed and created when document hiding</remarks>
        event ControlCreatedDelegate<TControl> ControlCreated;

        /// <summary>
        /// Checks if this panel is active
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Returns the specific User Control of this panel
        /// </summary>
        TControl Control { get; }
        
        /// <summary>
        /// Closes current panel
        /// </summary>
        void Close();
    }
}
