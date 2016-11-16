using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainGenerator : MonoBehaviour {

	public TerrainData myTerrainData;

	public Vector3 worldSize;
	public int resolution = 513;
	public Texture2D myTexture;
	private float[,] terrainRand;
	public float timeStep = 0.01f;
	public float startTime = 0.0f;
	public float speed = 1;
	// Use this for initialization
	void Start () {

		//This is where we set our public variables to the terrain
		//meaning we change it's size, and resolution
		TerrainCollider data = gameObject.GetComponent<TerrainCollider> ();
		if (data != null) {
			myTerrainData = data.terrainData;
			myTerrainData.size = worldSize;
			myTerrainData.heightmapResolution = resolution;
		}

		//This is where we change the heightmap
		//the heightmap array size is based onresolution

		GenerateTerrain ();

		//this is where we set the texture of the terrain
		SplatPrototype[] terrainTexture = new SplatPrototype[1];
		terrainTexture [0] = new SplatPrototype ();
		terrainTexture [0].texture = myTexture;
		myTerrainData.splatPrototypes = terrainTexture;
	}

	public float GetHeight(Vector3 position)
	{
		return Terrain.activeTerrain.SampleHeight (position);
	}

	public void GenerateTerrain(){

		float xValue = 0f;
		float yValue = 0f;
		terrainRand = new float[resolution,resolution];
		for (int i = 0; i < resolution; i++) {
			yValue += timeStep;
			for (int j = 0; j < resolution; j++) {
				//terrainRand[i,j] = Mathf.PerlinNoise((float)i/(float)resolution, (float)j/(float)resolution);
				
				xValue += timeStep;
				terrainRand[i,j] = Mathf.PerlinNoise(xValue, yValue);
			}
			xValue = 0.0f;
		}
		myTerrainData.SetHeights (0, 0, terrainRand);
	}

	// Update is called once per frame
	void Update () {

	}
}
