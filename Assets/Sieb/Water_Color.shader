// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.6617647,fgcg:0.986004,fgcb:1,fgca:1,fgde:0.04,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-2180-OUT,spec-358-OUT,gloss-1676-OUT,alpha-7442-OUT,refract-7726-OUT,voffset-7758-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:30662,y:32793,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2647059,c2:0.7058823,c3:0.6511156,c4:1;n:type:ShaderForge.SFN_Slider,id:358,x:32239,y:32727,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:31685,y:32822,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_TexCoord,id:9477,x:31131,y:33818,varname:node_9477,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:9857,x:32052,y:34190,ptovrint:False,ptlb:normal map,ptin:_normalmap,varname:node_9857,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:68ef18d22f71a984698cc6c408a9f5d4,ntxv:2,isnm:False|UVIN-4429-UVOUT;n:type:ShaderForge.SFN_NormalVector,id:6616,x:32540,y:33779,prsc:2,pt:True;n:type:ShaderForge.SFN_Multiply,id:7263,x:32939,y:33854,varname:node_7263,prsc:2|A-6616-OUT,B-9857-RGB;n:type:ShaderForge.SFN_Time,id:689,x:30911,y:34241,varname:node_689,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4365,x:31174,y:34207,varname:node_4365,prsc:2|A-6234-OUT,B-689-T;n:type:ShaderForge.SFN_Vector1,id:6234,x:30910,y:34149,varname:node_6234,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Multiply,id:6816,x:31550,y:34031,varname:node_6816,prsc:2|A-9477-UVOUT,B-9535-OUT;n:type:ShaderForge.SFN_Vector1,id:9535,x:31361,y:34106,varname:node_9535,prsc:2,v1:2;n:type:ShaderForge.SFN_Blend,id:2180,x:31987,y:32471,varname:node_2180,prsc:2,blmd:10,clmp:True|SRC-3817-OUT,DST-7069-OUT;n:type:ShaderForge.SFN_Tex2d,id:6264,x:32014,y:34631,ptovrint:False,ptlb:normal map_copy,ptin:_normalmap_copy,varname:_normalmap_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:68ef18d22f71a984698cc6c408a9f5d4,ntxv:2,isnm:False|UVIN-5172-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1998,x:31553,y:34428,varname:node_1998,prsc:2|A-8805-UVOUT,B-8863-OUT;n:type:ShaderForge.SFN_Multiply,id:2337,x:31247,y:34671,varname:node_2337,prsc:2|A-2305-OUT,B-9235-T;n:type:ShaderForge.SFN_TexCoord,id:8805,x:31237,y:34393,varname:node_8805,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:8863,x:31237,y:34558,varname:node_8863,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:2305,x:31019,y:34629,varname:node_2305,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Time,id:9235,x:31019,y:34728,varname:node_9235,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8769,x:33025,y:34095,varname:node_8769,prsc:2|A-2144-OUT,B-6264-RGB;n:type:ShaderForge.SFN_NormalVector,id:2144,x:32617,y:34211,prsc:2,pt:True;n:type:ShaderForge.SFN_Blend,id:7758,x:33381,y:33920,varname:node_7758,prsc:2,blmd:19,clmp:True|SRC-7263-OUT,DST-8769-OUT;n:type:ShaderForge.SFN_Multiply,id:7945,x:31198,y:33079,varname:node_7945,prsc:2|A-9857-B,B-6264-B;n:type:ShaderForge.SFN_VertexColor,id:9490,x:31264,y:32873,varname:node_9490,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3817,x:31397,y:32580,varname:node_3817,prsc:2|A-894-OUT,B-9490-RGB;n:type:ShaderForge.SFN_Posterize,id:7069,x:31529,y:32994,varname:node_7069,prsc:2|IN-7945-OUT,STPS-7949-OUT;n:type:ShaderForge.SFN_Vector1,id:7949,x:31386,y:33223,varname:node_7949,prsc:2,v1:10;n:type:ShaderForge.SFN_ObjectPosition,id:7425,x:30216,y:32938,varname:node_7425,prsc:2;n:type:ShaderForge.SFN_FragmentPosition,id:8736,x:30216,y:33063,varname:node_8736,prsc:2;n:type:ShaderForge.SFN_Subtract,id:9653,x:30420,y:32974,varname:node_9653,prsc:2|A-7425-Y,B-8736-Y;n:type:ShaderForge.SFN_Color,id:2121,x:30662,y:32604,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_2121,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.1985294,c3:0.1492393,c4:1;n:type:ShaderForge.SFN_Lerp,id:894,x:31116,y:32758,varname:node_894,prsc:2|A-2121-RGB,B-6665-RGB,T-8034-OUT;n:type:ShaderForge.SFN_Slider,id:1588,x:30615,y:33150,ptovrint:False,ptlb:depth blend,ptin:_depthblend,varname:node_1588,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:8034,x:30962,y:32905,varname:node_8034,prsc:2|A-8550-OUT,B-1588-OUT;n:type:ShaderForge.SFN_OneMinus,id:8550,x:30694,y:32983,varname:node_8550,prsc:2|IN-9653-OUT;n:type:ShaderForge.SFN_Panner,id:4429,x:31750,y:34154,varname:node_4429,prsc:2,spu:1,spv:0|UVIN-6816-OUT,DIST-4365-OUT;n:type:ShaderForge.SFN_Panner,id:5172,x:31775,y:34531,varname:node_5172,prsc:2,spu:0,spv:1|UVIN-1998-OUT,DIST-2337-OUT;n:type:ShaderForge.SFN_Multiply,id:1676,x:31883,y:32948,varname:node_1676,prsc:2|A-1813-OUT,B-9857-G,C-6264-G;n:type:ShaderForge.SFN_OneMinus,id:2623,x:32096,y:32995,varname:node_2623,prsc:2|IN-1676-OUT;n:type:ShaderForge.SFN_Multiply,id:7442,x:32333,y:33071,varname:node_7442,prsc:2|A-2623-OUT,B-8492-OUT;n:type:ShaderForge.SFN_Slider,id:8492,x:31850,y:33197,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_8492,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:7726,x:32125,y:33348,varname:node_7726,prsc:2|A-9653-OUT,B-5049-OUT,C-6178-OUT;n:type:ShaderForge.SFN_Vector1,id:6178,x:31808,y:33616,varname:node_6178,prsc:2,v1:-1;n:type:ShaderForge.SFN_NormalVector,id:5049,x:31808,y:33436,prsc:2,pt:True;proporder:6665-358-1813-9857-6264-2121-1588-8492;pass:END;sub:END;*/

