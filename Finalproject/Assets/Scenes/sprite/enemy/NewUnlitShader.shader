Shader "Custom/TransparentByColor"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _ColorToReplace("Color To Replace", Color) = (0.066, 0.235, 0.305, 1)  // 改成深藍綠色
        _Threshold("Threshold", Range(0,1)) = 0.1                              // 容許範圍 0.1
    }
        SubShader
        {
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
            LOD 100

            Pass
            {
                Cull Off
                ZWrite Off
                Blend SrcAlpha OneMinusSrcAlpha

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float4 _ColorToReplace;
                float _Threshold;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);

                // 如果顏色接近目標顏色，設為透明
                if (distance(col.rgb, _ColorToReplace.rgb) < _Threshold)
                {
                    col.a = 0;
                }
                return col;
            }
            ENDCG
        }
        }
}