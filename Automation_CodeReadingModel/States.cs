namespace Automation_CodeReadingModel
{
    #region 是否需要"保存数据"
    public enum SaveDataState
    {
        saveDataTrue,
        saveDataFalse
    }
    /// <summary>
    /// 是否需要"保存数据"
    /// </summary>
    /// saveDataTrue-需要保存
    /// saveDataFalse-不需要保存
    public class SaveData
    {
        public static SaveDataState state = SaveDataState.saveDataFalse;
    }
    #endregion

    #region 是否需要"自动捕捉"
    public enum ImgAutoState
    {
        imgAutoTrue,
        imgAutoFalse
    }
    /// <summary>
    /// 是否需要"自动捕捉"
    /// </summary>
    /// imgAutoTrue-自动捕捉
    /// imgAutoFalse-手动捕捉
    public class ImgAuto
    {
        public static ImgAutoState state = ImgAutoState.imgAutoFalse;
    }
    #endregion
}
