﻿Shader "Custom/NewSurfaceShader"
{
    SubShader
    {
        Tags { "Queue"="Transparent+1" } // render after all transparent objects (this queue will be 3001)
        Pass { Blend Zero One }
     
    }

}
