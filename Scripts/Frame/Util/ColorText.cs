using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// 为Text的字体动态附加颜色
    /// </summary>
    public class ColorText : MonoBehaviour
    {
        /// <summary>
        /// 预制颜色
        /// </summary>
        public enum SampleColorEnum
        {
            /// <summary>
            /// 粉色 FFE1FF
            /// </summary>
            Pink,
            /// <summary>
            /// 深绿色 008000
            /// </summary>
            Lime,
            /// <summary>
            /// 天青色 008080
            /// </summary>
            Teal,
            /// <summary>
            /// 亮绿色 00FF00
            /// </summary>
            Green,
            /// <summary>
            /// 暗红色 800000
            /// </summary>
            Maroon,
            /// <summary>
            /// 红色 FF0000
            /// </summary>
            Red,
            /// <summary>
            /// 天蓝色 00FFFF
            /// </summary>
            Aqua,
            /// <summary>
            /// 黑色 000000
            /// </summary>
            Black,
            /// <summary>
            /// 土色 808000
            /// </summary>
            Olive,
            /// <summary>
            /// 蓝色 0000FF
            /// </summary>
            Blue,
            /// <summary>
            /// 紫色 800080
            /// </summary>
            Purple,
            /// <summary>
            /// 橙色 FFA500
            /// </summary>
            Orange
            
        }


        /// <summary>
        /// 自定义字体颜色
        /// </summary>
        /// <param name="color"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SelfColorText(Color color,string str)
        {
            string colorStr = ColorUtility.ToHtmlStringRGB(color);
            return BuliderString(colorStr,str);
        }

        /// <summary>
        /// 访问预制颜色，对字体进行染色
        /// </summary>
        /// <param name="colorEnum"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SampleColorText(SampleColorEnum colorEnum,string str)
        {
            string colorStr = SwitchSampleColor(colorEnum);
            return BuliderString(colorStr, str);
        }

        /// <summary>
        /// 拼接颜色字符串
        /// colorStr 十六进制颜色（去除#号）
        /// str 需要染色的字符串
        /// </summary>
        /// <returns></returns>
        public static string BuliderString(string colorStr,string str)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<color='#");
            sb.Append(colorStr);
            sb.Append("'>");

            sb.Append(str);

            sb.Append("</color>");

            return sb.ToString();
        }

        /// <summary>
        /// 通过枚举访问预制颜色
        /// </summary>
        /// <param name="sce"></param>
        /// <returns></returns>
        private static string SwitchSampleColor(SampleColorEnum sce)
        {
            switch (sce)
            {
                case SampleColorEnum.Pink:
                    return "FFE1FF";
                case SampleColorEnum.Lime:
                    return "008000";
                case SampleColorEnum.Aqua:
                    return "00FFFF";
                case SampleColorEnum.Black:
                    return "000000";
                case SampleColorEnum.Teal:
                    return "008080";
                case SampleColorEnum.Green:
                    return "00FF00";
                case SampleColorEnum.Maroon:
                    return "800000";
                case SampleColorEnum.Olive:
                    return "808000";
                case SampleColorEnum.Purple:
                    return "800080";
                case SampleColorEnum.Red:
                    return "FF0000";
                case SampleColorEnum.Orange:
                    return "FFA500";
                case SampleColorEnum.Blue:
                    return "0000FF";
            }
            return "FFFFFF";
        }
    }
}
