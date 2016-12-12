using UnityEngine;
using System.Collections;

public class FlickerMaterial : MonoBehaviour {
	public Material mat;
	public Light lit;
	public float deltaCompound;
	public Color color;
	public bool randomColor;

	public float randStart;
	public float randFreq;
	// Use this for initialization
	void Start () {
		mat =  this.GetComponent<Renderer>().material;
		lit = this.GetComponent<Light>();
		Color c = new Color();
		if(randomColor){
			c.r = Random.Range(0.0f, color.r);
			c.g = Random.Range(0.0f, color.g);
			c.b = Random.Range(0.0f, color.b);
			mat.SetColor("_Color", c);
		} else {
			mat.SetColor("_Color", color);
		}
		randStart = Random.Range(0.0f, 1000.0f);
		randFreq = Random.Range(10.0f,30.0f);
	}
	
	// Update is called once per frame
	void Update () {
		Color c = mat.GetColor("_Color");
		deltaCompound += Time.deltaTime;
		c.a = (float)(1+Mathf.Sin((deltaCompound + randStart)*randFreq))/12;

		randFreq = Random.Range(10.0f,30.0f);
		mat.SetColor("_Color",c);
		c.a = 1;
		mat.SetColor("_EmissionColor", c);
		if(lit != null){
			lit.color = c;
		}
		
	}
}
