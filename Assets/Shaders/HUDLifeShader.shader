// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:34039,y:32629,varname:node_1873,prsc:2|emission-671-OUT,alpha-8058-OUT;n:type:ShaderForge.SFN_TexCoord,id:7925,x:32031,y:32752,varname:node_7925,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:6949,x:32230,y:32752,varname:node_6949,prsc:2,spu:0.25,spv:0|UVIN-7925-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:7379,x:32434,y:32752,varname:node_7379,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6949-UVOUT;n:type:ShaderForge.SFN_Vector1,id:9325,x:32614,y:32932,varname:node_9325,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Frac,id:7817,x:32614,y:32752,varname:node_7817,prsc:2|IN-7379-OUT;n:type:ShaderForge.SFN_Subtract,id:9862,x:32827,y:32752,varname:node_9862,prsc:2|A-7817-OUT,B-9325-OUT;n:type:ShaderForge.SFN_Abs,id:2118,x:33022,y:32752,varname:node_2118,prsc:2|IN-9862-OUT;n:type:ShaderForge.SFN_Vector1,id:6186,x:33022,y:32933,varname:node_6186,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:2816,x:33229,y:32812,varname:node_2816,prsc:2|A-2118-OUT,B-6186-OUT;n:type:ShaderForge.SFN_Vector1,id:7603,x:33216,y:32995,varname:node_7603,prsc:2,v1:3;n:type:ShaderForge.SFN_Power,id:8058,x:33459,y:32835,varname:node_8058,prsc:2|VAL-2816-OUT,EXP-7603-OUT;n:type:ShaderForge.SFN_Color,id:9908,x:33644,y:32636,ptovrint:False,ptlb:node_9908,ptin:_node_9908,varname:node_9908,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.6617647,c3:0,c4:1;n:type:ShaderForge.SFN_Vector1,id:4942,x:33624,y:32784,varname:node_4942,prsc:2,v1:5;n:type:ShaderForge.SFN_Relay,id:9726,x:33654,y:32941,varname:node_9726,prsc:2|IN-8058-OUT;n:type:ShaderForge.SFN_Multiply,id:671,x:33810,y:32784,varname:node_671,prsc:2|A-9908-RGB,B-4942-OUT,C-9726-OUT;proporder:9908-3725;pass:END;sub:END;*/

Shader "Shader Forge/HUDLifeShader" {
    Properties {
        _node_9908 ("node_9908", Color) = (1,0.6617647,0,1)
        _node_3725 ("node_3725", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _node_9908;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_5639 = _Time;
                float node_8058 = pow((abs((frac((i.uv0+node_5639.g*float2(0.25,0)).r)-0.5))*2.0),3.0);
                float3 emissive = (_node_9908.rgb*5.0*node_8058);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_8058);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
