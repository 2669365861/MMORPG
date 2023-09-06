using Net.Client;
using Net.Component;
using Net.UnityComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkStartPoint : MonoBehaviour
{
    public NetworkObject Object;
    public Vector3 offset;

    void Start()
    {
        var offset1=new Vector3(Random.Range(offset.x, -offset.x),0f,Random.Range(offset.z,-offset.z));
        var player=Instantiate(Object,transform.position+offset1,Quaternion.identity);
        player.Identity = ClientBase.Instance.UID;
        FindObjectOfType<ARPGcamera>().target = player.transform;
        player.GetComponent<Player>().isLocalPlayer = true;
    }
}
