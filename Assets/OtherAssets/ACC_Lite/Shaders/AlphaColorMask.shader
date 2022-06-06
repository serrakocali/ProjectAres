Shader "Custom/AlphaColorMask" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGBA)", 2D) = "white" {}
		_MetallicTex ("Metallic (RGBA)", 2D) = "white" {}
		_Smoothness ("Smoothness", Range(0,1)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MetallicTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MetallicTex;
		};

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		#pragma instancing_options assumeuniformscaling

		UNITY_INSTANCING_BUFFER_START(Props)
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color)
			UNITY_DEFINE_INSTANCED_PROP(half, _Smoothness)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = (c.rgb * (1 - c.a)) + (c.rgb * UNITY_ACCESS_INSTANCED_PROP(Props, _Color) * c.a);
			// Metallic and smoothness come from _MetallicTex
			fixed4 m = tex2D (_MetallicTex, IN.uv_MetallicTex);
			o.Metallic = m.rgb;
			o.Smoothness = (m.a * (1 - c.a)) + (c.rgb * UNITY_ACCESS_INSTANCED_PROP(Props, _Smoothness) * c.a);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
