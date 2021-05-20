using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class TransformerEnd : IdentifiedObject
    {

        private List<long> ratiotapchangers = new List<long>();
        private long terminals = 0;

       

        public long Terminals
        {
            get
            {
                return terminals;
            }

            set
            {
                terminals = value;
            }
        }

        public List<long> Ratiotapchangers
        {
            get
            {
                return ratiotapchangers;
            }

            set
            {
                ratiotapchangers = value;
            }
        }

        public TransformerEnd(long globalId) : base(globalId)
        {
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                TransformerEnd te = (TransformerEnd)obj;
                return (te.terminals == this.terminals &&
                        CompareHelper.CompareLists(te.ratiotapchangers, this.ratiotapchangers, true));
                
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



        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.TRANSFORMEREND_RATIOTAPCH:
                case ModelCode.TRANSFORMEREND_TERMINAL:
                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TRANSFORMEREND_RATIOTAPCH:
                    property.SetValue(ratiotapchangers);
                    break;

                case ModelCode.TRANSFORMEREND_TERMINAL:
                    property.SetValue(terminals);
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

                case ModelCode.TRANSFORMEREND_TERMINAL:
                    terminals = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        public override bool IsReferenced
        {
            get
            {
                return ((ratiotapchangers.Count > 0) || base.IsReferenced);
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (ratiotapchangers != null && ratiotapchangers.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.TRANSFORMEREND_RATIOTAPCH] = ratiotapchangers.GetRange(0, ratiotapchangers.Count);
            }

            if (terminals != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            {
                references[ModelCode.TRANSFORMEREND_TERMINAL] = new List<long>();
                references[ModelCode.TRANSFORMEREND_TERMINAL].Add(terminals);
            }
            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.RATTAPCHANGER_TRANSEND:
                    ratiotapchangers.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.RATTAPCHANGER_TRANSEND:

                    if (ratiotapchangers.Contains(globalId))
                    {
                        ratiotapchangers.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }
    }    
}
