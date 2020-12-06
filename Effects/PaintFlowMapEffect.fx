float BrushSize;		// (in the (0, 0), (1, 1) space)
float2 BrushPosition;	// (in the (0, 0), (1, 1) space)
float2 BrushDirection;

texture OldFlowMapTexture : register(t0);
sampler2D OldFlowMapSampler : register(s0) = sampler_state
{
	Texture = <OldFlowMapTexture>;
};

struct PixelShaderInput
{
    float2 TexCoord : TEXCOORD0;
};

#define BRUSH_STRENGTH 0.05

float4 PixelShaderFunction(PixelShaderInput input) : COLOR0
{
	// TexCoord will vary between 0,0 and 1,1

	float distance = length(input.TexCoord - BrushPosition);
	float strength = saturate(lerp(1, 0, distance / BrushSize)) * BRUSH_STRENGTH;

	// REVIEW: We might have "drift" here for cases where == 0

	float2 oldValue = tex2D(OldFlowMapSampler, input.TexCoord).rg;
	// Convert to (-1, 1)
	oldValue = (oldValue * 2) - 1;
	
	float2 finalValue = lerp(oldValue, BrushDirection, strength);

	// Convert back
	finalValue = (finalValue * 0.5) + 0.5;

    return float4(finalValue, 1, 1);
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
