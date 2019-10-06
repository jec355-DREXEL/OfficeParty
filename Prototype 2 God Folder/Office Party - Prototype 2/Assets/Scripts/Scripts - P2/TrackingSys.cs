using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSys : MonoBehaviour {

    public float speed = 3.0f;
    public GameObject m_target;
    private Vector3 m_LastKnownPos = Vector3.zero;
    private Quaternion m_lookAtRotation;
    public bool lockedOn = false;
	
	// Update is called once per frame
	void Update () {
        if (m_target)
        {
            if (m_LastKnownPos != m_target.transform.position)
            {
                m_LastKnownPos = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_LastKnownPos - transform.position);
            }

            if (transform.rotation != m_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            }
        }
	}
    bool SetTarget(GameObject target)
    {
        if (target)
        {
            return false;
        }

        m_target = target;

        return true;
    }

    void OnTriggerEnter(Collider d)
    {
        if (d.gameObject.tag == "Player")
        {
            lockedOn = true;
            m_target = d.gameObject;
        }
    }
    void OnTriggerExit(Collider d)
    {
        if (d.gameObject.tag == "Player")
        {
            Debug.Log("im getting here");
            m_target = null;
            lockedOn = false;
        }
    }
}
