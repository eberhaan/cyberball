using UnityEngine;
using System.Collections;

public class SCColorPicker : MonoBehaviour {

	public Transform selectedColorMarker;

	public string defaultMessage = "PICK A COLOR";

	public tk2dTextMesh lblMsg;

	public tk2dSprite swatch;

	private Texture2D swatchTexture;

	public tk2dSlicedSprite preview;
	// Use this for initialization
	void Start () {
		Debug.Log (2);
		lblMsg.text = defaultMessage;
		lblMsg.Commit ();

		swatchTexture = swatch.GetComponent<Renderer>().sharedMaterial.mainTexture as Texture2D;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
						RaycastHit h;
						Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
						if (Physics.Raycast (r, out h)) {
								if (h.collider.name == "Swatch") {
					var pos = swatch.transform.InverseTransformPoint(h.point.x,h.point.y,h.point.z);
					Debug.Log(pos);
					preview.color = swatchTexture.GetPixel((int)((pos.x+.5f)*swatchTexture.width),(int)((pos.y+.5f)*swatchTexture.height));
					selectedColorMarker.position = h.point;				
				}
			}
				}
	}

	IEnumerator SetMessage(string message)
	{
		yield return new WaitForSeconds (.02f);
		Debug.Log (message);
		lblMsg.text = message;
		lblMsg.Commit ();
	}

	void OnColorSelected()
	{
		SendMessageUpwards ("CurrentBoyColor", preview.color);
		this.gameObject.SetActive (false);
	}
}
