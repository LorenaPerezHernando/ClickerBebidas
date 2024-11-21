using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PoolSystem : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private PointsElementUI _pointsPrefab;
	private Queue<PointsElementUI> _pointsPool = new Queue<PointsElementUI>();
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion

	#region Public Methods
	public PointsElementUI GetPoints()
	{
		if(_pointsPool.Count > 0)
		{
			return _pointsPool.Dequeue();
		}
		else
		{
			return Instantiate(_pointsPrefab);
		}
	}

	public void AddToPool(PointsElementUI pointsObject, float duration)
	{
		StartCoroutine(DoAddPool(pointsObject, duration));
	}

	private IEnumerator DoAddPool(PointsElementUI pointsObject, float duration)
	{
		yield return new WaitForSeconds(duration);
		pointsObject.gameObject.SetActive(false);
		_pointsPool.Enqueue(pointsObject);
		Debug.Log("Total pool objects: " + _pointsPool.Count);
	}
	#endregion

	#region Private Methods
	#endregion
}
