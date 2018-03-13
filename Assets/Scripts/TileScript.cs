using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    [SerializeField] private GameObject Guide;

    [SerializeField] GameObject[] Tiles = new GameObject[3];
    [SerializeField] private float _howLongToWait = 2f;
    private int _tileNo;
    private string _tileName;
    private Boolean _isBlocked = false;


    private void OnEnable()
    {
        _tileNo = Tiles.Length -1;
        _tileName = Tiles[_tileNo].name;
    }

    public void SetTileAsTarget(int tileNo)
    {
        Tiles[tileNo].tag = "target";
        Tiles[tileNo].GetComponent<Animator>().enabled = true;
        Guide.GetComponent<GuideScript>().ClipIndex = Guide.GetComponent<GuideScript>().ClipIndex + 1;
        Guide.GetComponent<GuideScript>().changeAudioClip(Guide.GetComponent<GuideScript>().ClipIndex);
        Guide.GetComponent<GuideScript>().playAudioClip();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "target" && !_isBlocked)
                {
                    Vanish(hit.collider.gameObject); //Remove Tile
                    if (_tileNo > 0)
                    {
                        _tileNo -= 1; //Iterate Tile number
                        _tileName = Tiles[_tileNo].name;
                        SetTileAsTarget(_tileNo);
                        StartCoroutine(FixedWait());
                    }
                    else
                    {
                        //Last Tile removed
                        GetComponent<HoneycombScript>().SendFadeRequestToGameManager();
                    }
                }
            }
        }
    }

    public void Vanish(GameObject gameObject)
    {
        StartCoroutine(DoVanish(gameObject));
    }

    IEnumerator DoVanish(GameObject gameObject)
    {
        while (gameObject.activeSelf)
        {
            gameObject.transform.localScale = new Vector3(0.9f * gameObject.transform.localScale.x, 0.9f * gameObject.transform.localScale.y, 0.9f * gameObject.transform.localScale.z);

            if (gameObject.transform.localScale.x <= 0.1f)
            {
                gameObject.SetActive(false);
            }

            yield return null;
        }

        //canvasGroup.interactable = false;
        yield return null;
    }

    IEnumerator FixedWait()
    {
        float timer = Time.time + _howLongToWait;

        while (Time.time < timer)
        {
            _isBlocked = true;
            yield return null;
        }

        _isBlocked = false;
        yield return null;
    }
}
