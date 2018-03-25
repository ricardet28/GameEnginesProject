// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:35256,y:32924,varname:node_9361,prsc:2|emission-7658-OUT,refract-6339-OUT,voffset-2769-OUT;n:type:ShaderForge.SFN_Vector1,id:2833,x:32040,y:32585,cmnt:U depth speed,varname:node_2833,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2219,x:32040,y:32697,cmnt:V depth speed,varname:node_2219,prsc:2,v1:-0.4;n:type:ShaderForge.SFN_Append,id:9601,x:32276,y:32619,varname:node_9601,prsc:2|A-2833-OUT,B-2219-OUT;n:type:ShaderForge.SFN_Multiply,id:3965,x:32483,y:32619,varname:node_3965,prsc:2|A-9601-OUT,B-3756-T;n:type:ShaderForge.SFN_TexCoord,id:9074,x:32483,y:32796,varname:node_9074,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:1231,x:32687,y:32619,varname:node_1231,prsc:2|A-3965-OUT,B-9074-UVOUT;n:type:ShaderForge.SFN_Time,id:3756,x:32276,y:32806,varname:node_3756,prsc:2;n:type:ShaderForge.SFN_Slider,id:1719,x:31903,y:33037,ptovrint:False,ptlb:Fresnel Strench,ptin:_FresnelStrench,varname:node_1719,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.5,max:3;n:type:ShaderForge.SFN_Fresnel,id:1815,x:32276,y:33034,varname:node_1815,prsc:2|EXP-1719-OUT;n:type:ShaderForge.SFN_Multiply,id:4511,x:32598,y:33025,varname:node_4511,prsc:2|A-1815-OUT,B-5214-OUT,C-2835-OUT;n:type:ShaderForge.SFN_Tex2d,id:7365,x:32891,y:32619,ptovrint:False,ptlb:node_7365,ptin:_node_7365,varname:node_7365,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1231-OUT;n:type:ShaderForge.SFN_Color,id:271,x:32891,y:32833,ptovrint:False,ptlb:Depth Color,ptin:_DepthColor,varname:node_271,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2655172,c2:0.9351926,c3:1,c4:1;n:type:ShaderForge.SFN_Clamp01,id:3225,x:32891,y:33035,varname:node_3225,prsc:2|IN-4511-OUT;n:type:ShaderForge.SFN_Tex2d,id:2697,x:32276,y:33342,ptovrint:False,ptlb:Main Texture,ptin:_MainTexture,varname:node_2697,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bd6bbae8d8ff3b64ab04076894c25c34,ntxv:0,isnm:False|UVIN-4384-OUT;n:type:ShaderForge.SFN_Vector1,id:58,x:32276,y:33551,cmnt:Emission,varname:node_58,prsc:2,v1:0.15;n:type:ShaderForge.SFN_Multiply,id:2234,x:32477,y:33342,varname:node_2234,prsc:2|A-2697-RGB,B-58-OUT;n:type:ShaderForge.SFN_Add,id:4384,x:32046,y:33342,varname:node_4384,prsc:2|A-4371-OUT,B-9629-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4371,x:31828,y:33342,varname:node_4371,prsc:2|A-659-OUT,B-57-T;n:type:ShaderForge.SFN_TexCoord,id:9629,x:31828,y:33499,varname:node_9629,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:659,x:31618,y:33342,varname:node_659,prsc:2|A-383-OUT,B-9172-OUT;n:type:ShaderForge.SFN_Time,id:57,x:31618,y:33509,varname:node_57,prsc:2;n:type:ShaderForge.SFN_Add,id:2770,x:32685,y:33342,varname:node_2770,prsc:2|A-4511-OUT,B-2234-OUT;n:type:ShaderForge.SFN_Vector1,id:3141,x:32891,y:33187,cmnt:Depth color power,varname:node_3141,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Color,id:9330,x:32891,y:33292,ptovrint:False,ptlb:node_9330,ptin:_node_9330,varname:node_9330,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.8421279,c3:0.9705882,c4:1;n:type:ShaderForge.SFN_Clamp01,id:145,x:32891,y:33475,varname:node_145,prsc:2|IN-2770-OUT;n:type:ShaderForge.SFN_Multiply,id:5776,x:33142,y:33292,varname:node_5776,prsc:2|A-9330-RGB,B-145-OUT;n:type:ShaderForge.SFN_Multiply,id:9255,x:33145,y:33012,varname:node_9255,prsc:2|A-7365-RGB,B-271-RGB,C-3141-OUT;n:type:ShaderForge.SFN_Multiply,id:2043,x:33145,y:32870,varname:node_2043,prsc:2|A-9330-RGB,B-3225-OUT;n:type:ShaderForge.SFN_Multiply,id:6786,x:33145,y:32704,varname:node_6786,prsc:2|A-7365-RGB,B-271-RGB,C-3141-OUT;n:type:ShaderForge.SFN_Lerp,id:6054,x:33376,y:32704,varname:node_6054,prsc:2|A-6786-OUT,B-2043-OUT,T-9768-OUT;n:type:ShaderForge.SFN_Lerp,id:6438,x:33377,y:33012,varname:node_6438,prsc:2|A-9255-OUT,B-5776-OUT,T-9768-OUT;n:type:ShaderForge.SFN_Vector1,id:716,x:32891,y:33648,cmnt:Depth dist,varname:node_716,prsc:2,v1:0.4;n:type:ShaderForge.SFN_DepthBlend,id:9768,x:33142,y:33481,varname:node_9768,prsc:2|DIST-716-OUT;n:type:ShaderForge.SFN_TexCoord,id:2672,x:33564,y:33213,varname:node_2672,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:5806,x:33407,y:33433,ptovrint:False,ptlb:node_5806,ptin:_node_5806,varname:node_5806,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:8888,x:33391,y:33586,ptovrint:False,ptlb:node_8888,ptin:_node_8888,varname:node_8888,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Step,id:487,x:33790,y:33213,varname:node_487,prsc:2|A-2672-V,B-5806-OUT;n:type:ShaderForge.SFN_Step,id:9125,x:33790,y:33452,varname:node_9125,prsc:2|A-8888-OUT,B-2672-V;n:type:ShaderForge.SFN_Multiply,id:433,x:34002,y:33336,varname:node_433,prsc:2|A-487-OUT,B-9125-OUT;n:type:ShaderForge.SFN_Clamp01,id:3776,x:34216,y:33336,varname:node_3776,prsc:2|IN-433-OUT;n:type:ShaderForge.SFN_Multiply,id:5630,x:34427,y:33180,varname:node_5630,prsc:2|A-4993-OUT,B-3776-OUT;n:type:ShaderForge.SFN_FaceSign,id:8713,x:33377,y:33213,varname:node_8713,prsc:2,fstp:0;n:type:ShaderForge.SFN_Lerp,id:4993,x:33564,y:32989,varname:node_4993,prsc:2|A-6054-OUT,B-6438-OUT,T-8713-VFACE;n:type:ShaderForge.SFN_Slider,id:383,x:31209,y:33343,ptovrint:False,ptlb:U Speed,ptin:_USpeed,varname:node_383,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Slider,id:9172,x:31209,y:33561,ptovrint:False,ptlb:V Speed,ptin:_VSpeed,varname:node_9172,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Multiply,id:6339,x:32963,y:33896,varname:node_6339,prsc:2|A-2835-OUT,B-2426-OUT;n:type:ShaderForge.SFN_Add,id:2835,x:32748,y:33917,varname:node_2835,prsc:2|A-3059-OUT,B-6505-OUT;n:type:ShaderForge.SFN_Tex2d,id:31,x:32366,y:33999,ptovrint:False,ptlb:node_31,ptin:_node_31,varname:node_31,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:3,isnm:True|UVIN-3744-OUT;n:type:ShaderForge.SFN_Slider,id:3059,x:32258,y:33870,ptovrint:False,ptlb:Noise Effect,ptin:_NoiseEffect,varname:node_3059,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:0.3988737,max:2;n:type:ShaderForge.SFN_Slider,id:3807,x:32266,y:34241,ptovrint:False,ptlb:node_3807,ptin:_node_3807,varname:node_3807,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Vector1,id:2296,x:32406,y:34399,varname:node_2296,prsc:2,v1:0.005;n:type:ShaderForge.SFN_Multiply,id:2426,x:32679,y:34200,varname:node_2426,prsc:2|A-3807-OUT,B-2296-OUT;n:type:ShaderForge.SFN_Multiply,id:3744,x:32016,y:34020,varname:node_3744,prsc:2|A-5836-UVOUT,B-6533-OUT;n:type:ShaderForge.SFN_Panner,id:5836,x:31666,y:34157,varname:node_5836,prsc:2,spu:1,spv:0|UVIN-6109-UVOUT,DIST-8474-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6533,x:31826,y:34301,ptovrint:False,ptlb:node_6533,ptin:_node_6533,varname:node_6533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Panner,id:6109,x:31384,y:34068,varname:node_6109,prsc:2,spu:0,spv:1|UVIN-2918-UVOUT,DIST-2588-OUT;n:type:ShaderForge.SFN_TexCoord,id:2918,x:31163,y:33912,varname:node_2918,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:2588,x:31163,y:34126,varname:node_2588,prsc:2|A-645-T,B-9038-OUT;n:type:ShaderForge.SFN_Multiply,id:8474,x:31163,y:34322,varname:node_8474,prsc:2|A-645-T,B-6191-OUT;n:type:ShaderForge.SFN_Time,id:645,x:30829,y:34122,varname:node_645,prsc:2;n:type:ShaderForge.SFN_Slider,id:9038,x:30704,y:34321,ptovrint:False,ptlb:CoordVDist,ptin:_CoordVDist,varname:node_9038,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:0.1,max:2;n:type:ShaderForge.SFN_Slider,id:6191,x:30693,y:34482,ptovrint:False,ptlb:CoordUDist,ptin:_CoordUDist,varname:_CoordVDist_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:0.1,max:2;n:type:ShaderForge.SFN_SceneColor,id:1200,x:34368,y:32648,varname:node_1200,prsc:2;n:type:ShaderForge.SFN_Clamp01,id:8422,x:34572,y:32729,varname:node_8422,prsc:2|IN-1200-RGB;n:type:ShaderForge.SFN_Lerp,id:7658,x:34890,y:32958,varname:node_7658,prsc:2|A-8422-OUT,B-4628-RGB,T-5630-OUT;n:type:ShaderForge.SFN_Slider,id:5214,x:32174,y:33225,ptovrint:False,ptlb:Transparent,ptin:_Transparent,varname:node_5214,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5116984,max:1;n:type:ShaderForge.SFN_Append,id:6505,x:32558,y:33999,varname:node_6505,prsc:2|A-31-R,B-31-G;n:type:ShaderForge.SFN_Color,id:4628,x:34572,y:32898,ptovrint:False,ptlb:Color Refraccion,ptin:_ColorRefraccion,varname:node_4628,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_NormalVector,id:4300,x:33027,y:34353,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:9769,x:32870,y:34234,ptovrint:False,ptlb:Displacement Amount,ptin:_DisplacementAmount,varname:node_9769,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.002,max:0.2;n:type:ShaderForge.SFN_Multiply,id:2769,x:33261,y:34096,varname:node_2769,prsc:2|A-31-RGB,B-9769-OUT,C-4300-OUT;proporder:1719-7365-271-2697-9330-5806-8888-383-9172-5214-31-3059-6533-9038-6191-3807-4628-9769;pass:END;sub:END;*/

