using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class TapChanger:PowerSystemResource
    {
        private int highStep;
        private float initialDelay;
        private int lowStep;
        private bool itcFlag;
        private int neutralStep;
        private float neutralU;
        private int normalStep;
        private bool regulationStatus;
        private float subsequentDelay;

        public int HighStep
        {
            get
            {
                return highStep;
            }

            set
            {
                highStep = value;
            }
        }

        public float InitialDelay
        {
            get
            {
                return initialDelay;
            }

            set
            {
                initialDelay = value;
            }
        }

        public int LowStep
        {
            get
            {
                return lowStep;
            }

            set
            {
                lowStep = value;
            }
        }

        public bool ItcFlag
        {
            get
            {
                return itcFlag;
            }

            set
            {
                itcFlag = value;
            }
        }

        public int NeutralStep
        {
            get
            {
                return neutralStep;
            }

            set
            {
                neutralStep = value;
            }
        }

        public float NeutralU
        {
            get
            {
                return neutralU;
            }

            set
            {
                neutralU = value;
            }
        }

        public int NormalStep
        {
            get
            {
                return normalStep;
            }

            set
            {
                normalStep = value;
            }
        }

        public bool RegulationStatus
        {
            get
            {
                return regulationStatus;
            }

            set
            {
                regulationStatus = value;
            }
        }

        public float SubsequentDelay
        {
            get
            {
                return subsequentDelay;
            }

            set
            {
                subsequentDelay = value;
            }
        }

        public TapChanger(long globalId) : base(globalId) 
		{
        }
        
        

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                TapChanger tc = (TapChanger)obj;
                return ((tc.highStep == this.highStep) &&
                        (tc.initialDelay == this.initialDelay) && 
                        (tc.lowStep==this.lowStep) && (tc.itcFlag==this.itcFlag)
                        && (tc.neutralStep==this.neutralStep)&& (tc.neutralU==this.neutralU)
                        && (tc.normalStep==this.normalStep)&& (tc.regulationStatus=this.regulationStatus)
                        && (tc.subsequentDelay==this.subsequentDelay));
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
                case ModelCode.TAPCHANGER_HIGHST:
                case ModelCode.TAPCHANGER_INDELAY:
                case ModelCode.TAPCHANGER_LOWST:
                case ModelCode.TAPCHANGER_ITCFLAG:
                case ModelCode.TAPCHANGER_NEUTST:
                case ModelCode.TAPCHANGER_NEUTU:
                case ModelCode.TAPCHANGER_NORMST:
                case ModelCode.TAPCHANGER_REGST:
                case ModelCode.TAPCHANGER_SUBDELAY:


                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TAPCHANGER_HIGHST:
                    property.SetValue(highStep);
                    break;

                case ModelCode.TAPCHANGER_INDELAY:
                    property.SetValue(initialDelay);
                    break;

                case ModelCode.TAPCHANGER_ITCFLAG:
                    property.SetValue(itcFlag);
                    break;

                case ModelCode.TAPCHANGER_LOWST:
                    property.SetValue(lowStep);
                    break;

                case ModelCode.TAPCHANGER_NEUTST:
                    property.SetValue(neutralStep);
                    break;

                case ModelCode.TAPCHANGER_NEUTU:
                    property.SetValue(neutralU);
                    break;

                case ModelCode.TAPCHANGER_NORMST:
                    property.SetValue(normalStep);
                    break;

                case ModelCode.TAPCHANGER_REGST:
                    property.SetValue(regulationStatus);
                    break;

                case ModelCode.TAPCHANGER_SUBDELAY:
                    property.SetValue(subsequentDelay);
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
                case ModelCode.TAPCHANGER_HIGHST:
                    highStep = property.AsInt();
                    break;

                case ModelCode.TAPCHANGER_INDELAY:
                    initialDelay = property.AsFloat();
                    break;

                case ModelCode.TAPCHANGER_ITCFLAG:
                    itcFlag = property.AsBool();
                    break;

                case ModelCode.TAPCHANGER_LOWST:
                    lowStep = property.AsInt();
                    break;

                case ModelCode.TAPCHANGER_NEUTST:
                    neutralStep = property.AsInt();
                    break;

                case ModelCode.TAPCHANGER_NEUTU:
                    neutralU = property.AsFloat();
                    break;

                case ModelCode.TAPCHANGER_NORMST:
                    normalStep = property.AsInt();
                    break;

                case ModelCode.TAPCHANGER_REGST:
                    regulationStatus = property.AsBool();
                    break;

                case ModelCode.TAPCHANGER_SUBDELAY:
                    subsequentDelay = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation
    }
}
