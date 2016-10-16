using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	//rotation
	public float mouseSensivity = 0.0F;
	private float rotationX = 0.0F;
	private float rotationY = 0.0F;
	private float currentRotationX = 0.0F;
	private float currentRotationY = 0.0F;
	private float rotationSpeedX = 0.0F;
	private float rotationSpeedY = 0.0F;
	
	// Update is called once per frame
	void Update () {


		//camera rotation
		//mouse movement: Rotating on x is like looking up and down, rotating on y is like looking left and right
		this.rotationX -= Input.GetAxis ("Mouse Y") * this.mouseSensivity;	//Get the mouse movement on the y axis, so rotation on x axis can be done, mouse sensivity can be specified here aswell
		this.rotationY += Input.GetAxis ("Mouse X") * this.mouseSensivity;	//Get the mouse movement on the x axis, so rotation on the y axis can be done
		this.rotationX = Mathf.Clamp (rotationX, -90.0F, 90.0F);	//Locks the rotation on the x axis between the very down and up view (-90 and 90)
		this.currentRotationX = Mathf.SmoothDamp (this.currentRotationX, this.rotationX, ref this.rotationSpeedX, 0.1F);	//smoothly/gradually changes the current rotation x to the new rotation x with rotation speed x
		this.currentRotationY = Mathf.SmoothDamp (this.currentRotationY, this.rotationY, ref this.rotationSpeedY, 0.1F);	//same here, just with y

		this.transform.rotation = Quaternion.Euler (this.currentRotationX, this.currentRotationY, 0.0F);	//rotates with the calculated values -> note: Z - Rotation will always be set to 0.0F, otherwise rotation would be weird

	}

}