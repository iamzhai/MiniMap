// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Rotate"
{
	Properties
	{
		_MainText("Base(GRB)",2D) = "white"{}
	_Color("Base Color)",Color) = (1,1,1,1)
		_Rspeed("Rspeed",Range(1,100)) = 1
	}
		SubShader
	{
		tags{ "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
		Blend SrcAlpha OneMinusSrcAlpha
		Cull off
		Pass
	{
		Name "Simple"
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

		sampler2D _MainText;
	float4 _Color;
	float _Rspeed;
	struct v2f
	{
		float4 pos:POSITION;
		float4 uv:TEXCOORD0;
	};

	v2f vert(appdata_base v)
	{

		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = v.texcoord;
		return o;
	}

	half4 frag(v2f i) :COLOR
	{
		float2 uv = i.uv.xy - float2(0.5,0.5);

		float2 rotate = float2(cos(_Rspeed*_Time.x),sin(_Rspeed*_Time.x));
		uv = float2(uv.x*rotate.x - uv.y*rotate.y,uv.x*rotate.y + uv.y*rotate.x);

		uv += float2(0.5,0.5);
		half4 c = tex2D(_MainText,uv.xy)*_Color;
		return c;
	}
		ENDCG
	}
	}
}
