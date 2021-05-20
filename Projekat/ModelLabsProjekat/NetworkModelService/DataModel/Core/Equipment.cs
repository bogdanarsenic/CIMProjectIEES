using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
	public class Equipment : PowerSystemResource
	{
        private bool aggregate;
        private bool normallyInService;

        public bool NormallyInService
        {
            get
            {
                return normallyInService;
            }

            set
            {
                normallyInService = value;
            }
        }

        public bool Aggregate
        {
            get
            {
                return aggregate;
            }

            set
            {
                aggregate = value;
            }
        }

        public Equipment(long globalId) : base(globalId)
        {
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Equipment x = (Equipment)obj;
                return ((x.normallyInService == this.normallyInService) &&
                        (x.aggregate == this.aggregate));
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
                case ModelCode.EQUIPMENT_AGGR:
                case ModelCode.EQUIPMENT_NORMINSERV:

                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.EQUIPMENT_NORMINSERV:
                    property.SetValue(normallyInService);
                    break;

                case ModelCode.EQUIPMENT_AGGR:
                    property.SetValue(aggregate);
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
                case ModelCode.EQUIPMENT_AGGR:
                    aggregate = property.AsBool();
                    break;

                case ModelCode.EQUIPMENT_NORMINSERV:
                    normallyInService = property.AsBool();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation
    }
}
