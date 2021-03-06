﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://xcad.xarial.com/license/
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.UI.PropertyPage.Base;
using Xarial.XCad.UI.PropertyPage.Services;

namespace Xarial.XCad.UI.PropertyPage.Attributes
{
    /// <summary>
    /// Indicates that the state of this control depends on the <see cref="IMetadata"/>
    /// </summary>
    public interface IDependentOnMetadataAttribute : IAttribute
    {
        /// <summary>
        /// Metadata tags
        /// </summary>
        object[] Dependencies { get; }

        /// <summary>
        /// Dependency handler resolving the control state
        /// </summary>
        IMetadataDependencyHandler DependencyHandler { get; }
    }

    /// <inheritdoc/>
    public class DependentOnMetadataAttribute : Attribute, IDependentOnMetadataAttribute
    {
        /// <inheritdoc/>
        public object[] Dependencies { get; }

        /// <inheritdoc/>
        public IMetadataDependencyHandler DependencyHandler { get; }

        public DependentOnMetadataAttribute(Type dependencyHandler, params object[] dependencies)
        {
            if (!typeof(IMetadataDependencyHandler).IsAssignableFrom(dependencyHandler))
            {
                throw new InvalidCastException($"{dependencyHandler.FullName} must be assignable from {typeof(IMetadataDependencyHandler).FullName}");
            }

            DependencyHandler = (IMetadataDependencyHandler)Activator.CreateInstance(dependencyHandler);

            Dependencies = dependencies;
        }
    }
}
