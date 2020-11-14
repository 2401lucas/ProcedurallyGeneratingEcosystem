using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class LevelGen : MonoBehaviour
{
    public enum DrawMode { NoiseMap, Mesh, FalloffMap}
    public DrawMode drawMode;

    public bool autoUpdate = true;

    public Material terrainMaterial;

    public MeshSettings meshSettings;
    public HeightMapSettings heightMapSettings;
    public TextureData textureData;

    [Range(0, MeshSettings.numSupportedLods)]
    public int editorPreviewLevelOfDetail;

    float[,] fallOffMap;
    bool falloffMapGenerated;


    void OnValuesUpdated()
    {
        if (!Application.isPlaying)
            DrawMapInEditor();
    }

    void OnTextureValuesUpdated()
    {
        textureData.ApplyToMaterial(terrainMaterial);
    }
    
    public void DrawMapInEditor()
    {
        textureData.UpdateMeshHeight(terrainMaterial, heightMapSettings.minHeight, heightMapSettings.maxHeight);

        HeightMap heightMap = HeightMapGenerator.GenerateHeightMap(meshSettings.numberOfVerticesPerLine,
            meshSettings.numberOfVerticesPerLine, heightMapSettings, Vector2.zero);
        LevelDisplay display = FindObjectOfType<LevelDisplay>();
        //Chooses to draw the raw or the coloured noise map 
        if (drawMode == DrawMode.NoiseMap)
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(heightMap.values));
        else if (drawMode == DrawMode.Mesh)
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(heightMap.values, meshSettings, editorPreviewLevelOfDetail));
        else if (drawMode == DrawMode.FalloffMap)
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(FalloffGen.GenerateFalloffMap(meshSettings.numberOfVerticesPerLine)));
    }

    void OnValidate()
    {
        if (meshSettings != null)
        {
            meshSettings.OnValuesUpdated -= OnValuesUpdated;
            meshSettings.OnValuesUpdated += OnValuesUpdated;
        }

        if (heightMapSettings != null)
        {
            heightMapSettings.OnValuesUpdated -= OnValuesUpdated;
            heightMapSettings.OnValuesUpdated += OnValuesUpdated;
        }
        if (textureData != null)
        {
            textureData.OnValuesUpdated -= OnTextureValuesUpdated;
            textureData.OnValuesUpdated += OnTextureValuesUpdated;
        }

        falloffMapGenerated = false;
    }
}