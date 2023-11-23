namespace UnityEngine.Extensions
{
    [System.Serializable]
    public abstract class BaseData
    {
        [field: SerializeField] public GizmosData Gizmos { get; private set; }
        [field: SerializeField] public LayerMask LayerMask { get; set; } = -1;
        [field: SerializeField] public Transform Root { get; set; }

        [SerializeField] private Vector3 positionOffset;

        public Vector3 Center
        {
            get => Root == null ? positionOffset : Root.localToWorldMatrix.MultiplyPoint3x4(positionOffset);
            set => positionOffset = value;
        }
    }
}