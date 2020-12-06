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

//float fNoiseAmount = 0.002; 

static const float PI = 3.14159265f;
float fSpeed = 1.0; 
float fDirection = 1.0; 
float fRadius = 0.1;

// Noise
float4 PixelShaderFunction(float4 sampleColor : COLOR0, float2 Tex: TEXCOORD0) : COLOR
{
	float fCircle = 1.0;
	fCircle += PI / fSpeed * fDirection;
	// Distortion factor
	float NoiseX = cos(fCircle * fRadius);
	float NoiseY = cos(fCircle * fRadius);
	//NoiseX=fmod(NoiseX,8) * fmod(NoiseX,4); 

	// Use our distortion factor to compute how much it will affect each
	// texture coordinate
	//float DistortX = fmod(NoiseX,fNoiseAmount);
	//float DistortY = fmod(NoiseX,fNoiseAmount+0.002);
 
	// Create our new texture coordinate based on our distortion factor
	float2 DistortTex = float2(NoiseX,NoiseY);
 
	// Use our new texture coordinate to look-up a pixel in ColorMapSampler.
	float4 Color=tex2D(uImage0, Tex+DistortTex);
 
 	if (!any(Color))
        return Color;
 
	// Keep our alphachannel at 1.
	
	Color.a = 1.0f;
	Color *= sampleColor;
	
		return Color;
}

technique Technique1
{
    pass NoiseDyePass
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}