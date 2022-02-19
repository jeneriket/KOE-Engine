using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Exploration
{
    namespace Managers
    {
        public class TilemapManager : MonoBehaviour
        {
            //public classes
            [System.Serializable]
            public class TilesWithFootsteps
            {
                public List<TileBase> tiles = new List<TileBase>();
                public Movement.FootstepMode setFootstepMode;
            }


            //public fields
            [Header("Managed Tilemaps")]
            public List<Tilemap> groundTileMaps = new List<Tilemap>();

            //private, serialized fields
            [Header("Ground Special Tiles")]
            [SerializeField]
            List<TilesWithFootsteps> groundTilesWithFootsteps = new List<TilesWithFootsteps>();

            //public methods
            public Movement.FootstepMode GetPositionFootstepMode(Vector2 position)
            {
                foreach(Tilemap tilemap in groundTileMaps)
                {
                    TileBase gotTile = tilemap.GetTile(Vector3Int.RoundToInt(position));

                    foreach(TilesWithFootsteps tilesWithFootstepsModule in groundTilesWithFootsteps)
                    {
                        foreach(TileBase tile in tilesWithFootstepsModule.tiles)
                        {
                            if(tile == gotTile)
                                return tilesWithFootstepsModule.setFootstepMode;
                        }
                    }
                }

                return Movement.FootstepMode.Default;
            }
        }
    }
}
