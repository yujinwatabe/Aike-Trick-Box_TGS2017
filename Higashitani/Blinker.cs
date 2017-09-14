using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour {
	[SerializeField]
	private Renderer rend;

	[HideInInspector] public Color color;

	[SerializeField] private float interval = 0.5f;
    [SerializeField]
	phasechange phase;

	// Use this for initialization
	void Start () {
		SearchRnderer (transform);
		phase = Camera.main.GetComponent<phasechange> ();
	}

	// Update is called once per frame
	void Update () {
		if (!phase.GetMode) {
			float val = Mathf.PingPong (Time.time / 2, interval);
			color = new Color (0f, 0.5f - val, 0f);    //Green + Alpha-Channel
			rend.material.SetColor ("_EmissionColor", color);
		} else {
			ResetColor ();
		}
	}
	//再起プログラム
	void SearchRnderer (Transform targetT){	
		if (targetT.childCount != 0) { 					//対象（その階層）の子オブジェクトがあるなら
			foreach (Transform t in targetT) { 			//子をtに入れていく
				if (t.GetComponent<Renderer> ()) {	 	//tにrendererがあるなら
					rend = t.GetComponent<Renderer>();
					return;
				} else {						  	 	//tにrendererがないなら子を一つ降り、再起
					SearchRnderer (t);
				}
			}
		} else {					   					//子がいない場合
			return;
		}
	}

	private void ResetColor(){
		if (color != new Color (0, 0, 0)) {
			color = new Color (0, 0, 0);
			rend.material.SetColor ("_EmissionColor", color);
		}
	}

	void OnDestroy(){
		ResetColor ();
	}
}
