using UnityEngine;

namespace _Game.RSNCore.Extensions
{
    public static class TransformExtensions
    {
        public static void Show(this Component component) => component.gameObject.SetActive(true);

        public static void Show(this GameObject gameObj) => gameObj.SetActive(true);

        public static void Hide(this Component component) => component.gameObject.SetActive(false);

        public static void Hide(this GameObject gameObj) => gameObj.SetActive(false);

        public static void SafeShow(this Component component)
        {
            if (!(bool)(Object)component || (bool)(Object)component.gameObject)
                return;
            component.gameObject.SetActive(true);
        }

        public static void SafeShow(this GameObject gameObj)
        {
            if (!(bool)(Object)gameObj)
                return;
            gameObj.SetActive(true);
        }

        public static void SafeHide(this Component component)
        {
            if (!(bool)(Object)component || (bool)(Object)component.gameObject)
                return;
            component.gameObject.SetActive(false);
        }

        public static void SafeHide(this GameObject gameObj)
        {
            if (!(bool)(Object)gameObj)
                return;
            gameObj.SetActive(false);
        }

        public static void SetLocalPosition(this GameObject go, Vector3 newLocalPosition)
        {
            go.transform.localPosition = newLocalPosition;
        }

        public static void SetLocalPosition(this GameObject go, float? x = null, float? y = null, float? z = null)
        {
            var transform = go.transform;
            var localPosition = transform.localPosition;
            ref var local1 = ref localPosition;
            var nullable = x;
            var num1 = (double?)nullable ?? localPosition.x;
            local1.x = (float)num1;
            ref var local2 = ref localPosition;
            nullable = y;
            var num2 = (double?)nullable ?? localPosition.y;
            local2.y = (float)num2;
            ref var local3 = ref localPosition;
            nullable = z;
            var num3 = (double?)nullable ?? localPosition.z;
            local3.z = (float)num3;
            transform.localPosition = localPosition;
        }

        public static void SetLocalPosition(this Component cp, Vector3 newLocalPosition)
        {
            cp.gameObject.SetLocalPosition(newLocalPosition);
        }

        public static void SetLocalPosition(this Component cp, float? x = null, float? y = null, float? z = null)
        {
            cp.gameObject.SetLocalPosition(x, y, z);
        }

        public static void SetPosition(this GameObject go, Vector3 newPosition)
        {
            go.transform.position = newPosition;
        }

        public static void SetPosition(this GameObject go, float? x = null, float? y = null, float? z = null)
        {
            var transform = go.transform;
            var position = transform.position;
            ref var local1 = ref position;
            var nullable = x;
            var num1 = (double?)nullable ?? position.x;
            local1.x = (float)num1;
            ref var local2 = ref position;
            nullable = y;
            var num2 = (double?)nullable ?? position.y;
            local2.y = (float)num2;
            ref var local3 = ref position;
            nullable = z;
            var num3 = (double?)nullable ?? position.z;
            local3.z = (float)num3;
            transform.position = position;
        }

        public static void SetPosition(this Component cp, Vector3 newPosition)
        {
            cp.gameObject.SetPosition(newPosition);
        }

        public static void SetPosition(this Component cp, float? x = null, float? y = null, float? z = null)
        {
            cp.gameObject.SetPosition(x, y, z);
        }

        public static void SetLocalRotation(this GameObject go, Quaternion newLocalRotation)
        {
            go.transform.localRotation = newLocalRotation;
        }

        public static void SetLocalRotation(this GameObject go, Vector3 newLocalRotation)
        {
            go.transform.localRotation = Quaternion.Euler(newLocalRotation);
        }

        public static void SetLocalRotation(this Component cp, Quaternion newLocalRotation)
        {
            cp.gameObject.SetLocalRotation(newLocalRotation);
        }

        public static void SetLocalRotation(this Component cp, Vector3 newLocalRotation)
        {
            cp.gameObject.SetLocalRotation(newLocalRotation);
        }

        public static void SetRotation(this GameObject go, Quaternion newLocalRotation)
        {
            go.transform.rotation = newLocalRotation;
        }

