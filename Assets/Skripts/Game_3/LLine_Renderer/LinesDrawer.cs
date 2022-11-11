using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesDrawer : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private LayerMask cantDrrawnOverLayer;
    private int cantDrrawnOverLayerIndex;

    [Space(30f)]
    [SerializeField] private Gradient lineColor;
    [SerializeField] private float linePointsMinDistance;
    [SerializeField] private float lineWidth;


    private Line currentLine;
    private Camera cam;


    public static bool boolController = true;



    void Start()
    {
        boolController = true;
        cam = Camera.main;
        cantDrrawnOverLayerIndex = LayerMask.NameToLayer("Ground");
        PlayerContlorrer.speed = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && boolController == true)
        {
            BeginDraw();
        }
        if (currentLine != null && boolController == true)
        {
            Draw();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();
            boolController = false;
            PlayerContlorrer.speed = 13f;
        }
    }

    void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

        currentLine.UsePhisics(false);
        currentLine.SetLineColor(lineColor);
        currentLine.SetPointsMinDistance(linePointsMinDistance);
        currentLine.SetLineWidth(lineWidth);

    }
    void Draw()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3, Vector2.zero, 1f, cantDrrawnOverLayer);

        if (hit)
        {
            EndDraw();
        }
        else
        {
            currentLine.AddPoint(mousePosition);
        }
    }
    void EndDraw()
    {
        if (currentLine != null)
        {
            if (currentLine.pointsCount < 5)          // Длина допустимого размера линий
            {
                Destroy(currentLine.gameObject);
            }
            else
            {
                currentLine.gameObject.layer = cantDrrawnOverLayerIndex;
                currentLine.UsePhisics(true);
                currentLine = null;
            }
        }
    }
}
