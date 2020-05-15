namespace Automation_CodeReadingModel
{
    public class UsedInfo
    {
        /// <summary>
        /// DbId
        /// </summary>
        public string DbId { get; set; }
        /// <summary>
        /// 其他ID
        /// </summary>
        public string OtherID { get; set; }
        /// <summary>
        /// 医院标识
        /// </summary>
        public string HospitalNo { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public string ScanDate { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public string TagCode { get; set; }
        /// <summary>
        /// 条形码数
        /// </summary>
        public string TagCodeNum { get; set; }
        /// <summary>
        /// 坏的条形码
        /// </summary>
        public string BedNo { get; set; }
        /// <summary>
        /// 签名确认
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// 图片名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 图片文件
        /// </summary>
        public string ImgFile { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图片张数
        /// </summary>
        private int imgCount;   // deviation
        public int ImgCount { get { return imgCount != 0 ? imgCount : 0; } set{ imgCount = value; } }
    }
}
