using System;
using System.Collections.Generic;

using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

using static NPT.Main.StaticValue;

namespace NPT.Main.StartPage
{
    [RequireComponent(typeof(GraphicRaycaster))]
    public class StartingAnimation : MonoBehaviour
    {
        public List<FadeObject> FadeObjects;
        public List<MoveObject> MoveObjects;

        private void Start()
        {
            GetComponent<GraphicRaycaster>().enabled = false;
            AnimationObjectBase lastObject = null;
            foreach (FadeObject o in FadeObjects)
            {
                o.Start(this);
                if (lastObject == null || o.StartingDelay + o.Duration > lastObject.StartingDelay + lastObject.Duration)
                    lastObject = o;
            }
            foreach (MoveObject o in MoveObjects)
            {
                o.Start(this);
                if (lastObject == null || o.StartingDelay + o.Duration > lastObject.StartingDelay + lastObject.Duration)
                    lastObject = o;
            }
            StartCoroutine(DelayInvoke(StartRaycast, lastObject.StartingDelay + lastObject.Duration));
        }

        private void StartRaycast()
        {
            GetComponent<GraphicRaycaster>().enabled = true;
        }
    }

    public abstract class AnimationObjectBase
    {
        public float StartingDelay, Duration;
        public abstract void Start(MonoBehaviour sender);
        public abstract void StartTween();
    }

    public abstract class AnimationObject<TObject, TValue> : AnimationObjectBase
    {
        public TObject Target;

        public TValue StartValue, EndValue;
        public Ease Ease;

        public override void Start(MonoBehaviour sender)
        {
            sender.StartCoroutine(DelayInvoke(StartTween, StartingDelay));
        }

        public override abstract void StartTween();
    }

    [Serializable]
    public class FadeObject : AnimationObject<CanvasGroup, float>
    {
        public override void Start(MonoBehaviour sender)
        {
            Target.alpha = StartValue;
            base.Start(sender);
        }

        public override void StartTween()
        {
            Target.DOFade(EndValue, Duration).SetEase(Ease);
        }
    }

    [Serializable]
    public class MoveObject : AnimationObject<RectTransform, Vector2>
    {
        public override void Start(MonoBehaviour sender)
        {
            Target.anchoredPosition = StartValue;
            base.Start(sender);
        }

        public override void StartTween()
        {
            Target.DOAnchorPos(EndValue, Duration).SetEase(Ease);
        }
    }
}
