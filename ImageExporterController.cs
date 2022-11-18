using UnityEngine;
using System.Collections;
using System.IO;
using Jumpy;

namespace taecg.tools.ImageExporter
{
    public class ImageExporterController : MonoBehaviour
    {

        public Camera cam;
        public int cameraIndex;


        [HideInInspector]public string fileExtention; 

        //[HideInInspector]public string imageFormat;
        [HideInInspector]public bool isEnabledAlpha = false;
        [HideInInspector]public Vector2 resolution;
        [HideInInspector]public int frameCount;
        [HideInInspector]public string fileName;
        [HideInInspector]public string filePath;
        [HideInInspector]public int rangeStart;
        [HideInInspector]public int rangeEnd;
        [HideInInspector]public int currectFrame;

        StreamWriter sw_2D;
        StreamWriter sw_3D;

        // Use this for initialization
        void Start()
        {
            //修改帧生成速率
            Time.captureFramerate = frameCount;
            InitTextFile(".txt",ref sw_2D);
            InitTextFile("_3D.txt", ref sw_3D);
            InitImageFile();
            CameraManager.Instance.ExportThisFrame += ExportThisFrameHandler;
            CameraManager.Instance.EndExport += EndExportHandler;

        }
	
        // Update is called once per frame
        void ExportThisFrameHandler(string imageFormat) 
        {
            fileExtention = imageFormat;
            foreach (var bound in PeopleManager.Instance.bounds_list)
            {
                WriteFileByLine((Time.frameCount - CameraManager.Instance.BeginFrameCount).ToString() + " " +  bound.GetDataTuple_2D(cam),sw_2D);
                WriteFileByLine((Time.frameCount - CameraManager.Instance.BeginFrameCount).ToString() + " " + bound.GetDataTuple_3D(cam), sw_3D);
            }

            TakeSequenceScreenShot();
        }

        /// <summary>
        /// 生成序列图
        /// </summary>
        public void TakeSequenceScreenShot()
        {
            StartCoroutine(WaitTakeSequenceScreenShot());
        }

        private void InitTextFile(string suffix,ref StreamWriter sw) 
        {
            string file_name = "Camera" + cameraIndex + suffix;
  
            FileInfo file_info = new FileInfo(MainController.Instance.matchings + "//" + file_name);

            if (!file_info.Exists)
            {
                sw = file_info.CreateText();//创建一个用于写入 UTF-8 编码的文本  
                Debug.Log("[IO]文件 " + file_name + " 创建成功！");
            }
            else
            {
                sw = file_info.AppendText();//打开现有 UTF-8 编码文本文件以进行读取  
            }

        }

        private void InitImageFile() 
        {
            Directory.CreateDirectory(MainController.Instance.Image_subsets + "/C" + cameraIndex.ToString());
            Debug.Log("[IO]文件夹" + MainController.Instance.Image_subsets + "/C" + cameraIndex.ToString() + "创建成功");
        }

        private void FinishFile(StreamWriter sw)
        {
            sw.Close(); 
            sw.Dispose();
        }

        public void WriteFileByLine(string str_info,StreamWriter sw)
        {
            sw.WriteLine(str_info);
        }


        IEnumerator WaitTakeSequenceScreenShot()
        {
            int resWidthN = CameraManager.RESOLUTION_WIDTH;
            int resHeightN = CameraManager.RESOLUTION_HEIGHT;

            RenderTexture rt = new RenderTexture(resWidthN, resHeightN,24);
            cam.targetTexture = rt;

            TextureFormat _texFormat;
            if (isEnabledAlpha)
                _texFormat = TextureFormat.ARGB32;
            else
                _texFormat = TextureFormat.RGB24;

            Texture2D tex = new Texture2D(resWidthN, resHeightN, _texFormat, false);


            cam.Render();
            RenderTexture.active = rt;
            tex.ReadPixels(new Rect(0, 0, resWidthN, resHeightN), 0, 0);
            tex.Apply();

            //清空rendertexture
            cam.targetTexture = null;
            RenderTexture.active = null; 
            if (!isEnabledAlpha)
                GameObject.Destroy(rt);

            byte[] bytes;
            switch(fileExtention)
            {
                case ".png":
                    bytes = tex.EncodeToPNG();
                    break;
                case ".jpg":
                    bytes = tex.EncodeToJPG();
                    break;
                default:
                    bytes = tex.EncodeToPNG();
                    break;
            }

            File.WriteAllBytes(MainController.Instance.Image_subsets  + "/C" + cameraIndex.ToString() + "/"  + GetXDigitNum(4,(Time.frameCount - CameraManager.Instance.BeginFrameCount)) + fileExtention, bytes);

            yield return new WaitForEndOfFrame();
        }

        string GetXDigitNum(int X, int num) 
        {
            string result ="";
            for (int i = 0; i < X; i++)
            {
                string last = (num % 10).ToString();
                num = num / 10;
                result = last + result;
            }

            //Debug.Log(result);
            return result;

        }

        void EndExportHandler() 
        {

            FinishFile(sw_2D);
            FinishFile(sw_3D);
        }
    }
}