using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[CustomGridBrush(false, true, false, "GrassBrush")]
public class GrassBrush : GridBrushBase {

	#if UNITY_EDITOR
	[MenuItem("Assets/Create/CustomAssets/GrassBrush",false,0)]
	//This Function is called when you click the menu entry
	private static void CreateGrassBrush()
	{
		string fileName = "GrassBrush";
		GrassBrush mytb = ScriptableObject.CreateInstance<GrassBrush>();
		mytb.name = fileName + ".asset";
		AssetDatabase.CreateAsset(mytb, "Assets/" +mytb.name + "");

	}
	#endif 

	public TileBase[] tiles;
	public string tileMapName;
	public int overflow = 5;

	public override void Paint(GridLayout grid, GameObject layer, Vector3Int position)
	{
		Tilemap tileMap = GetTilemap();

		if (tileMap != null)
		{
			PaintInternal(position, tileMap);
		}
	}

	private void PaintInternal(Vector3Int position, Tilemap tilemap)
	{
		int rnd = Mathf.RoundToInt(Random.Range (0f, tiles.Length + overflow - 1));
		rnd = rnd - overflow < 0 ? 0 : rnd - overflow;
		tilemap.SetTile(position, tiles[rnd]);
	}

	public Tilemap GetTilemap()
	{
		GameObject go = GameObject.Find(tileMapName);
		return go != null ? go.GetComponent<Tilemap>() : null;
	}



}
