using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oustacheController : MonoBehaviour
{
    [SerializeField] GameObject _moustachePrefab;
    [SerializeField] int _gap = 10;
    [SerializeField] float _bodySpeed = 10;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _steerSpeed;

    [SerializeField] SnakeController _snake;


    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistoryHead = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < 0; i++)
        {
            GrowMoustache();
        }
    }
    void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;

        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * _steerSpeed * Time.deltaTime);

        PositionHistoryHead.Insert(0, transform.position);

        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistoryHead[Mathf.Clamp(index * _gap, 0, PositionHistoryHead.Count - 1)];

            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * _bodySpeed * Time.deltaTime;

            body.transform.LookAt(point);

            index++;
        }
    }

    public void GrowMoustache()
    {
        GameObject LastBody = gameObject;
        GameObject body = Instantiate(_moustachePrefab, LastBody.transform.position, LastBody.transform.rotation);
        BodyParts.Add(body);
    }
}
