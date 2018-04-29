using UnityEngine;

namespace LD41
{
    public class BulletHellUtil : MonoBehaviour
    {
        public static GameObject InstantiatePrefabWithParent(GameObject prefab, GameObject parent)
        {
            GameObject instantiated = Instantiate(prefab);
            if (instantiated == null)
            {
                return null;
            }

            var localPos = instantiated.transform.localPosition;
            var localRot = instantiated.transform.localRotation;
            var localScale = instantiated.transform.localScale;
            instantiated.transform.parent = parent.transform;
            instantiated.transform.localPosition = localPos;
            instantiated.transform.localRotation = localRot;
            instantiated.transform.localScale = localScale;
            return instantiated;
        }

        public static GameObject CallFunctionAfterTime(float time, UnityEngine.Events.UnityAction func)
        {
            GameObject caller = new GameObject("Func Caller - " + time.ToString() + " seconds");
            DestroyInvoker invoker = caller.AddComponent(typeof(DestroyInvoker)) as DestroyInvoker;
            invoker.onDestroyCallback = func;
            GameObject.Destroy(caller, time);

            return caller;
        }

        public static GameObject CallFunctionForTime(float time, UnityEngine.Events.UnityAction func)
        {
            GameObject caller = new GameObject("Func Caller - " + time.ToString() + " seconds");
            DestroyInvoker invoker = caller.AddComponent(typeof(DestroyInvoker)) as DestroyInvoker;
            invoker.onUpdateCallback = func;

            if (time != -1)
            {
                GameObject.Destroy(caller, time);
            }

            return caller;
        }

        public static void CancelFunctionHandler(GameObject funcHandler)
        {
            DestroyInvoker invoker = funcHandler.GetComponent<DestroyInvoker>();
            if (invoker != null)
            {
                invoker.onDestroyCallback = null;
            }
        }
    }
}
