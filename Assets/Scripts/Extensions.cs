using UnityEngine;
using System.Collections;
 
public static class Extensions
{
	public static Transform Search(this Transform target, string name)
	{
		if (target.name == name) return target;
		
		for (int i = 0; i < target.childCount; ++i)
		{
			var result = Search(target.GetChild(i), name);
			
			if (result != null) return result;
		}
		
		return null;
	}

	public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}

	public static Bounds OrthographicBounds(this Camera camera)
	{
		float screenAspect = (float)Screen.width / (float)Screen.height;
		float cameraHeight = camera.orthographicSize * 2;
		Bounds bounds = new Bounds(
			camera.transform.position,
			new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
		return bounds;
	}
}
