// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.6617647,fgcg:0.986004,fgcb:1,fgca:1,fgde:0.04,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-2460-OUT,custl-9941-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32017,y:33166,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32017,y:32981,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:31504,y:32603,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:31504,y:32794,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:7782,x:31716,y:32709,cmnt:Lambert,varname:node_7782,prsc:2,dt:1|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Multiply,id:1941,x:32198,y:32713,cmnt:Diffuse Contribution,varname:node_1941,prsc:2|A-5927-RGB,B-2976-OUT;n:type:ShaderForge.SFN_Color,id:5927,x:31918,y:32525,ptovrint:False,ptlb:ColorRamp_1,ptin:_ColorRamp_1,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5085,x:32489,y:32963,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-1941-OUT,B-3406-RGB,C-8068-OUT;n:type:ShaderForge.SFN_AmbientLight,id:7528,x:32452,y:32683,varname:node_7528,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2460,x:32696,y:32612,cmnt:Ambient Light,varname:node_2460,prsc:2|A-1631-RGB,B-7528-RGB;n:type:ShaderForge.SFN_Color,id:1631,x:32452,y:32487,ptovrint:False,ptlb:ColorRamp_2,ptin:_ColorRamp_2,varname:node_1631,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.2447262,c3:0.2794118,c4:1;n:type:ShaderForge.SFN_Posterize,id:2976,x:31931,y:32808,varname:node_2976,prsc:2|IN-7782-OUT,STPS-4810-OUT;n:type:ShaderForge.SFN_Vector1,id:4810,x:31631,y:32932,varname:node_4810,prsc:2,v1:5;n:type:ShaderForge.SFN_Multiply,id:6122,x:32505,y:33112,varname:node_6122,prsc:2|A-7782-OUT,B-2180-RGB,C-8068-OUT;n:type:ShaderForge.SFN_Color,id:2180,x:32139,y:33346,ptovrint:False,ptlb:Subsurface,ptin:_Subsurface,varname:node_2180,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.8529412,c3:0.6058823,c4:1;n:type:ShaderForge.SFN_Multiply,id:1611,x:32815,y:33016,varname:node_1611,prsc:2|A-6122-OUT,B-5085-OUT;n:type:ShaderForge.SFN_Multiply,id:9941,x:32997,y:32992,varname:node_9941,prsc:2|A-1611-OUT,B-7894-OUT;n:type:ShaderForge.SFN_Slider,id:7894,x:32749,y:33176,ptovrint:False,ptlb:light Intensity,ptin:_lightIntensity,varname:node_7894,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;proporder:5927-1631-2180-7894;pass:END;sub:END;*/

Shader "Shader Forge/CellShading" {
    Properties {
        _ColorRamp_1 ("ColorRamp_1", Color) = (1,1,1,1)
        _ColorRamp_2 ("ColorRamp_2", Color) = (0,0.2447262,0.2794118,1)
        _Subsurface ("Subsurface", Color) = (0,0.8529412,0.6058823,1)
        _lightIntensity ("light Intensity", Range(0, 1)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 2.0
            uniform float4 _ColorRamp_1;
            uniform float4 _ColorRamp_2;
            uniform float4 _Subsurface;
            uniform float _lightIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 emissive = (_ColorRamp_2.rgb*UNITY_LIGHTMODEL_AMBIENT.rgb);
                float node_7782 = max(0,dot(lightDirection,normalDirection)); // Lambert
                float node_4810 = 5.0;
                float3 finalColor = emissive + (((node_7782*_Subsurface.rgb*attenuation)*((_ColorRamp_1.rgb*floor(node_7782 * node_4810) / (node_4810 - 1))*_LightColor0.rgb*attenuation))*_lightIntensity);
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 2.0
            uniform float4 _ColorRamp_1;
            uniform float4 _ColorRamp_2;
            uniform float4 _Subsurface;
            uniform float _lightIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_7782 = max(0,dot(lightDirection,normalDirection)); // Lambert
                float node_4810 = 5.0;
                float3 finalColor = (((node_7782*_Subsurface.rgb*attenuation)*((_ColorRamp_1.rgb*floor(node_7782 * node_4810) / (node_4810 - 1))*_LightColor0.rgb*attenuation))*_lightIntensity);
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
