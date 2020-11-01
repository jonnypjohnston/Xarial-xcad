﻿using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Geometry.Curves;
using Xarial.XCad.Geometry.Structures;
using Xarial.XCad.SolidWorks.Geometry.Exceptions;

namespace Xarial.XCad.SolidWorks.Geometry.Curves
{
    public class SwLineCurve : SwCurve, IXLineCurve
    {
        internal SwLineCurve(IModeler modeler, ICurve curve, bool isCreated) : base(modeler, curve, isCreated)
        {
        }

        public Point StartCoordinate 
        {
            get 
            {
                if (IsCommitted)
                {
                    return StartPoint.Coordinate;
                }
                else 
                {
                    return m_Creator.CachedProperties.Get<Point>();
                }
            }
            set 
            {
                if (IsCommitted)
                {
                    throw new CommitedSegmentReadOnlyParameterException();
                }
                else
                {
                    m_Creator.CachedProperties.Set(value);
                }
            }
        }

        public Point EndCoordinate 
        {
            get
            {
                if (IsCommitted)
                {
                    return EndPoint.Coordinate;
                }
                else
                {
                    return m_Creator.CachedProperties.Get<Point>();
                }
            }
            set
            {
                if (IsCommitted)
                {
                    throw new Exception("Coordinate cannot be modified after entity is committed");
                }
                else
                {
                    m_Creator.CachedProperties.Set(value);
                }
            }
        }

        protected override ICurve[] Create()
        {
            var line = m_Modeler.CreateLine(StartCoordinate.ToArray(), (StartCoordinate - EndCoordinate).ToArray()) as ICurve;
            line = line.CreateTrimmedCurve2(StartCoordinate.X, StartCoordinate.Y, StartCoordinate.Z, EndCoordinate.X, EndCoordinate.Y, EndCoordinate.Z);

            if (line == null)
            {
                throw new NullReferenceException("Failed to create line");
            }

            return new ICurve[] { line };
        }
    }
}