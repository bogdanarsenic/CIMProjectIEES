using System;

namespace FTN.Common
{	
	public enum PhaseCode : short
	{
		Unknown = 0,
		A=1,
		AB=2,
		ABC=3,
        ABCN=4,
		ABN=5,
		AC=6,
		ACN=7,
		AN=8,
        B=9,
		BC=10,
		BCN=11,
		BN=12,
		C=13,
		CN=14,
		N=15,
		S1=16,
        S12=17,
        S12N=18,
        S1N=19,
        S2=20,
        S2N=21,
	}
	
	public enum TransformerControlMode : short
	{
		Reactive = 1,				
		Volt = 2,			
	}
	
	public enum WindingConnection : short
	{
		A=1,
        D=2,
        I=3,
        Y=4,
        YN=5,
        Z=6,
        ZN=7,
	}

			
}
