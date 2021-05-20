using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class PowerTransformerEnd:TransformerEnd
    {

        private float b;
        private float b0;
        private WindingConnection connectionKind;
        private float g;
        private float g0;
        private int phaseAngle;
        private float r;
        private float r0;
        private float ratedS;
        private float ratedU;
        private float x;
        private float x0;

        private long transformers = 0;

        public float B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;
            }
        }

        public float B0
        {
            get
            {
                return b0;
            }

            set
            {
                b0 = value;
            }
        }

        public WindingConnection ConnectionKind
        {
            get
            {
                return connectionKind;
            }

            set
            {
                connectionKind = value;
            }
        }

        public float G
        {
            get
            {
                return g;
            }

            set
            {
                g = value;
            }
        }

        public float G0
        {
            get
            {
                return g0;
            }

            set
            {
                g0 = value;
            }
        }

        public int PhaseAngle
        {
            get
            {
                return phaseAngle;
            }

            set
            {
                phaseAngle = value;
            }
        }

        public float R
        {
            get
            {
                return r;
            }

            set
            {
                r = value;
            }
        }

        public float R0
        {
            get
            {
                return r0;
            }

            set
            {
                r0 = value;
            }
        }

        public float RatedS
        {
            get
            {
                return ratedS;
            }

            set
            {
                ratedS = value;
            }
        }

        public float RatedU
        {
            get
            {
                return ratedU;
            }

            set
            {
                ratedU = value;
            }
        }

        public float X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public float X0
        {
            get
            {
                return x0;
            }

            set
            {
                x0 = value;
            }
        }

        public long Transformers
        {
            get
            {
                return transformers;
            }

            set
            {
                transformers = value;
            }
        }

        public PowerTransformerEnd(long globalId)
			: base(globalId)
		{
        }

        

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                PowerTransformerEnd pte = (PowerTransformerEnd)obj;
                return (pte.b == this.b && pte.b0 == this.b0 && pte.connectionKind == connectionKind
                    && pte.g == this.g && pte.g0 == this.g0 && pte.phaseAngle == this.phaseAngle
                    && pte.r == this.r && pte.r0 == this.r0 && pte.ratedS == this.ratedS
                    && pte.ratedU == this.ratedU && pte.x == this.x && pte.x0 == this.x0 
                    && pte.transformers==this.transformers);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.POWERTE_B:
                case ModelCode.POWERTE_B0:
                case ModelCode.POWERTE_CONNKIND:
                case ModelCode.POWERTE_G:
                case ModelCode.POWERTE_G0:
                case ModelCode.POWERTE_PHANCL:
                case ModelCode.POWERTE_R:
                case ModelCode.POWERTE_R0:
                case ModelCode.POWERTE_RATEDS:
                case ModelCode.POWERTE_RATEDU:
                case ModelCode.POWERTE_X:
                case ModelCode.POWERTE_X0:
                case ModelCode.POWERTE_POWERTR:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.POWERTE_B:
                    property.SetValue(b);
                    break;

                case ModelCode.POWERTE_B0:
                    property.SetValue(b0);
                    break;

                case ModelCode.POWERTE_CONNKIND:
                    property.SetValue((short)connectionKind);
                    break;

                case ModelCode.POWERTE_G:
                    property.SetValue(g);
                    break;

                case ModelCode.POWERTE_G0:
                    property.SetValue(g0);
                    break;

                case ModelCode.POWERTE_PHANCL:
                    property.SetValue(phaseAngle);
                    break;

                case ModelCode.POWERTE_R:
                    property.SetValue(r);
                    break;

                case ModelCode.POWERTE_R0:
                    property.SetValue(r0);
                    break;

                case ModelCode.POWERTE_RATEDS:
                    property.SetValue(ratedS);
                    break;

                case ModelCode.POWERTE_RATEDU:
                    property.SetValue(ratedU);
                    break;

                case ModelCode.POWERTE_X:
                    property.SetValue(x);
                    break;

                case ModelCode.POWERTE_X0:
                    property.SetValue(x0);
                    break;

                case ModelCode.POWERTE_POWERTR:
                    property.SetValue(transformers);
                    break;


                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.POWERTE_B:
                    b = property.AsFloat();
                    break;

                case ModelCode.POWERTE_B0:
                    b0 = property.AsFloat();
                    break;

                case ModelCode.POWERTE_CONNKIND:
                    connectionKind = (WindingConnection)property.AsEnum();
                    break;

                case ModelCode.POWERTE_G:
                    g = property.AsFloat();
                    break;

                case ModelCode.POWERTE_G0:
                    g0 = property.AsFloat();
                    break;

                case ModelCode.POWERTE_PHANCL:
                    phaseAngle = property.AsInt();
                    break;

                case ModelCode.POWERTE_R:
                    r = property.AsFloat();
                    break;

                case ModelCode.POWERTE_R0:
                    r0 = property.AsFloat();
                    break;

                case ModelCode.POWERTE_RATEDS:
                    ratedS = property.AsFloat();
                    break;

                case ModelCode.POWERTE_RATEDU:
                    ratedU = property.AsFloat();
                    break;

                case ModelCode.POWERTE_X:
                    x = property.AsFloat();
                    break;

                case ModelCode.POWERTE_X0:
                    x0 = property.AsFloat();
                    break;

                case ModelCode.POWERTE_POWERTR:
                    transformers = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {

            if (transformers != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.POWERTE_POWERTR] = new List<long>();
                references[ModelCode.POWERTE_POWERTR].Add(transformers);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}
