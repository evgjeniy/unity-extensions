namespace UnityEngine.Extensions
{
    [System.Serializable]
    public class BoxData : BaseData
    {
        [SerializeField, Min(0.0f)] private Vector3 _size = Vector3.one;

        public Vector3 Size
        {
            get => Root == null ? _size : Vector3.Scale(Root.lossyScale, _size);
            set
            {
                if (_size.x < 0 || _size.y < 0 || _size.z < 0) return;
                _size = value;
            }
        }

        public Quaternion Orientation
        {
            get => Root == null ? Quaternion.identity : Root.rotation;
            set { if (Root != null) Root.rotation = value; }
        }
    }

    [System.Serializable]
    public class MeshData : BoxData
    {
        [field: SerializeField] public Mesh Mesh { get; set; }
    }
}