using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    [SerializeField] GameObject[] Tiles = new GameObject[3];
    private int _tileNo;
    private string _tileName;

    private void OnEnable()
    {
        _tileNo = Tiles.Length -1;
        _tileName = Tiles[_tileNo].name;
    }

    public void SetTileAsTarget(int tileNo)
    {
        Tiles[tileNo].tag = "target";
    }

    private void IterateOnTiles()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                if (_hit.collider.tag == "target" && _hit.collider.name == _tileName)
                {
                    Vanish(_hit.collider.gameObject);
                    if(_tileNo > 0)
                    {
                        _tileNo -= 1;
                        _tileName = Tiles[_tileNo].name;
                        SetTileAsTarget(_tileNo);
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
}
