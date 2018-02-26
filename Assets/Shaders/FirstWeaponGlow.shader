// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32957,y:32687,varname:node_3138,prsc:2|emission-7695-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31996,y:32543,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.4970588,c3:0.1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7039,x:32254,y:32549,varname:node_7039,prsc:2|A-7241-RGB,B-1316-OUT;n:type:ShaderForge.SFN_Multiply,id:7695,x:32545,y:32699,varname:node_7695,prsc:2|A-7039-OUT,B-7808-OUT;n:type:ShaderForge.SFN_RemapRange,id:1316,x:32257,y:32796,varname:node_1316,prsc:2,frmn:-1,frmx:1,tomn:2.5,tomx:5|IN-8608-OUT;n:type:ShaderForge.SFN_Sin,id:8608,x:32069,y:32796,varname:node_8608,prsc:2|IN-6678-OUT;n:type:ShaderForge.SFN_Multiply,id:6678,x:31842,y:32796,varname:node_6678,prsc:2|A-6692-OUT,B-9375-T;n:type:ShaderForge.SFN_ValueProperty,id:6692,x:31571,y:32669,ptovrint:False,ptlb:node_6692,ptin:_node_6692,varname:node_6692,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Time,id:9375,x:31571,y:32795,varname:node_9375,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:7276,x:31843,y:33069,ptovrint:False,ptlb:node_7276,ptin:_node_7276,varname:node_7276,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-8278-UVOUT;n:type:ShaderForge.SFN_Multiply,id:666,x:32072,y:33069,varname:node_666,prsc:2|A-7276-RGB,B-8677-OUT;n:type:ShaderForge.SFN_Clamp01,id:7808,x:32257,y:33069,varname:node_7808,prsc:2|IN-666-OUT;n:type:ShaderForge.SFN_Fresnel,id:8677,x:31843,y:33326,varname:node_8677,prsc:2|EXP-9630-OUT;n:type:ShaderForge.SFN_Slider,id:9630,x:31402,y:33433,ptovrint:False,ptlb:Fresnel Strench,ptin:_FresnelStrench,varname:node_9630,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Panner,id:8278,x:31422,y:33066,varname:node_8278,prsc:2,spu:1,spv:0|UVIN-51-UVOUT,DIST-4638-OUT;n:type:ShaderForge.SFN_Panner,id:51,x:31185,y:32868,varname:node_51,prsc:2,spu:0,spv:1|UVIN-3614-UVOUT,DIST-6916-OUT;n:type:ShaderForge.SFN_TexCoord,id:3614,x:30930,y:32664,varname:node_3614,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:6916,x:30930,y:32878,varname:node_6916,prsc:2|A-2662-T,B-7833-OUT;n:type:ShaderForge.SFN_Time,id:2662,x:30648,y:32865,varname:node_2662,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4638,x:30930,y:33122,varname:node_4638,prsc:2|A-2662-T,B-5589-OUT;n:type:ShaderForge.SFN_Slider,id:7833,x:30415,y:33111,ptovrint:False,ptlb:ChangeSpeedVertical,ptin:_ChangeSpeedVertical,varname:node_7833,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:5589,x:30415,y:33363,ptovrint:False,ptlb:ChangeSpeedHorizontal,ptin:_ChangeSpeedHorizontal,varname:_ChangeSpeedVertical_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:7241-6692-7276-9630-7833-5589;pass:END;sub:END;*/

Shader "Shader Forge/FirstWeaponGlow" {
    Properties {
        _Color ("Color", Color) = (1,0.4970588,0.1,1)
        _node_6692 ("node_6692", Float ) = 5
        _node_7276 ("node_7276", 2D) = "white" {}
        _FresnelStrench ("Fresnel Strench", Range(0, 1)) = 0
        _ChangeSpeedVertical ("ChangeSpeedVertical", Range(0, 1)) = 0
        _ChangeSpeedHorizontal ("ChangeSpeedHorizontal", Range(0, 1)) = 0
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _node_6692;
            uniform sampler2D _node_7276; uniform float4 _node_7276_ST;
            uniform float _FresnelStrench;
            uniform float _ChangeSpeedVertical;
            uniform float _ChangeSpeedHorizontal;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_9375 = _Time;
                float4 node_2662 = _Time;
                float2 node_8278 = ((i.uv0+(node_2662.g*_ChangeSpeedVertical)*float2(0,1))+(node_2662.g*_ChangeSpeedHorizontal)*float2(1,0));
                float4 _node_7276_var = tex2D(_node_7276,TRANSFORM_TEX(node_8278, _node_7276));
                float3 emissive = ((_Color.rgb*(sin((_node_6692*node_9375.g))*1.25+3.75))*saturate((_node_7276_var.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelStrench))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
