using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{    
    #region Properties
	#endregion

	#region Fields
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(transform.up * Time.deltaTime * 5, Space.World);
    }
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion   
}
