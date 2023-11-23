namespace UnityEngine.Extensions
{
    public static class GizmosDrawingExtension
    {
        private delegate void DrawSphereDelegate(Vector3 center, float radius);
        private delegate void DrawBoxDelegate(Vector3 center, Vector3 size);
        private delegate void DrawMeshDelegate(Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale);
        
        public static void DrawGizmos(this BaseData data)
        {
            switch (data)
            {
                case MeshData mesh: mesh.Gizmos.DrawMesh(mesh.Mesh, mesh.Center, mesh.Orientation, mesh.Size); break;
                case BoxData box: box.Gizmos.DrawBox(box.Center, box.Orientation, box.Size); break;
                case SphereData sphere: sphere.Gizmos.DrawSphere(sphere.Center, sphere.Radius); break;
                case RayData ray: ray.Gizmos.DrawRay(ray.Center, ray.Direction, ray.MaxDistance); break;
            }
        }
        
        public static void DrawRay(this GizmosData gizmos, Vector3 center, Vector3 direction, float maxDistance)
        {
            if (gizmos.drawType == 0) return;

            Gizmos.color = gizmos.gizmosColor;
            Gizmos.DrawRay(center, direction * maxDistance);
        }

        public static void DrawSphere(this GizmosData gizmos, Vector3 center, float radius)
        {
            if (gizmos.drawType == 0) return;

            Gizmos.color = gizmos.gizmosColor;

            DrawSphereDelegate draw = null;
            if ((gizmos.drawType & GizmosData.DrawType.Wire) != 0) draw += Gizmos.DrawWireSphere;
            if ((gizmos.drawType & GizmosData.DrawType.Solid) != 0) draw += Gizmos.DrawSphere;
            draw?.Invoke(center, radius);
        }

        public static void DrawBox(this GizmosData gizmos, Vector3 center, Quaternion orientation, Vector3 size)
        {
            if (gizmos.drawType == 0) return;

            Gizmos.color = gizmos.gizmosColor;
            Gizmos.matrix = Matrix4x4.TRS(center, orientation, Vector3.one);

            DrawBoxDelegate draw = null;
            if ((gizmos.drawType & GizmosData.DrawType.Wire) != 0) draw += Gizmos.DrawWireCube;
            if ((gizmos.drawType & GizmosData.DrawType.Solid) != 0) draw += Gizmos.DrawCube;
            draw?.Invoke(Vector3.zero, size);
            
            Gizmos.matrix = Matrix4x4.identity;
        }

        public static void DrawMesh(this GizmosData gizmos, Mesh mesh, Transform transform) => 
            gizmos.DrawMesh(mesh, transform.position, transform.rotation, transform.lossyScale);

        public static void DrawMesh(this GizmosData gizmos, Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            if (gizmos.drawType == 0 || mesh == null) return;

            Gizmos.color = gizmos.gizmosColor;

            DrawMeshDelegate draw = null;
            if ((gizmos.drawType & GizmosData.DrawType.Wire) != 0) draw += Gizmos.DrawWireMesh;
            if ((gizmos.drawType & GizmosData.DrawType.Solid) != 0) draw += Gizmos.DrawMesh;
            draw?.Invoke(mesh, position, rotation, scale);
        }
    }
}