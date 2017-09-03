using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Cursor : MonoBehaviour {

	private float angle;

	GameObject buildingCursor;

	[SerializeField] private int offsetX = 0;
    public int X
    {
        get { return offsetX; }
        private set
        {
            offsetX = value;
            if(offsetX < 0)
            {
                offsetX = 0;
            }
            else if (offsetX > maxX)
            {
                offsetX = maxX;
            }
        }
    }

	private int maxX;
    [SerializeField] private int offsetY = 0;
	private int maxY;
    public int Y
    {
        get { return offsetY; }
        private set
        {
            offsetY = value;
            if (offsetY < 0)
            {
                offsetY = 0;
            }
            else if (offsetY > maxY)
            {
                offsetY = maxY;
            }
        }
    }

    private bool usingAxis = false;

	private float t;
	private float delay = 0.3f;

    void Start () {
		maxX = Services.MapManager.mapWidth - 1;
		maxY = Services.MapManager.mapLength - 1;

		Services.EventManager.Register<ButtonPressed> (OnButtonPressed);

		buildingCursor = GameObject.Find ("BuildingCursor");

		buildingCursor.SetActive (false);

	}

	// Update is called once per frame
	void Update ()
    {
        Debug.Log("cursor pos x " + X + ", cursor pos y " + Y);
        GetTileBuildingInfo ();

		Vector3 tilePos = Services.GameManager.currentCamera.WorldToScreenPoint (Services.MapManager.map[offsetX,offsetY].transform.position);

		transform.position = tilePos;

		if (buildingCursor != null) {
			buildingCursor.transform.position = transform.position;
		}

		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		if (x != 0.0f || y != 0.0f)
        {
			
			angle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;


			if (angle >= 0 && angle < 30) {

				if (!usingAxis) {
					Y--;
					X--;

					usingAxis = true;
				}

			} else if (angle >= 30 && angle <= 60) {
				if (!usingAxis) {
					Y--;
					usingAxis = true;
				}

			} else if (angle > 60 && angle < 120) {
				
				if (!usingAxis) {
					X++;
					Y--;
					usingAxis = true;
				}

			} else if (angle >= 120 && angle <= 150) {

				if (!usingAxis) {
					X++;
					usingAxis = true;
				}

				
			} else if (angle > 150 && angle <= 180) {

				if (!usingAxis) {
					Y++;
					X++;
					usingAxis = true;
				}

			} else if (angle >= -180 && angle < -150) {

				if (!usingAxis) {
					Y++;
					X++;
					usingAxis = true;
				}

			} else if (angle >= -150 && angle <= -120) {

				if (!usingAxis) {
					Y++;
					usingAxis = true;
				}
					
			} else if (angle > -120 && angle < -60) {

				if (!usingAxis) {
					X--;
					Y++;
					usingAxis = true;
				}

			} else if (angle >= -60 && angle <= -30) {

				if (!usingAxis) {
					X--;
					usingAxis = true;
				}

			} else if (angle > -30 && angle < 0) {

				if (!usingAxis) {
					Y--;
					X--;

					usingAxis = true;
				}
	
			}
		}
        else
        {
			usingAxis = false;
		}

        if (usingAxis)
        {
			t += Time.deltaTime;

			if (t >= delay)
            {
				t = 0;
				usingAxis = false;
			}
		}
	}

	void GetTileBuildingInfo(){

		if (Services.MapManager.map [offsetX, offsetY].containedBuilding != null) {
			buildingCursor.GetComponent<Image> ().color = Color.red;
			
		} else {
			buildingCursor.GetComponent<Image> ().color = Color.white;
		}
			
		
	}

	void OnButtonPressed(ButtonPressed e){
		if (e.button == "B") {
			buildingCursor.SetActive (true);
		}
	}
}
