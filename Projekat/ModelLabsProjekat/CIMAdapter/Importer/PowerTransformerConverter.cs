namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				if (cimIdentifiedObject.MRIDHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
				}
				if (cimIdentifiedObject.NameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
				}
				if (cimIdentifiedObject.AliasNameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_ALIASN, cimIdentifiedObject.AliasName));
				}
			}
		}

     

        public static void PopulateConnectivityNodeProperties(FTN.ConnectivityNode cimConnectivityNode, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConnectivityNode != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimConnectivityNode, rd);

				if (cimConnectivityNode.DescriptionHasValue)
				{
					rd.AddProperty(new Property(ModelCode.CONNECTNODE_DESC, cimConnectivityNode.Description));
				}
			}
		}

		public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimPowerSystemResource != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);

			}
		}

		public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimEquipment != null) && (rd != null))
			{
				PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);

				if (cimEquipment.AggregateHasValue)
				{
					rd.AddProperty(new Property(ModelCode.EQUIPMENT_AGGR, cimEquipment.Aggregate));
				}

                if (cimEquipment.NormallyInServiceHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_NORMINSERV, cimEquipment.NormallyInService));
                }
            }
		}

		public static void PopulateTerminalProperties(FTN.Terminal cimTerminal, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimTerminal != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTerminal, rd);

				if (cimTerminal.ConnectedHasValue)
				{
					rd.AddProperty(new Property(ModelCode.TERMINAL_CONN, cimTerminal.Connected));
				}
				if (cimTerminal.SequenceNumberHasValue)
				{
					rd.AddProperty(new Property(ModelCode.TERMINAL_SEQNUM, cimTerminal.SequenceNumber));
				}
               
                if (cimTerminal.PhasesHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TERMINAL_PHASE, (short)GetDMSPhaseCode(cimTerminal.Phases)));
                }

                if (cimTerminal.ConnectivityNodeHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConnectivityNode.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to ConnectivityNode: rdfID \"").Append(cimTerminal.ConnectivityNode.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONNECTNODE, gid));
                }

                if (cimTerminal.ConductingEquipmentHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConductingEquipment.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to ConductingEquipment: rdfID \"").Append(cimTerminal.ConductingEquipment.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONDEQ, gid));
                }
            }
		}

        public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConductingEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);

            }
        }

        public static void PopulateTapChangerProperties(FTN.TapChanger cimTapChanger, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTapChanger != null) && (rd != null))
            {
                PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimTapChanger, rd, importHelper, report);

                if (cimTapChanger.HighStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_HIGHST, cimTapChanger.HighStep));
                }

                if (cimTapChanger.InitialDelayHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_INDELAY, cimTapChanger.InitialDelay));
                }

                if (cimTapChanger.LowStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_LOWST, cimTapChanger.LowStep));
                }

                if (cimTapChanger.LtcFlagHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_ITCFLAG, cimTapChanger.LtcFlag));
                }

                if (cimTapChanger.NeutralStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_NEUTST, cimTapChanger.NeutralStep));
                }

                if (cimTapChanger.NeutralUHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_NEUTU, cimTapChanger.NeutralU));
                }

                if (cimTapChanger.NormalStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_NORMST, cimTapChanger.NormalStep));
                }

                if (cimTapChanger.RegulationStatusHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_REGST, cimTapChanger.RegulationStatus));
                }

                if (cimTapChanger.SubsequentDelayHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAPCHANGER_SUBDELAY, cimTapChanger.SubsequentDelay));
                }
            }
        }


        public static void PopulatePowerTransformerProperties(FTN.PowerTransformer cimPowerTransformer, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPowerTransformer != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimPowerTransformer, rd, importHelper, report);

                if (cimPowerTransformer.VectorGroupHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTR_VECTGR, cimPowerTransformer.VectorGroup));
                }
            }
        }


        public static void PopulateTransformerEndProperties(FTN.TransformerEnd cimTransformerEnd, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTransformerEnd != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTransformerEnd, rd);

                if (cimTransformerEnd.TerminalHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTransformerEnd.Terminal.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTransformerEnd.GetType().ToString()).Append(" rdfID = \"").Append(cimTransformerEnd.ID);
                        report.Report.Append("\" - Failed to set reference to Terminal: rdfID \"").Append(cimTransformerEnd.Terminal.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TRANSFORMEREND_TERMINAL, gid));
                }
            }
        }

        public static void PopulateRatioTapChangerProperties(FTN.RatioTapChanger cimRatioTapChanger, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimRatioTapChanger != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateTapChangerProperties(cimRatioTapChanger, rd, importHelper, report);

                if (cimRatioTapChanger.StepVoltageIncrementHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RATTAPCHANGER_STVOLTINC, cimRatioTapChanger.StepVoltageIncrement));
                }

                if (cimRatioTapChanger.TculControlModeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RATTAPCHANGER_CONTMODE, (short)GetDMSTransformerControlMode(cimRatioTapChanger.TculControlMode)));
                }

                if (cimRatioTapChanger.TransformerEndHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimRatioTapChanger.TransformerEnd.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimRatioTapChanger.GetType().ToString()).Append(" rdfID = \"").Append(cimRatioTapChanger.ID);
                        report.Report.Append("\" - Failed to set reference to TransformerEnd: rdfID \"").Append(cimRatioTapChanger.TransformerEnd.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.RATTAPCHANGER_TRANSEND, gid));
                }
            }
        }

        public static void PopulatePowerTransformerEndProperties(FTN.PowerTransformerEnd cimPowerTransformerEnd, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPowerTransformerEnd != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateTransformerEndProperties(cimPowerTransformerEnd, rd, importHelper, report);

                if (cimPowerTransformerEnd.BHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_B, cimPowerTransformerEnd.B));
                }

                if (cimPowerTransformerEnd.B0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_B0, cimPowerTransformerEnd.B0));
                }

                if (cimPowerTransformerEnd.ConnectionKindHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_CONNKIND, (short)GetDMSWindingConnection(cimPowerTransformerEnd.ConnectionKind)));
                }

                if (cimPowerTransformerEnd.GHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_G, cimPowerTransformerEnd.G));
                }

                if (cimPowerTransformerEnd.G0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_G0, cimPowerTransformerEnd.G0));
                }

                if (cimPowerTransformerEnd.PhaseAngleClockHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_PHANCL, cimPowerTransformerEnd.PhaseAngleClock));
                }

                if (cimPowerTransformerEnd.RHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_R, cimPowerTransformerEnd.R));
                }

                if (cimPowerTransformerEnd.R0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_R0, cimPowerTransformerEnd.R0));
                }

                if (cimPowerTransformerEnd.RatedSHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_RATEDS, cimPowerTransformerEnd.RatedS));
                }

                if (cimPowerTransformerEnd.RatedUHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_RATEDU, cimPowerTransformerEnd.RatedU));
                }

                if (cimPowerTransformerEnd.XHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_X, cimPowerTransformerEnd.X));
                }

                if (cimPowerTransformerEnd.X0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTE_X0, cimPowerTransformerEnd.X0));
                }

                if (cimPowerTransformerEnd.PowerTransformerHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimPowerTransformerEnd.PowerTransformer.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimPowerTransformerEnd.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerTransformerEnd.ID);
                        report.Report.Append("\" - Failed to set reference to PowerTransformer: rdfID \"").Append(cimPowerTransformerEnd.PowerTransformer.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.POWERTE_POWERTR, gid));
                }

            }
        }

       
		#endregion Populate ResourceDescription

		#region Enums convert
		public static PhaseCode GetDMSPhaseCode(FTN.PhaseCode phases)
		{
			switch (phases)
			{
				case FTN.PhaseCode.A:
					return PhaseCode.A;
				case FTN.PhaseCode.AB:
					return PhaseCode.AB;
				case FTN.PhaseCode.ABC:
					return PhaseCode.ABC;
				case FTN.PhaseCode.ABCN:
					return PhaseCode.ABCN;
				case FTN.PhaseCode.ABN:
					return PhaseCode.ABN;
				case FTN.PhaseCode.AC:
					return PhaseCode.AC;
				case FTN.PhaseCode.ACN:
					return PhaseCode.ACN;
				case FTN.PhaseCode.AN:
					return PhaseCode.AN;
				case FTN.PhaseCode.B:
					return PhaseCode.B;
				case FTN.PhaseCode.BC:
					return PhaseCode.BC;
				case FTN.PhaseCode.BCN:
					return PhaseCode.BCN;
				case FTN.PhaseCode.BN:
					return PhaseCode.BN;
				case FTN.PhaseCode.C:
					return PhaseCode.C;
				case FTN.PhaseCode.CN:
					return PhaseCode.CN;
				case FTN.PhaseCode.N:
					return PhaseCode.N;
				case FTN.PhaseCode.s12N:
					return PhaseCode.ABN;
				case FTN.PhaseCode.s1N:
					return PhaseCode.AN;
				case FTN.PhaseCode.s2N:
					return PhaseCode.BN;
				default: return PhaseCode.Unknown;
			}
		}

		public static TransformerControlMode GetDMSTransformerControlMode(FTN.TransformerControlMode transformerControl)
		{
			switch (transformerControl)
			{
				case FTN.TransformerControlMode.reactive:
					return TransformerControlMode.Reactive;
				default:
                    return TransformerControlMode.Volt;
			}
		}

		public static WindingConnection GetDMSWindingConnection(FTN.WindingConnection windingConnection)
		{
			switch (windingConnection)
			{
				case FTN.WindingConnection.D:
					return WindingConnection.D;
				case FTN.WindingConnection.I:
					return WindingConnection.I;
				case FTN.WindingConnection.Z:
					return WindingConnection.Z;
				case FTN.WindingConnection.Y:
					return WindingConnection.Y;
				default:
					return WindingConnection.Y;
			}
		}
		#endregion Enums convert
	}
}
