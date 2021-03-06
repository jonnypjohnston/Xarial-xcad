﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://xcad.xarial.com/license/
//*********************************************************************

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xarial.XCad.Geometry;
using Xarial.XCad.Geometry.Structures;
using Xarial.XCad.Geometry.Surfaces;
using Xarial.XCad.SolidWorks.Documents;
using Xarial.XCad.SolidWorks.Geometry.Surfaces;
using Xarial.XCad.SolidWorks.Utils;
using Xarial.XCad.Utils.Reflection;

namespace Xarial.XCad.SolidWorks.Geometry
{
    public interface ISwFace : ISwEntity, IXFace 
    {
        IFace2 Face { get; }
        new ISwSurface Definition { get; }
    }

    internal class SwFace : SwEntity, ISwFace
    {
        IXSurface IXFace.Definition => Definition;

        public IFace2 Face { get; }

        public SwFace(IFace2 face, ISwDocument doc) : base(face as IEntity, doc)
        {
            Face = face;
        }

        public override ISwBody Body => (SwBody)FromDispatch(Face.GetBody());

        public override IEnumerable<ISwEntity> AdjacentEntities 
        {
            get 
            {
                foreach (IEdge edge in (Face.GetEdges() as object[]).ValueOrEmpty())
                {
                    yield return FromDispatch<SwEdge>(edge);
                }
            }
        }

        public double Area => Face.GetArea();

        private IComponent2 Component => (Face as IEntity).GetComponent() as IComponent2;

        public Color? Color 
        {
            get => SwColorHelper.GetColor(Face, Component, 
                (o, c) => Face.GetMaterialPropertyValues2((int)o, c) as double[]);
            set => SwColorHelper.SetColor(Face, value, Component,
                (m, o, c) => Face.SetMaterialPropertyValues2(m, (int)o, c),
                (o, c) => Face.RemoveMaterialProperty2((int)o, c));
        }

        public ISwSurface Definition => SwSelObject.FromDispatch<SwSurface>(Face.IGetSurface());
    }

    public interface ISwPlanarFace : ISwFace, IXPlanarFace
    {
        new ISwPlanarSurface Definition { get; }
    }

    internal class SwPlanarFace : SwFace, ISwPlanarFace
    {
        IXPlanarSurface IXPlanarFace.Definition => Definition;

        public SwPlanarFace(IFace2 face, ISwDocument doc) : base(face, doc)
        {
        }

        public new ISwPlanarSurface Definition => SwSelObject.FromDispatch<SwPlanarSurface>(Face.IGetSurface());
    }

    public interface ISwCylindricalFace : ISwFace, IXCylindricalFace
    {
        new ISwCylindricalSurface Definition { get; }
    }

    internal class SwCylindricalFace : SwFace, ISwCylindricalFace
    {
        IXCylindricalSurface IXCylindricalFace.Definition => Definition;

        public SwCylindricalFace(IFace2 face, ISwDocument doc) : base(face, doc)
        {
        }

        public new ISwCylindricalSurface Definition => SwSelObject.FromDispatch<SwCylindricalSurface>(Face.IGetSurface());
    }
}
