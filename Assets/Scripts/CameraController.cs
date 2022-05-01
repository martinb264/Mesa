using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public GameObject player;
    private Vector3 offset;
    [SerializeField]
    private float followSpeed;

    // Start is called before the first frame update

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        //transform.position = Vector3.Lerp(transform.position, offset, Time.deltaTime*followSpeed);
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}
