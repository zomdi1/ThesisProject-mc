using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BiomeAttributes", menuName = "Minecraft/Biome Attributes")]
public class BiomeAttribute : ScriptableObject
{
    public string biomeName;

    public int solidGroundHeight;
    public int terrainHeight; //height of terrain from the solid ground to how high the highest point of your terrain can be
    public float terrainScale;

    public Lode[] lodes;
}

[System.Serializable]
public class Lode
{
    public string nodeName;
    public byte blockID;
    public int minHeight;
    public int maxHeight;
    public float scale;
    public float threshold;
    public float noiseOffset; //preventing repeating noise result
}
