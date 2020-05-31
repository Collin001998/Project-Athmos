using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public GameObject avatar;

    private Vector3 avatarPosition;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = calaucateDistance(this.transform.position, avatar.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (avatar.GetComponent<Player>() && avatar.GetComponent<Player>().isWalkable)
        {
           this.transform.position = avatar.transform.position + distance;
        }
    }

    Vector3 calaucateDistance(Vector3 position1, Vector3 position2)
    {
        Vector3 distance = new Vector3(0,0,0);
        distance = position1 - position2;

        return distance;
    }
}
