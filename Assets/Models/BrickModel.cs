using Assets.Enums;
using UnityEngine;

namespace Assets.Models
{
    public class BrickModel
    {
        public BrickModel()
        {
            Hits = 0;
        }

        public int Id { get; set; }
        public GameObject Brick { get; set; }
        public Vector2 Position { get; set; }
        public BrickType BrickType { get; set; }
        public int Hits { get; set; }
    }
}