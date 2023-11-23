namespace UnityEngine.Extensions
{
    [System.Serializable]
    public class BoxData : BaseData
    {
        [SerializeField, Min(0.0f)] private Vector3 size = Vector3.one;

        public Vector3 Size
        {
            get => Root == null ? size : Vector3.Scale(Root.lossyScale, size);
            set
            {
                if (size.x < 0 || size.y < 0 || size.z < 0) return;
                size = value;
            }
        }

        public Quaternion Orientation => Root == null ? Quaternion.identity : Root.rotation;
    }
    
    [System.Serializable]
    public class MeshData : BoxData
    {
        [field: SerializeField] public Mesh Mesh { get; set; }
    }
}