using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;


namespace FTN.Services.NetworkModelService.DataModel.Wires
{
	public class PowerTransformer : ConductingEquipment
	{
        private string vectorGroup;
		private List<long> transformerends = new List<long>();

		public PowerTransformer(long globalId)
			: base(globalId)
		{
		}


        public string VectorGroup
        {
            get
            {
                return vectorGroup;
            }

            set
            {
                vectorGroup = value;
            }
        }

        public List<long> Transformerends
        {
            get
            {
                return transformerends;
            }

            set
            {
                transformerends = value;
            }
        }


        public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				PowerTransformer pt = (PowerTransformer)obj;
                return (pt.vectorGroup == this.vectorGroup &&
                        CompareHelper.CompareLists(pt.transformerends, this.transformerends, true));
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
				case ModelCode.POWERTR_VECTGR:
				case ModelCode.POWERTR_POWTRE:				
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{

				case ModelCode.POWERTR_VECTGR:
					prop.SetValue(vectorGroup);
					break;				

				case ModelCode.POWERTR_POWTRE:
					prop.SetValue(transformerends);
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
				case ModelCode.POWERTR_VECTGR:
					vectorGroup = property.AsString();
					break;

				//case ModelCode.POWERTR_POWTRE:					
				//	transformerends = property.AsReferences();
				//	break;

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
				return ((transformerends.Count > 0) || base.IsReferenced);
			}
		}

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			if (transformerends!= null && transformerends.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
			{
				references[ModelCode.POWERTR_POWTRE] = transformerends.GetRange(0, transformerends.Count);
			}

            base.GetReferences(references, refType);
		}

		public override void AddReference(ModelCode referenceId, long globalId)
		{
			switch (referenceId)
			{
				case ModelCode.POWERTE_POWERTR:
					transformerends.Add(globalId);
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
				case ModelCode.POWERTE_POWERTR:

					if (transformerends.Contains(globalId))
					{
						transformerends.Remove(globalId);
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
