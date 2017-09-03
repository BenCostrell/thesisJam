using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Cursor : MonoBehaviour {

	private float angle;

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
            else if (offsetX > maxY)
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

	}

	// Update is called once per frame
	void Update ()
    {

		Vector3 tilePos = Services.GameManager.currentCamera.WorldToScreenPoint (Services.MapManager.map[offsetX,offsetY].transform.position);

		transform.position = tilePos;

		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		if (x != 0.0f || y != 0.0f)
        {
			
			angle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;


			if (angle >= 0 && angle < 30) {
				if (offsetY > 0 && offsetY > 0) {
					if (!usingAxis) {
						offsetY--;
						offsetX--;

						usingAxis = true;
					}
				} 

			} else if (angle >= 30 && angle <= 60) {
				if (offsetY > 0) {
					if (!usingAxis) {
						offsetY--;
						usingAxis = true;
					}

				}
			} else if (angle > 60 && angle < 120) {

				if (offsetX < maxX && offsetY > 0) {
					if (!usingAxis) {
						offsetX++;
						offsetY--;
						usingAxis = true;
					}
				}
			} else if (angle >= 120 && angle <= 150) {
				if ( offsetX < maxX) {
					if (!usingAxis) {
						offsetX++;
						usingAxis = true;
					}

				}
				
			} else if (angle > 150 && angle <= 180) {
				if (offsetY < maxY && offsetX < maxX) {
					if (!usingAxis) {
						offsetY++;
						offsetX++;
						usingAxis = true;
					}

				}
			} else if (angle >= -180 && angle < -150) {
				if (offsetY < maxY && offsetX < maxX) {
					if (!usingAxis) {
						offsetY++;
						offsetX++;
						usingAxis = true;
					}

				}
			} else if (angle >= -150 && angle <= -120) {
				if (offsetY < maxY) {
					if (!usingAxis) {
						offsetY++;
						usingAxis = true;
					}

				}
			} else if (angle > -120 && angle < -60) {
				if (offsetX > 0 && offsetY < maxY) {
					if (!usingAxis) {
						offsetX--;
						offsetY++;
						usingAxis = true;
					}
				}
			} else if (angle >= -60 && angle <= -30) {
				if (offsetX > 0 ) {
					if (!usingAxis) {
						offsetX--;
						usingAxis = true;
					}

				}
			} else if (angle > -30 && angle < 0) {
				if (offsetY > 0 && offsetX > 0) {
					if (!usingAxis) {
						offsetY--;
						offsetX--;

						usingAxis = true;
					}
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
}
