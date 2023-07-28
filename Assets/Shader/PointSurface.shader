Shader "Custom/Point Surface"
{
    properties{
        
        _Smoothness ("Smoothness", Range(0,1)) = 0.5
        }
    SubShader
    {
        

        CGPROGRAM
        #pragma surface ConfigureSurface Standard fullforwardshadows
		#pragma target 3.0s
        struct Input {
			float3 worldPos;
		};
        float _Smoothness;
        void ConfigureSurface (Input input, inout SurfaceOutputStandard surface)
        {
            surface.Albedo=saturate(input.worldPos*0.5+0.5);
            surface.Smoothness=_Smoothness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