Shader "Shader Forge/ShaderDepth" {
    Properties {
        _FresnelStrench ("Fresnel Strench", Range(0, 3)) = 1.5
        _node_7365 ("node_7365", 2D) = "white" {}
        _DepthColor ("Depth Color", Color) = (0.2655172,0.9351926,1,1)
        _MainTexture ("Main Texture", 2D) = "white" {}
        _node_9330 ("node_9330", Color) = (0,0.8421279,0.9705882,1)
        _node_5806 ("node_5806", Range(0, 1)) = 1
        _node_8888 ("node_8888", Range(0, 1)) = 0
        _USpeed ("U Speed", Range(0, 1)) = 0.1
        _VSpeed ("V Speed", Range(0, 1)) = 0.1
        _Transparent ("Transparent", Range(0, 1)) = 0.5116984
        _node_31 ("node_31", 2D) = "bump" {}
        _NoiseEffect ("Noise Effect", Range(-2, 2)) = 0.3988737
        _node_6533 ("node_6533", Float ) = 1
        _CoordVDist ("CoordVDist", Range(-2, 2)) = 0.1
        _CoordUDist ("CoordUDist", Range(-2, 2)) = 0.1
        _node_3807 ("node_3807", Range(0, 1)) = 0.1
        _ColorRefraccion ("Color Refraccion", Color) = (0.5,0.5,0.5,1)
        _DisplacementAmount ("Displacement Amount", Range(0, 0.2)) = 0.002
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float _FresnelStrench;
            uniform sampler2D _node_7365; uniform float4 _node_7365_ST;
            uniform float4 _DepthColor;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float4 _node_9330;
            uniform float _node_5806;
            uniform float _node_8888;
            uniform float _USpeed;
            uniform float _VSpeed;
            uniform sampler2D _node_31; uniform float4 _node_31_ST;
            uniform float _NoiseEffect;
            uniform float _node_3807;
            uniform float _node_6533;
            uniform float _CoordVDist;
            uniform float _CoordUDist;
            uniform float _Transparent;
            uniform float4 _ColorRefraccion;
            uniform float _DisplacementAmount;
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
                float4 projPos : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_645 = _Time;
                float2 node_3744 = (((o.uv0+(node_645.g*_CoordVDist)*float2(0,1))+(node_645.g*_CoordUDist)*float2(1,0))*_node_6533);
                float3 _node_31_var = UnpackNormal(tex2Dlod(_node_31,float4(TRANSFORM_TEX(node_3744, _node_31),0.0,0)));
                v.vertex.xyz += (_node_31_var.rgb*_DisplacementAmount*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_645 = _Time;
                float2 node_3744 = (((i.uv0+(node_645.g*_CoordVDist)*float2(0,1))+(node_645.g*_CoordUDist)*float2(1,0))*_node_6533);
                float3 _node_31_var = UnpackNormal(tex2D(_node_31,TRANSFORM_TEX(node_3744, _node_31)));
                float2 node_2835 = (_NoiseEffect+float2(_node_31_var.r,_node_31_var.g));
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (node_2835*(_node_3807*0.005));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float4 node_3756 = _Time;
                float2 node_1231 = ((float2(0.0,(-0.4))*node_3756.g)+i.uv0);
                float4 _node_7365_var = tex2D(_node_7365,TRANSFORM_TEX(node_1231, _node_7365));
                float node_3141 = 0.7; // Depth color power
                float2 node_4511 = (pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelStrench)*_Transparent*node_2835);
                float node_9768 = saturate((sceneZ-partZ)/0.4);
                float4 node_57 = _Time;
                float2 node_4384 = ((float2(_USpeed,_VSpeed)*node_57.g)+i.uv0);
                float4 _MainTexture_var = tex2D(_MainTexture,TRANSFORM_TEX(node_4384, _MainTexture));
                float3 emissive = lerp(saturate(sceneColor.rgb),_ColorRefraccion.rgb,(lerp(lerp((_node_7365_var.rgb*_DepthColor.rgb*node_3141),(_node_9330.rgb*float3(saturate(node_4511),0.0)),node_9768),lerp((_node_7365_var.rgb*_DepthColor.rgb*node_3141),(_node_9330.rgb*saturate((float3(node_4511,0.0)+(_MainTexture_var.rgb*0.15)))),node_9768),isFrontFace)*saturate((step(i.uv0.g,_node_5806)*step(_node_8888,i.uv0.g)))));
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,1),1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_31; uniform float4 _node_31_ST;
            uniform float _node_6533;
            uniform float _CoordVDist;
            uniform float _CoordUDist;
            uniform float _DisplacementAmount;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_645 = _Time;
                float2 node_3744 = (((o.uv0+(node_645.g*_CoordVDist)*float2(0,1))+(node_645.g*_CoordUDist)*float2(1,0))*_node_6533);
                float3 _node_31_var = UnpackNormal(tex2Dlod(_node_31,float4(TRANSFORM_TEX(node_3744, _node_31),0.0,0)));
                v.vertex.xyz += (_node_31_var.rgb*_DisplacementAmount*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
