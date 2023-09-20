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
    /// ΪText�����嶯̬������ɫ
    /// </summary>
    public class ColorText : MonoBehaviour
    {
        /// <summary>
        /// Ԥ����ɫ
        /// </summary>
        public enum SampleColorEnum
        {
            /// <summary>
            /// ��ɫ FFE1FF
            /// </summary>
            Pink,
            /// <summary>
            /// ����ɫ 008000
            /// </summary>
            Lime,
            /// <summary>
            /// ����ɫ 008080
            /// </summary>
            Teal,
            /// <summary>
            /// ����ɫ 00FF00
            /// </summary>
            Green,
            /// <summary>
            /// ����ɫ 800000
            /// </summary>
            Maroon,
            /// <summary>
            /// ��ɫ FF0000
            /// </summary>
            Red,
            /// <summary>
            /// ����ɫ 00FFFF
            /// </summary>
            Aqua,
            /// <summary>
            /// ��ɫ 000000
            /// </summary>
            Black,
            /// <summary>
            /// ��ɫ 808000
            /// </summary>
            Olive,
            /// <summary>
            /// ��ɫ 0000FF
            /// </summary>
            Blue,
            /// <summary>
            /// ��ɫ 800080
            /// </summary>
            Purple,
            /// <summary>
            /// ��ɫ FFA500
            /// </summary>
            Orange
            
        }


        /// <summary>
        /// �Զ���������ɫ
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
        /// ����Ԥ����ɫ�����������Ⱦɫ
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
        /// ƴ����ɫ�ַ���
        /// colorStr ʮ��������ɫ��ȥ��#�ţ�
        /// str ��ҪȾɫ���ַ���
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
        /// ͨ��ö�ٷ���Ԥ����ɫ
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