Shader "Shader Forge/Water_Color" {
    Properties {
        _Color ("Color", Color) = (0.2647059,0.7058823,0.6511156,1)
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 2)) = 2
        _normalmap ("normal map", 2D) = "black" {}
        _normalmap_copy ("normal map_copy", 2D) = "black" {}
        _Depth ("Depth", Color) = (0,0.1985294,0.1492393,1)
        _depthblend ("depth blend", Range(0, 1)) = 1
        _Opacity ("Opacity", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 2.0
            uniform sampler2D _GrabTexture;
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _normalmap; uniform float4 _normalmap_ST;
            uniform sampler2D _normalmap_copy; uniform float4 _normalmap_copy_ST;
            uniform float4 _Depth;
            uniform float _depthblend;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD7;
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 node_689 = _Time;
                float2 node_4429 = ((o.uv0*2.0)+(0.03*node_689.g)*float2(1,0));
                float4 _normalmap_var = tex2Dlod(_normalmap,float4(TRANSFORM_TEX(node_4429, _normalmap),0.0,0));
                float4 node_9235 = _Time;
                float2 node_5172 = ((o.uv0*2.0)+(0.03*node_9235.g)*float2(0,1));
                float4 _normalmap_copy_var = tex2Dlod(_normalmap_copy,float4(TRANSFORM_TEX(node_5172, _normalmap_copy),0.0,0));
                v.vertex.xyz += saturate(((v.normal*_normalmap_copy_var.rgb)-(v.normal*_normalmap_var.rgb)));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float node_9653 = (objPos.g-i.posWorld.g);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (node_9653*normalDirection*(-1.0)).rg;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 node_689 = _Time;
                float2 node_4429 = ((i.uv0*2.0)+(0.03*node_689.g)*float2(1,0));
                float4 _normalmap_var = tex2D(_normalmap,TRANSFORM_TEX(node_4429, _normalmap));
                float4 node_9235 = _Time;
                float2 node_5172 = ((i.uv0*2.0)+(0.03*node_9235.g)*float2(0,1));
                float4 _normalmap_copy_var = tex2D(_normalmap_copy,TRANSFORM_TEX(node_5172, _normalmap_copy));
                float node_1676 = (_Gloss*_normalmap_var.g*_normalmap_copy_var.g);
                float gloss = node_1676;
                float perceptualRoughness = 1.0 - node_1676;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float node_7949 = 10.0;
                float3 diffuseColor = saturate(( floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1) > 0.5 ? (1.0-(1.0-2.0*(floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1)-0.5))*(1.0-(lerp(_Depth.rgb,_Color.rgb,((1.0 - node_9653)+_depthblend))*i.vertexColor.rgb))) : (2.0*floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1)*(lerp(_Depth.rgb,_Color.rgb,((1.0 - node_9653)+_depthblend))*i.vertexColor.rgb)) )); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,((1.0 - node_1676)*_Opacity)),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 2.0
            uniform sampler2D _GrabTexture;
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _normalmap; uniform float4 _normalmap_ST;
            uniform sampler2D _normalmap_copy; uniform float4 _normalmap_copy_ST;
            uniform float4 _Depth;
            uniform float _depthblend;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
                UNITY_FOG_COORDS(10)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 node_689 = _Time;
                float2 node_4429 = ((o.uv0*2.0)+(0.03*node_689.g)*float2(1,0));
                float4 _normalmap_var = tex2Dlod(_normalmap,float4(TRANSFORM_TEX(node_4429, _normalmap),0.0,0));
                float4 node_9235 = _Time;
                float2 node_5172 = ((o.uv0*2.0)+(0.03*node_9235.g)*float2(0,1));
                float4 _normalmap_copy_var = tex2Dlod(_normalmap_copy,float4(TRANSFORM_TEX(node_5172, _normalmap_copy),0.0,0));
                v.vertex.xyz += saturate(((v.normal*_normalmap_copy_var.rgb)-(v.normal*_normalmap_var.rgb)));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_9653 = (objPos.g-i.posWorld.g);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (node_9653*normalDirection*(-1.0)).rg;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 node_689 = _Time;
                float2 node_4429 = ((i.uv0*2.0)+(0.03*node_689.g)*float2(1,0));
                float4 _normalmap_var = tex2D(_normalmap,TRANSFORM_TEX(node_4429, _normalmap));
                float4 node_9235 = _Time;
                float2 node_5172 = ((i.uv0*2.0)+(0.03*node_9235.g)*float2(0,1));
                float4 _normalmap_copy_var = tex2D(_normalmap_copy,TRANSFORM_TEX(node_5172, _normalmap_copy));
                float node_1676 = (_Gloss*_normalmap_var.g*_normalmap_copy_var.g);
                float gloss = node_1676;
                float perceptualRoughness = 1.0 - node_1676;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float node_7949 = 10.0;
                float3 diffuseColor = saturate(( floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1) > 0.5 ? (1.0-(1.0-2.0*(floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1)-0.5))*(1.0-(lerp(_Depth.rgb,_Color.rgb,((1.0 - node_9653)+_depthblend))*i.vertexColor.rgb))) : (2.0*floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1)*(lerp(_Depth.rgb,_Color.rgb,((1.0 - node_9653)+_depthblend))*i.vertexColor.rgb)) )); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * ((1.0 - node_1676)*_Opacity),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 2.0
            uniform sampler2D _normalmap; uniform float4 _normalmap_ST;
            uniform sampler2D _normalmap_copy; uniform float4 _normalmap_copy_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
                float3 normalDir : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_689 = _Time;
                float2 node_4429 = ((o.uv0*2.0)+(0.03*node_689.g)*float2(1,0));
                float4 _normalmap_var = tex2Dlod(_normalmap,float4(TRANSFORM_TEX(node_4429, _normalmap),0.0,0));
                float4 node_9235 = _Time;
                float2 node_5172 = ((o.uv0*2.0)+(0.03*node_9235.g)*float2(0,1));
                float4 _normalmap_copy_var = tex2Dlod(_normalmap_copy,float4(TRANSFORM_TEX(node_5172, _normalmap_copy),0.0,0));
                v.vertex.xyz += saturate(((v.normal*_normalmap_copy_var.rgb)-(v.normal*_normalmap_var.rgb)));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 2.0
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _normalmap; uniform float4 _normalmap_ST;
            uniform sampler2D _normalmap_copy; uniform float4 _normalmap_copy_ST;
            uniform float4 _Depth;
            uniform float _depthblend;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 node_689 = _Time;
                float2 node_4429 = ((o.uv0*2.0)+(0.03*node_689.g)*float2(1,0));
                float4 _normalmap_var = tex2Dlod(_normalmap,float4(TRANSFORM_TEX(node_4429, _normalmap),0.0,0));
                float4 node_9235 = _Time;
                float2 node_5172 = ((o.uv0*2.0)+(0.03*node_9235.g)*float2(0,1));
                float4 _normalmap_copy_var = tex2Dlod(_normalmap_copy,float4(TRANSFORM_TEX(node_5172, _normalmap_copy),0.0,0));
                v.vertex.xyz += saturate(((v.normal*_normalmap_copy_var.rgb)-(v.normal*_normalmap_var.rgb)));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float node_9653 = (objPos.g-i.posWorld.g);
                float4 node_689 = _Time;
                float2 node_4429 = ((i.uv0*2.0)+(0.03*node_689.g)*float2(1,0));
                float4 _normalmap_var = tex2D(_normalmap,TRANSFORM_TEX(node_4429, _normalmap));
                float4 node_9235 = _Time;
                float2 node_5172 = ((i.uv0*2.0)+(0.03*node_9235.g)*float2(0,1));
                float4 _normalmap_copy_var = tex2D(_normalmap_copy,TRANSFORM_TEX(node_5172, _normalmap_copy));
                float node_7949 = 10.0;
                float3 diffColor = saturate(( floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1) > 0.5 ? (1.0-(1.0-2.0*(floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1)-0.5))*(1.0-(lerp(_Depth.rgb,_Color.rgb,((1.0 - node_9653)+_depthblend))*i.vertexColor.rgb))) : (2.0*floor((_normalmap_var.b*_normalmap_copy_var.b) * node_7949) / (node_7949 - 1)*(lerp(_Depth.rgb,_Color.rgb,((1.0 - node_9653)+_depthblend))*i.vertexColor.rgb)) ));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float node_1676 = (_Gloss*_normalmap_var.g*_normalmap_copy_var.g);
                float roughness = 1.0 - node_1676;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
