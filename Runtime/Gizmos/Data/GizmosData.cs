namespace UnityEngine.Extensions
{
    [System.Serializable]
    public class GizmosData
    {
        [System.Flags] public enum DrawType : byte { Wire = 1, Solid = 2 }

        public DrawType drawType = DrawType.Wire;
        public Color gizmosColor = new (1.0f, 1.0f, 1.0f, 0.5f);
    }
}