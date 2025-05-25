using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private Dictionary<Vector2Int, IGridObject> _objects = new ();

    public void Bind(IGridObject gridObject, Vector2Int coordinates)
    {
		if (_objects.ContainsKey(coordinates))
			return;	

		gridObject.BindTo(new Vector3(coordinates.x, 0, coordinates.y));
		_objects.Add(coordinates, gridObject);
	}
}
