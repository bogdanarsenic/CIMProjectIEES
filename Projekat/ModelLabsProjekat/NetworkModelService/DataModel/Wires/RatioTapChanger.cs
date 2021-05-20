using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class RatioTapChanger:TapChanger
    {
        private float stepVoltageInc;
        private TransformerControlMode controlMode;
        private long transformers = 0;

        public float StepVoltageInc
        {
            get
            {
                return stepVoltageInc;
            }

            set
            {
                stepVoltageInc = value;
            }
        }

        public TransformerControlMode ControlMode
        {
            get
            {
                return controlMode;
            }

            set
            {
                controlMode = value;
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

        public RatioTapChanger(long globalId)
			: base(globalId)
		{
        }

       

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                RatioTapChanger rtc = (RatioTapChanger)obj;
                return (rtc.stepVoltageInc == this.stepVoltageInc &&
                        rtc.controlMode == this.controlMode &&
                        rtc.transformers == this.transformers);
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

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.RATTAPCHANGER_STVOLTINC:
                case ModelCode.RATTAPCHANGER_TRANSEND:
                case ModelCode.RATTAPCHANGER_CONTMODE:

                    return true;
                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.RATTAPCHANGER_STVOLTINC:
                    property.SetValue(stepVoltageInc);
                    break;

                case ModelCode.RATTAPCHANGER_TRANSEND:
                    property.SetValue(transformers);
                    break;

                case ModelCode.RATTAPCHANGER_CONTMODE:
                    property.SetValue((short)controlMode);
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
                case ModelCode.RATTAPCHANGER_STVOLTINC:
                    stepVoltageInc = property.AsFloat();
                    break;

                case ModelCode.RATTAPCHANGER_TRANSEND:
                    transformers=property.AsReference();
                    break;

                case ModelCode.RATTAPCHANGER_CONTMODE:
                    controlMode = (TransformerControlMode)property.AsEnum();
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
            if (transformers != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            {
                references[ModelCode.RATTAPCHANGER_TRANSEND] = new List<long>();
                references[ModelCode.RATTAPCHANGER_TRANSEND].Add(transformers);
            }

            base.GetReferences(references, refType);
        }


        #endregion IReference implementation
    }
}
