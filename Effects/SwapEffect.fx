sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uTime;
float4 uSourceRect;
float2 uWorldPosition;
float uDirection;
float3 uLightSource;
float2 uImageSize0;
float2 uImageSize1;

float4 PixelShaderFunction(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);
	float4 color2 = color;
	
    if (!any(color))
        return color;
	
	color.r = color2.b;
	color.g = color2.r;
	color.b = color2.g;
	
	color *= sampleColor;
    return color;
}

technique Technique1
{
    pass SwapDyePass
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}