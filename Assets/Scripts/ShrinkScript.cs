using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkScript : MonoBehaviour {

    [SerializeField]
    private GameObject _shrinkObject;

    [SerializeField]
    private float _howLongToShrink = 0.2f;

    public void Shrink()
    {
        StartCoroutine(DoShrink());
    }

    IEnumerator DoShrink()
    {
        float timer = Time.time + _howLongToShrink;

        while (Time.time < timer)
        {
            _shrinkObject.transform.localScale = new Vector3(0.99f * _shrinkObject.transform.localScale.x, 0.99f * _shrinkObject.transform.localScale.y, 0.99f * _shrinkObject.transform.localScale.z);

            yield return null;
        }

        //canvasGroup.interactable = false;
        yield return null;
    }

    public void Enlarge()
    {
        StartCoroutine(DoEnlarge());
    }

    IEnumerator DoEnlarge()
    {
        float timer = Time.time + _howLongToShrink;

        while (Time.time < timer)
        {
            _shrinkObject.transform.localScale = new Vector3(1.01f * _shrinkObject.transform.localScale.x, 1.01f * _shrinkObject.transform.localScale.y, 1.01f * _shrinkObject.transform.localScale.z);

            yield return null;
        }

        //canvasGroup.interactable = false;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("down"))
        {
            Shrink();
        }

        if (Input.GetKeyDown("up"))
        {
            Enlarge();
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                if (_hit.collider.tag == "target")
                {
                    Shrink();
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                if (_hit.collider.tag == "target")
                {
                    Enlarge();
                }
            }
        }
    }
}
