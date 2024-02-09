namespace UnityEngine.Extensions
{
    [System.Serializable]
    public abstract class BaseData
    {
        [field: SerializeField] public GizmosData Gizmos { get; private set; }
        [field: SerializeField] public LayerMask LayerMask { get; set; } = -1;
        [field: SerializeField] public Transform Root { get; set; }
        [field: SerializeField] public Vector3 Offset { get; set; }

        public Vector3 Center
        {
            get => Root == null ? Offset : Root.localToWorldMatrix.MultiplyPoint3x4(Offset);
            set => Offset = value;
        }
    }
}