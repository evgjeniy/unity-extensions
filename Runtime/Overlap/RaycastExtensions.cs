namespace UnityEngine.Extensions
{
    public static class RaycastExtensions
    {
        public static bool Raycast(this RayData ray, out RaycastHit hit, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.Raycast
        (
            ray.Center, ray.Direction, out hit, ray.MaxDistance, ray.LayerMask.value, qti
        );

        public static bool Raycast(this RayData ray, out RaycastHit hit, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.Raycast
        (
            ray.Center, ray.Direction, out hit, ray.MaxDistance, mask.value, qti
        );

        public static bool Raycast(this BaseData baseData, Vector3 direction, out RaycastHit hit, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.Raycast
        (
            baseData.Center, direction, out hit, direction.magnitude, baseData.LayerMask.value, qti
        );

        public static bool Raycast(this BaseData baseData, Vector3 direction, out RaycastHit hit, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.Raycast
        (
            baseData.Center, direction, out hit, direction.magnitude, mask.value, qti
        );

        public static RaycastHit[] RaycastAll(this RayData ray, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.RaycastAll
        (
            ray.Center, ray.Direction, ray.MaxDistance, ray.LayerMask.value, qti
        );

        public static RaycastHit[] RaycastAll(this RayData ray, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.RaycastAll
        (
            ray.Center, ray.Direction, ray.MaxDistance, mask.value, qti
        );

        public static RaycastHit[] RaycastAll(this BaseData baseData, Vector3 direction, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.RaycastAll
        (
            baseData.Center, direction, direction.magnitude, baseData.LayerMask.value, qti
        );

        public static RaycastHit[] RaycastAll(this BaseData baseData, Vector3 direction, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.RaycastAll
        (
            baseData.Center, direction, direction.magnitude, mask.value, qti
        );

        public static int RaycastNonAlloc(this RayData ray, RaycastHit[] hits, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.RaycastNonAlloc
        (
            ray.Center, ray.Direction, hits, ray.MaxDistance, ray.LayerMask.value, qti
        );

        public static int RaycastNonAlloc(this RayData ray, RaycastHit[] hits, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.RaycastNonAlloc
        (
            ray.Center, ray.Direction, hits, ray.MaxDistance, mask.value, qti
        );

        public static int RaycastNonAlloc(this BaseData baseData, Vector3 direction, RaycastHit[] hits, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.RaycastNonAlloc
        (
            baseData.Center, direction, hits, direction.magnitude, baseData.LayerMask.value, qti
        );

        public static int RaycastNonAlloc(this BaseData baseData, Vector3 direction, RaycastHit[] hits, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.RaycastNonAlloc
        (
            baseData.Center, direction, hits, direction.magnitude, mask.value, qti
        );

        public static bool Linecast(this BaseData baseData, Vector3 endPoint, out RaycastHit hit, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.Linecast
        (
            baseData.Center, endPoint, out hit, baseData.LayerMask.value, qti
        );

        public static bool Linecast(this BaseData baseData, Vector3 endPoint, out RaycastHit hit, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.Linecast
        (
            baseData.Center, endPoint, out hit, mask.value, qti
        );

        public static bool Linecast(this RayData ray, out RaycastHit hit, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.Linecast
        (
            ray.Center, ray.Center + ray.Direction * ray.MaxDistance, out hit, ray.LayerMask.value, qti
        );

        public static bool Linecast(this RayData ray, out RaycastHit hit, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.Linecast
        (
            ray.Center, ray.Center + ray.Direction * ray.MaxDistance, out hit, mask.value, qti
        );
    }
}