        public static void SetRotation(this GameObject go, Vector3 newLocalRotation)
        {
            go.transform.rotation = Quaternion.Euler(newLocalRotation);
        }

        public static void SetRotation(this Component cp, Quaternion newLocalRotation)
        {
            cp.gameObject.SetRotation(newLocalRotation);
        }

        public static void SetRotation(this Component cp, Vector3 newLocalRotation)
        {
            cp.gameObject.SetRotation(newLocalRotation);
        }

        public static void SetEulerAngles(this GameObject go, float? x = null, float? y = null, float? z = null)
        {
            var transform = go.transform;
            var eulerAngles = transform.eulerAngles;
            ref var local1 = ref eulerAngles;
            var nullable = x;
            var num1 = (double?)nullable ?? eulerAngles.x;
            local1.x = (float)num1;
            ref var local2 = ref eulerAngles;
            nullable = y;
            var num2 = (double?)nullable ?? eulerAngles.y;
            local2.y = (float)num2;
            ref var local3 = ref eulerAngles;
            nullable = z;
            var num3 = (double?)nullable ?? eulerAngles.z;
            local3.z = (float)num3;
            transform.eulerAngles = eulerAngles;
        }

        public static void SetEulerAngles(this GameObject go, Vector3 eulerAngles)
        {
            go.transform.eulerAngles = eulerAngles;
        }

        public static void SetEulerAngles(this Component cp, Vector3 eulerAngles)
        {
            cp.gameObject.SetEulerAngles(eulerAngles);
        }

        public static void SetEulerAngles(this Component cp, float? x = null, float? y = null, float? z = null)
        {
            cp.gameObject.SetEulerAngles(x, y, z);
        }

        public static void SetLocalEulerAngles(this GameObject go, float? x = null, float? y = null, float? z = null)
        {
            var transform = go.transform;
            var localEulerAngles = transform.localEulerAngles;
            ref var local1 = ref localEulerAngles;
            var nullable = x;
            var num1 = (double?)nullable ?? localEulerAngles.x;
            local1.x = (float)num1;
            ref var local2 = ref localEulerAngles;
            nullable = y;
            var num2 = (double?)nullable ?? localEulerAngles.y;
            local2.y = (float)num2;
            ref var local3 = ref localEulerAngles;
            nullable = z;
            var num3 = (double?)nullable ?? localEulerAngles.z;
            local3.z = (float)num3;
            transform.localEulerAngles = localEulerAngles;
        }

        public static void SetLocalEulerAngles(this GameObject go, Vector3 eulerAngles)
        {
            go.transform.localEulerAngles = eulerAngles;
        }

        public static void SetLocalEulerAngles(this Component cp, float? x = null, float? y = null, float? z = null)
        {
            cp.gameObject.SetLocalEulerAngles(x, y, z);
        }

        public static void SetLocalEulerAngles(this Component cp, Vector3 eulerAngles)
        {
            cp.gameObject.SetLocalEulerAngles(eulerAngles);
        }

        public static void SetScale(this GameObject go, float? x = null, float? y = null, float? z = null)
        {
            var transform = go.transform;
            var localScale = transform.localScale;
            ref var local1 = ref localScale;
            var nullable = x;
            var num1 = (double?)nullable ?? localScale.x;
            local1.x = (float)num1;
            ref var local2 = ref localScale;
            nullable = y;
            var num2 = (double?)nullable ?? localScale.y;
            local2.y = (float)num2;
            ref var local3 = ref localScale;
            nullable = z;
            var num3 = (double?)nullable ?? localScale.z;
            local3.z = (float)num3;
            transform.localScale = localScale;
        }

        public static void SetScale(this GameObject go, Vector3 scale)
        {
            go.transform.localScale = scale;
        }

        public static void SetScale(this Component cp, float? x = null, float? y = null, float? z = null)
        {
            cp.gameObject.SetScale(x, y, z);
        }

        public static void SetScale(this Component cp, Vector3 scale) => cp.gameObject.SetScale(scale);
    }
}