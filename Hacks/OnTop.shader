Shader "Custom/AlwaysOnTop"
{
    SubShader
    {
        Tags { "Queue" = "Overlay" "RenderType" = "Overlay" }
        ZTest Always

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float4 color : COLOR;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = 1;
        }
        ENDCG
    }
        Fallback "Diffuse"
}