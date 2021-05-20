using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

		POWERTR 							= 0x0001,
		CONNECTNODE  						= 0x0002,
		TERMINAL							= 0x0003,
		POWERTE    					        = 0x0004,
        RATTAPCHANGER                       = 0x0005,
	}

    [Flags]
	public enum ModelCode : long
	{
		IDOBJ								= 0x1000000000000000,
        IDOBJ_GID                           = 0x1000000000000104,
		IDOBJ_ALIASN						= 0x1000000000000207,
		IDOBJ_MRID							= 0x1000000000000307,
		IDOBJ_NAME							= 0x1000000000000407,	

        TRANSFORMEREND                      = 0x1100000000000000,
        TRANSFORMEREND_RATIOTAPCH           = 0x1100000000000119,
        TRANSFORMEREND_TERMINAL             = 0x1100000000000209,


        CONNECTNODE                         = 0x1200000000020000,
        CONNECTNODE_DESC                    = 0x1200000000020107,
        CONNECTNODE_TERM                    = 0x1200000000020219,

        TERMINAL                            = 0x1300000000030000,
        TERMINAL_CONN                       = 0x1300000000030101,
        TERMINAL_PHASE                      = 0x130000000003020a,
        TERMINAL_SEQNUM                     = 0x1300000000030303,
        TERMINAL_CONNECTNODE                = 0x1300000000030409,
        TERMINAL_TRANSEND                   = 0x1300000000030519,
        TERMINAL_CONDEQ                     = 0x1300000000030609,


        PSR									= 0x1400000000000000,

		EQUIPMENT       					= 0x1410000000000000,
        EQUIPMENT_AGGR                      = 0x1410000000000101,
        EQUIPMENT_NORMINSERV                = 0x1410000000000201,

        TAPCHANGER							= 0x1420000000000000,
        TAPCHANGER_HIGHST                   = 0x1420000000000103,
        TAPCHANGER_INDELAY                  = 0x1420000000000205,
        TAPCHANGER_LOWST                    = 0x1420000000000303,
        TAPCHANGER_ITCFLAG                  = 0x1420000000000401,
        TAPCHANGER_NEUTST                   = 0x1420000000000503,
        TAPCHANGER_NEUTU                    = 0x1420000000000605,
        TAPCHANGER_NORMST                   = 0x1420000000000703,
        TAPCHANGER_REGST                    = 0x1420000000000801,
        TAPCHANGER_SUBDELAY                 = 0x1420000000000905,

        CONDUCTINGEQ                        = 0x1411000000000000,
        CONDUCTINGEQ_TERMINALS              = 0x1411000000000119,


        POWERTR                             = 0x1411100000010000,
        POWERTR_VECTGR                      = 0x1411100000010107,
        POWERTR_POWTRE                      = 0x1411100000010219,

        RATTAPCHANGER                       = 0x1421000000050000,
        RATTAPCHANGER_STVOLTINC             = 0x1421000000050105,
        RATTAPCHANGER_CONTMODE              = 0x142100000005020a,
        RATTAPCHANGER_TRANSEND              = 0x1421000000050309,

        POWERTE                             = 0x1110000000040000,
        POWERTE_B                           = 0x1110000000040105,
        POWERTE_B0                          = 0x1110000000040205,
        POWERTE_CONNKIND                    = 0x111000000004030a,
        POWERTE_G                           = 0x1110000000040405,
        POWERTE_G0                          = 0x1110000000040505,
        POWERTE_PHANCL                      = 0x1110000000040603,
        POWERTE_R                           = 0x1110000000040705,
        POWERTE_R0                          = 0x1110000000040805,
        POWERTE_RATEDS                      = 0x1110000000040905,
        POWERTE_RATEDU                      = 0x1110000000040a05,
        POWERTE_X                           = 0x1110000000040b05,
        POWERTE_X0                          = 0x1110000000040c05,
        POWERTE_POWERTR                     = 0x1110000000040d09,


    }

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


