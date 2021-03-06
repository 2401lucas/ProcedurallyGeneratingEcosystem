﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/MeshSettings")]
public class MeshSettings : UpdatableData
{
    public const int numSupportedLods = 5;
    public const int numSupportedChunkSizes = 9;
    public const int numSupportedFlatShadedChunkSizes = 3;
    public static readonly int[] supportedChunkSizes = { 48, 72, 96, 120, 144, 168, 192, 216, 240 };

    public float meshScale = 2.5f;
    public bool useFlatShading;

    [Range(0, numSupportedChunkSizes - 1)]
    public int chunkSizeIndex;

    [Range(0, numSupportedFlatShadedChunkSizes - 1)]
    public int flatShadedChunkSizeIndex;

    //number of vertices used per line at LOD = 0. Includes 2 extra vertices that are excluded from final mesh but used for calculating normals.
    //When creating seamless chunks, 3 more vertices are needed to properly calculate it the edges of the chunks
    public int numberOfVerticesPerLine
    {
        get
        {
            //Each mesh has a limit of 65000 vertices, with a chunk size greater then 96 when flat shading, we exceed that
            return supportedChunkSizes[(useFlatShading) ? flatShadedChunkSizeIndex : chunkSizeIndex] + 5;
        }
    }

    public float meshWorldSize
    {
        get
        {
            return (numberOfVerticesPerLine - 3) * meshScale;
        }
    }
}
