using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public static class SaveDataManager
{
    #region CameraGenerateMethod
    public const string CAMERA_NUM = nameof(CAMERA_NUM);
    public const string CAMERA_HEIGHT = nameof(CAMERA_HEIGHT);
    public const string CAMERA_GENERATE_TYPE = nameof(CAMERA_GENERATE_TYPE);

    #region Ellipse Paramas
    public const string ELLIPSE_MAJORAXIS = nameof(ELLIPSE_MAJORAXIS);
    public const string ELLIPSE_MINORAXIS = nameof(ELLIPSE_MINORAXIS);
    #endregion

    #region Square Params
    public const string SQUARE_LONGEDGE = "Square_LongEdge";
    public const string SQUARE_SHORTEDGE = "Square_ShortEdge";
    #endregion

    #endregion

    #region FramesSettings
    
    #region Given_FrameCount
    public const string START_FRAME = nameof(START_FRAME);
    public const string END_FRAME = nameof(END_FRAME);
    public const string FRAME_COUNT = nameof(FRAME_COUNT);
    #endregion

    #endregion

    #region ImageExporterControlle
    public const string IS_ENABLE_ALPHA = nameof(IS_ENABLE_ALPHA);
    public const string RESOLUTION = nameof(RESOLUTION);
    public const string FILENAME = nameof(FILENAME);
    public const string FILEPATH = nameof(FILEPATH);
    #endregion
}
