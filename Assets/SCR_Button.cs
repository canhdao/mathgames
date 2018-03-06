using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SCR_Button : Button {
	protected float[] bottoms;
	protected float[] tops;

	protected override void Start () {
		bottoms = new float[transform.childCount];
		tops = new float[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild (i);
			RectTransform rectTransform = child.GetComponent<RectTransform> ();

			bottoms[i] = rectTransform.offsetMin.y;
			tops[i] = rectTransform.offsetMax.y;
		}
	}

	protected override void DoStateTransition (Selectable.SelectionState state, bool instant)
	{
		base.DoStateTransition (state, instant);

		if (tops != null) {
			for (int i = 0; i < transform.childCount; i++) {
				float bottom = bottoms [i];
				float top = tops [i];

				if (state == Selectable.SelectionState.Pressed) {
					bottom -= 20;
					top -= 20;
				}

				Transform child = transform.GetChild (i);
				RectTransform rectTransform = child.GetComponent<RectTransform> ();

				rectTransform.offsetMin = new Vector2 (rectTransform.offsetMin.x, bottom);
				rectTransform.offsetMax = new Vector2 (rectTransform.offsetMax.x, top);
			}
		}
	}
}
