using UnityEngine;

namespace whereisright
{
    public static class TransformExtension
    {
        public static void DestroyAllChilds(this Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                MonoBehaviour.Destroy(transform.GetChild(i).gameObject);
            }
        }

        public static void DestroyAllChilds(this RectTransform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                MonoBehaviour.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}