using UnityEngine;

public class GradientBackground : MonoBehaviour {
	
	public Color topColor = Color.blue;
	public Color bottomColor = Color.white;
	public int gradientLayer = 7;

	void Start()
	{
		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = 4.0f / 3.0f;
		
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		
		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();
		
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{  
			Rect rect = camera.rect;
			
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			
			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;
			
			Rect rect = camera.rect;
			
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			
			camera.rect = rect;
		}
	}

	void Awake () {	
		gradientLayer = Mathf.Clamp(gradientLayer, 0, 31);
		if (!camera) {
			Debug.LogError ("Must attach GradientBackground script to the camera");
			return;
		}
		
		camera.clearFlags = CameraClearFlags.Depth;
		camera.cullingMask = camera.cullingMask & ~(1 << gradientLayer);
		Camera gradientCam = new GameObject("Gradient Cam",typeof(Camera)).camera;
		gradientCam.depth = camera.depth-1;
		gradientCam.cullingMask = 1 << gradientLayer;
		
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[4]
		{new Vector3(-100f, .577f, 1f), new Vector3(100f, .577f, 1f), new Vector3(-100f, -.577f, 1f), new Vector3(100f, -.577f, 1f)};
		
		mesh.colors = new Color[4] {topColor,topColor,bottomColor,bottomColor};
		
		mesh.triangles = new int[6] {0, 1, 2, 1, 3, 2};
		
		Material mat = new Material("Shader \"Vertex Color Only\"{Subshader{BindChannels{Bind \"vertex\", vertex Bind \"color\", color}Pass{}}}");
		GameObject gradientPlane = new GameObject("Gradient Plane", typeof(MeshFilter), typeof(MeshRenderer));
		
		((MeshFilter)gradientPlane.GetComponent(typeof(MeshFilter))).mesh = mesh;
		gradientPlane.renderer.material = mat;
		gradientPlane.layer = gradientLayer;
	}
	
}