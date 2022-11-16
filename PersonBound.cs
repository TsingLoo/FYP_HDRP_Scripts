using I18N.CJK;
using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PersonBound : MonoBehaviour
{
   

    public int PID;
    // [SerializeField] Camera cam;

    //8个标志位 ，用来在scene里预览
    Vector3[] points;
    List<GameObject> obj_points = new List<GameObject> ();
    Vector2[] points2D;
    //需要提取Boxcollier顶点的对象
    private BoxCollider cube;
    string tuple_2D = "";
    string tuple_3D = "";

    DynSpownCollider dsc;

    private void Awake()
    {
        dsc = gameObject.AddComponent<DynSpownCollider>();
        dsc.target = gameObject;
        dsc.SpownCollider();

    }

    void Start()
    {


        
        //获取BoxCollider组件，此组件仅提供包围盒，不参与物理计算
        cube = gameObject.GetComponent<BoxCollider>();
        cube.isTrigger = true;


        //UpdateDataTuple();

        //GetDataTuple_2D();
        //GetDataTuple_3D();
        //GenerateCameraX_3D();
    }

    private void UpdateDataTuple()
    {
        points = Utils.GetBoxColliderVertexPositions(cube);
        GeneratePointByVector3();
    }

    public string GetDataTuple_2D(Camera cam)
    {
        //Debug.Log(PID.ToString());
        UpdateDataTuple();
        points2D = Utils.ConvertWorldPointsToViewportPoints(points, cam);
        tuple_2D = "";
        AddPropertyToTuple(PID.ToString(),ref tuple_2D);
        for (int i = 0; i < points.Length; i++)
        {
            AddPropertyToTuple((points2D[i].x * (CameraManager.RESOLUTION_WIDTH)).ToString(), ref tuple_2D);
            AddPropertyToTuple(((1 - points2D[i].y) * (CameraManager.RESOLUTION_HEIGHT)).ToString(), ref tuple_2D);
        }
        AddPropertyToTuple(((cam.WorldToViewportPoint(gameObject.transform.position).x * CameraManager.RESOLUTION_WIDTH)).ToString(), ref tuple_2D);
        AddPropertyToTuple(((1 - cam.WorldToViewportPoint(gameObject.transform.position).y) * CameraManager.RESOLUTION_HEIGHT).ToString(), ref tuple_2D);
        return tuple_2D;
    }

    public string GetDataTuple_3D(Camera cam)
    {
        UpdateDataTuple();
        tuple_3D = "";
        AddPropertyToTuple(PID.ToString(), ref tuple_3D);

        float Ybias = points[0].y;

        //写入八个顶点的世界坐标
        for (int i = 0; i < points.Length; i++)
        {
            //Debug.Log("[IO]This point is " + points[i].ToString());
            AddPropertyToTuple((points[i].x).ToString(), ref tuple_3D);
            //Debug.Log("[IO]This point is " + (points[i].x).ToString());
            AddPropertyToTuple((points[i].z).ToString(), ref tuple_3D);
            AddPropertyToTuple((points[i].y - Ybias).ToString(), ref tuple_3D);
            //Height 
            //AddPropertyToTuple(transform.position.y.ToString());
        }

        AddPropertyToTuple(transform.position.x.ToString(), ref tuple_3D);
        AddPropertyToTuple(transform.position.z.ToString(), ref tuple_3D);
        AddPropertyToTuple((transform.position.y - Ybias).ToString(), ref tuple_3D);
        return tuple_3D;
    }


    void AddPropertyToTuple(string property, ref string tuple) 
    {
        tuple = tuple + property + " ";
    }

    void GeneratePointByVector3() 
    {
        for (int i = 0; i < points.Length; i++)
        {
            GameObject obj_point;

            if (i < points.Length / 2)
            {
                obj_point = new GameObject("Bottom" + i.ToString());
            }
            else 
            {
                obj_point = new GameObject("Top" + (i-4).ToString());
            }
            
            obj_point.transform.SetParent(transform);
            obj_point.transform.position = points[i];
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            //cube.transform.position = points[i];
            obj_points.Add(obj_point);
        }
    }

}
