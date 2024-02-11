# Unity Extensions
[![License](https://img.shields.io/github/license/evgjeniy/unity-extensions?color=318CE7&style=flat-square)](LICENSE.md)
[![Version](https://img.shields.io/github/package-json/v/evgjeniy/unity-extensions?color=318CE7&style=flat-square)](package.json)
[![Unity](https://img.shields.io/badge/Unity-2019.1+-2296F3.svg?color=318CE7&style=flat-square)](https://unity.com/)

<h3>Useful extensions for programming games using Unity Engine</h3>

# Navigation
- [Get Started](#get-started)
- [How to use](#how-to-use)
  - [Base](#base)
    - [Enable Extensions](#enable-extensions)
    - [Instantiate Extensions](#instantiate-extensions)
    - [Invoke Extensions](#invoke-extensions)
    - [Null Check Extensions](#null-check-extensions)
    - [Parent Extensions](#base-unity-extensions)
  - [Gizmos](#gizmos)
  - [Overlap](#overlap)
    - [Overlap Data](#overlap-data)
    - [Overlap Extensions](#overlap-extensions)
  - [MonoCashed](#monocashed) 

# Get Started
**Installation options:**
- Copy git URL `https://github.com/evgjeniy/unity-extensions.git` in the **Unity Package Manager**
- Add `"com.evgjeniy.unityextensions": "https://github.com/evgjeniy/unity-extensions.git"` in `Packages/manifest.json`
- Or just clone the `Runtime` and `Editor` folders somewhere inside the `Assets` folder in your project
# How to use
## Base
### Enable Extensions
Use `Activate()`, `Deactivate()` methods instead of `gameObject.SetActive(true / false)` for game objects or components attached to this game objects.  
Use `Enable()`, `Disable()` methods instead of `component.enable = true / false` for components.

Example:
```csharp
[RequireComponent(typeof(CharacterController))]
public class EnableExample : MonoBehaviour
{
    private CharacterController _controller;

    private void Awake() => _controller = GetComponent<CharacterController>();
    
    private void OnEnable() => _controller.Enable(); // _controller.enable = true;
    
    private void OnDisable() => _controller.Disable(); // _controller.enable = false;

    public void Respawn() => gameObject.Activate(); // gameObject.SetActive(true);
    
    public void Death() => gameObject.Deactivate(); // gameObject.SetActive(false);
}
```
### Instantiate Extensions
Use `Spawn()`, `DestroyObject()` or `DestroyComponent()` methods instead of `Object.Instantiate()` and `Object.Destroy()`.

Example:
```csharp
public class InstantiateExample : MonoBehaviour
{
    [SerializeField] private Image imagePrefab;
    [SerializeField] private Transform parent;
    [SerializeField, Min(0)] private int amount;

    public void SpawnObjects()
    {
        for (var i = 0; i < amount; i++)
        {
            // var instance = Object.Instantiate(imagePrefab);
            var instance = imagePrefab.Spawn(Vector3.zero, Quaternion.identity, parent);
            instance.color = Color.white;
            
            // destroy the Image component after 5 seconds
            instance.DestroyComponent(5.0f);
        }
    }
}
```
Overloads `where T : UnityEngine.Object`:
```csharp
public static T Spawn<T>(this T prefab, Transform parent = null)
public static T Spawn<T>(this T prefab, Vector3 position, Transform parent = null)
public static T Spawn<T>(this T prefab, Vector3 position, Quaternion quaternion, Transform parent = null)

public static void DestroyObject(this Component component, float delay = 0.0f)
public static void DestroyObject(this GameObject gameObject, float delay = 0.0f)

public static void DestroyComponent(this Component component, float delay = 0.0f)
public static void DestroyComponent<T>(this GameObject gameObject, float delay = 0.0f)
```
### Invoke Extensions
```csharp
public static void InvokeNextFrame<T>(this T context, Action<T> action) where T : MonoBehaviour

public static void InvokeDelayed<T>(this T context, Action<T> action, float delay) where T : MonoBehaviour

public static T GetOrAddComponent<T>(this GameObject gameObject, Action<T> setupAction = null) where T : Component

public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
```
### Null Check Extensions
`where T : UnityEngine.Object`
```csharp
public static void IfNotNull<T>(this T component, Action<T> ifNotNull)

public static T IfNotNull<T>(this T component, Func<T> ifNotNull)

public static void IfNull<T>(this T component, Action<T> ifNull)

public static T IfNull<T>(this T component, Func<T> ifNull)
```
### Parent Extensions
```csharp
public static void SetParent(this GameObject target, GameObject parent)
public static void SetParent(this GameObject target, Component parent)
public static void SetParent(this Component target, GameObject parent)
public static void SetParent(this Component target, Component parent)
    
public static void ClearParent(this GameObject target)
public static void ClearParent(this Component target)
```
## Gizmos
- Declare the `GizmosData` field
- Invoke `DrawSphere`, `DrawBox`, `DrawRay` or `DrawMesh` methods from `OnDrawGizmos` or `OnDrawGizmosSelected` methods
- Setup `Type` and `Color` from **Unity Inspector**
```csharp
public class GizmosExample : MonoBehaviour
{
    [SerializeField] private GizmosData gizmos;

    private void OnDrawGizmos() => gizmos.DrawSphere(transform.position, 0.25f);
}
```
## Overlap
### Overlap Data
- Declare the `SphereData`, `BoxData` or `RayData` fields
- Invoke `DrawGizmos` method from `OnDrawGizmos` or `OnDrawGizmosSelected` methods
- Setup them from **Unity Inspector**

Example:
```csharp
public class OverlapDataGizmosExample : MonoBehaviour
{
    [SerializeField] private SphereData sphere;
    [SerializeField] private BoxData box;
    [SerializeField] private RayData ray;

    private void OnDrawGizmosSelected()
    {
        sphere.DrawGizmos();
        box.DrawGizmos();
        ray.DrawGizmos();
    }
}
```
Preview:

![unity-extensions-overlap-preview](https://github.com/evgjeniy/unity-extensions/assets/90873710/a879b048-a3c1-40b3-a3b3-6b1dfc016a93)

### Overlap Extensions
Use Overlap Extensions instead of `Physics` methods with help of Overlap Data configured from **Unity Inspector**

Example:
```csharp
public class OverlapExample : MonoBehaviour
{
    [SerializeField] private SphereData sphere;
    [SerializeField] private BoxData box;
    [SerializeField] private RayData ray;

    private RaycastHit[] _hits = new RaycastHit[32];
    
    public void TestOverlap()
    {
        bool checkResult = sphere.Check(); // Physics.CheckSphere()

        // Physics.OverlapBox()
        foreach (var overlappedCollider in box.Overlap())
            Debug.Log(overlappedCollider.name);

        // Physics.RaycastNonAlloc()
        int nonAllocSize = ray.RaycastNonAlloc(_hits);
        for (int i = 0; i < nonAllocSize; i++)
            Debug.Log(_hits[i].point);
    }
}
```

## MonoCashed

`MonoCashed` class caches generic components attached to the GameObject in `Awake` method.
Contains the properties `Cashed1`, `Cashed2`, ... `Cashed8` generic properties
representing access to cached components respectively. Repeats all methods and properties
of the `Transform` class.

Instead of this `Awake` cashing:

```csharp
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(IInputSystem))]
public class MonoCashedSample : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private IInputSystem _inputSystem;
    private float _moveSpeed = 5.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputSystem = GetComponent<IInputSystem>();
        
        _moveSpeed = 5.0f;
    }

    private void Update()
    {
        _rigidbody.velocity = _inputSystem.MoveDirection * (_moveSpeed * Time.deltaTime);
    }
}
```

Use `MonoCashed` class:

```csharp
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(IInputSystem))]
public class MonoCashedSample : MonoCashed<Rigidbody, IInputSystem>
{
    private float _moveSpeed;
    
    protected override void PostAwake() => _moveSpeed = 5.0f;
 /* or
    protected override void Awake() { base.Awake(); _moveSpeed = 5.0f; } */

    private void Update() => Cashed1.velocity = Cashed2.MoveDirection * (_moveSpeed * Time.deltaTime);
}
```