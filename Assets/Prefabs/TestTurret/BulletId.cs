using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletId : MonoBehaviour
{
    public GameObject sender;
    private Collider senderCollider;
    public bool simpleMode = false; //Script only returns sender
    public int dmg;
    public bool impactDestroy = true;
    public string[] surfaceTags;
    public GameObject[] impactPrefabs;
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject + " : " + sender);
        if (col.gameObject != sender && !simpleMode)
        {
            for (int i = 0; i < surfaceTags.Length; i++)
            {
                //Debug.Log(col.gameObject.tag + " | " + surfaceTags[i] + " | " + col.gameObject.CompareTag(surfaceTags[i]));
                if (col.gameObject.CompareTag(surfaceTags[i]))
                {
                    ContactPoint impactPos = col.GetContact(0);
                    Debug.DrawRay(transform.position, transform.forward, Color.white);
                    Vector3 pos = impactPos.point;
                    Quaternion rot = Quaternion.FromToRotation(Vector3.up, impactPos.normal);
                    if (impactPrefabs != null)
                        Instantiate(impactPrefabs[i], pos, rot);

                }
                if (impactDestroy)
                    Destroy(gameObject);
            }

        }
    }
}


