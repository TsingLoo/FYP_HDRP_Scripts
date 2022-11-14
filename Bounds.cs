using I18N.CJK;
using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Bounds : MonoBehaviour
{
   

    [SerializeField] int PID;
    [SerializeField] Camera cam;

    //8����־λ ��������scene��Ԥ��
    Vector3[] points;
    List<GameObject> obj_points = new List<GameObject> ();
    Vector2[] points2D;
    //��Ҫ��ȡBoxcollier����Ķ���
    private BoxCollider cube;
    string tuple = "";

    void Start()
    {
        //��ȡBoxCollider�������������ṩ��Χ�У��������������
        cube = gameObject.GetComponent<BoxCollider>();
        cube.isTrigger = true;

        //��ȡ�˸����������ռ���ά����
        points = Utils.GetBoxColliderVertexPositions(cube);

        //������ʾ��
        GeneratePointByVector3();

        //����˸�����תΪ�ӿ�����
        points2D =  Utils.ConvertWorldPointsToViewportPoints(points,cam);


        GenerateCameraX_2D();
        GenerateCameraX_3D();

    }

    void GenerateCameraX_2D() 
    {
        //Frame Index
        AddPropertyToTuple("0");

        //д���ɫPID
        AddPropertyToTuple(PID.ToString());

        //д��˸�������ӿ�����
        for (int i = 0; i < points.Length; i++)
        {
            AddPropertyToTuple((points2D[i].x * (MainController.RESOLUTION_WIDTH)).ToString());
            AddPropertyToTuple(((1 - points2D[i].y) * (MainController.RESOLUTION_HEIGHT)).ToString());
        }

        //д��ŵ��ӿ�����
        AddPropertyToTuple(((cam.WorldToViewportPoint(gameObject.transform.position).x * MainController.RESOLUTION_WIDTH)).ToString());
        AddPropertyToTuple(((1-cam.WorldToViewportPoint(gameObject.transform.position).y) * MainController.RESOLUTION_HEIGHT).ToString());

        Utils.WriteFileByLine("Camera1.txt", tuple);
    }

    void GenerateCameraX_3D() 
    {
        //��������ݣ�Ϊ֮��3D��������׼��
        tuple = "";
        //Frame Index
        AddPropertyToTuple("0");
        AddPropertyToTuple(PID.ToString());

        //д��˸��������������
        for (int i = 0; i < points.Length; i++)
        {
            Debug.Log("[IO]This point is " + points[i].ToString());
            AddPropertyToTuple((points[i].x).ToString());
            Debug.Log("[IO]This point is " + (points[i].x).ToString());
            AddPropertyToTuple((points[i].z).ToString());
            AddPropertyToTuple((points[i].y).ToString());
            //Height 
            //AddPropertyToTuple(transform.position.y.ToString());
        }

        AddPropertyToTuple(transform.position.x.ToString());
        AddPropertyToTuple(transform.position.z.ToString());
        AddPropertyToTuple(transform.position.y.ToString());
        Utils.WriteFileByLine("Camera1_3D.txt", tuple);
    }

    void AddPropertyToTuple(string property) 
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
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            cube.transform.position = points[i];
            obj_points.Add(obj_point);
        }
    }

}
