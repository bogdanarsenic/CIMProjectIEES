using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal:IdentifiedObject
    {
        private bool connected;
        private PhaseCode phases;
        private int seqNum;
        private long connectivityNode = 0;
        private long condeq = 0;
        private List<long> endtransformers = new List<long>();

        public Terminal(long globalId) : base(globalId) 
		{
        }

        public bool Connected
        {
            get
            {
                return connected;
            }

            set
            {
                connected = value;
            }
        }

        public PhaseCode Phases
        {
            get
            {
                return phases;
            }

            set
            {
                phases = value;
            }
        }

        public int SeqNum
        {
            get
            {
                return seqNum;
            }

            set
            {
                seqNum = value;
            }
        }

        public long ConnectivityNode
        {
            get
            {
                return connectivityNode;
            }

            set
            {
                connectivityNode = value;
            }
        }

        public long Condeq
        {
            get
            {
                return condeq;
            }

            set
            {
                condeq = value;
            }
        }


        public List<long> Endtransformers
        {
            get
            {
                return endtransformers;
            }

            set
            {
                endtransformers = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal t = (Terminal)obj;
                return (t.condeq == this.condeq &&
                        t.connected==this.connected &&
                        t.seqNum==this.seqNum &&
                        t.phases==this.phases &&
                        t.connectivityNode==this.connectivityNode &&
                        CompareHelper.CompareLists(t.endtransformers, this.endtransformers, true));
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
                case ModelCode.TERMINAL_CONN:
                case ModelCode.TERMINAL_PHASE:
                case ModelCode.TERMINAL_SEQNUM:
                case ModelCode.TERMINAL_CONDEQ:
                case ModelCode.TERMINAL_CONNECTNODE:
                case ModelCode.TERMINAL_TRANSEND:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.TERMINAL_CONN:
                    prop.SetValue(connected);
                    break;

                case ModelCode.TERMINAL_CONDEQ:
                    prop.SetValue(condeq);
                    break;

                case ModelCode.TERMINAL_CONNECTNODE:
                    prop.SetValue(connectivityNode);
                    break;

                case ModelCode.TERMINAL_PHASE:
                    prop.SetValue((short)phases);
                    break;

                case ModelCode.TERMINAL_SEQNUM:
                    prop.SetValue(seqNum);
                    break;

                case ModelCode.TERMINAL_TRANSEND:
                    prop.SetValue(endtransformers);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_SEQNUM:
                    seqNum = property.AsInt();
                    break;

                case ModelCode.TERMINAL_PHASE:
                    phases = (PhaseCode)property.AsEnum();
                    break;

                case ModelCode.TERMINAL_CONN:
                    connected = property.AsBool();
                    break;

                case ModelCode.TERMINAL_CONDEQ:
                    condeq = property.AsReference();
                    break;

                case ModelCode.TERMINAL_CONNECTNODE:
                    connectivityNode = property.AsReference();
                    break;

                //case ModelCode.TERMINAL_TRANSEND:
                //    endtransformers = property.AsReferences();
                //    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return ((endtransformers.Count > 0) || base.IsReferenced);
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (endtransformers != null && endtransformers.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_TRANSEND] = endtransformers.GetRange(0, endtransformers.Count);
            }

            if (connectivityNode != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CONNECTNODE] = new List<long>();
                references[ModelCode.TERMINAL_CONNECTNODE].Add(connectivityNode);
            }

            if (condeq != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CONDEQ] = new List<long>();
                references[ModelCode.TERMINAL_CONDEQ].Add(condeq);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TRANSFORMEREND_TERMINAL:
                    endtransformers.Add(globalId);
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
                case ModelCode.TRANSFORMEREND_TERMINAL:

                    if (endtransformers.Contains(globalId))
                    {
                        endtransformers.Remove(globalId);
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

        #endregion IReference implementation
    }
}
