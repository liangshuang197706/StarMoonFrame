using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    public class Launcher : UnitySingleton<Launcher>
    {
        [Header("��Ŀ��������")]

        [Header("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ")]
        [Header("��������")]
        public NetManager.NetEnum net;
        /// <summary>
        /// Start��ִ���������
        /// </summary>
        private void Start()
        {
            LogUtil.Warning("========= ��Ŀ���� =========");
            StartCoroutine(InitGame());
        }
        /// <summary>
        /// Э��:������Ŀ���Ŀ��
        /// </summary>
        /// <returns></returns>
        IEnumerator InitGame()
        {
            // ����·���Ƿ����
            bool success = PathManager.CheckPath();
            if(success) LogUtil.Success("====== ��Դ��·�� ======");
            else LogUtil.Danger("====== ��Դ��·����Ч��ȱʧ��    ======");

            LogUtil.SampleLog("====== S M F ��������� ======");
            yield return new WaitForSeconds(0.1f);

            #region ��Դ����ģ��
            GameObject res = new GameObject(typeof(ResManager).Name);
            res.AddComponent<ResManager>();
            if (res.GetComponent<ResManager>())
            {
                LogUtil.Success("====== Init ResManager    ======");
            }
            else
            {
                LogUtil.Danger("====== ResManager ģ��ȱʧ    ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region ���ù���ģ��
            GameObject config = new GameObject(typeof(ConfigManager).Name);
            config.AddComponent<ConfigManager>();
            if (config.GetComponent<ConfigManager>())
            {
                LogUtil.Success("====== Init ConfigManager    ======");
            }
            else
            {
                LogUtil.Danger("====== ConfigManager ģ��ȱʧ    ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region UI����ģ��
            GameObject ui = new GameObject(typeof(UIManager).Name);
            ui.AddComponent<UIManager>();
            if (ui.GetComponent<UIManager>())
            {
                LogUtil.Success("====== Init UIManager      ======");
            }
            else
            {
                LogUtil.Danger("====== UIManager ģ��ȱʧ      ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region ��Ч����ģ��
            GameObject am = new GameObject(typeof(AudioManager).Name);
            am.AddComponent<AudioManager>();
            if (am.GetComponent<AudioManager>())
            {
                LogUtil.Success("====== Init AudioManager ======");
            }
            else
            {
                LogUtil.Danger("====== AudioManager ģ��ȱʧ ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region ��Ϸ����ģ��
            GameObject gm = new GameObject(typeof(GameManager).Name);
            gm.AddComponent<GameManager>();
            if(gm.GetComponent<GameManager>())
            {
                LogUtil.Success("====== Init GameManager ======");
            }
            else
            {
                LogUtil.Danger("====== GameManager ģ��ȱʧ ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region �������ģ��
            if (net!= NetManager.NetEnum.None)
            {
                GameObject nm = new GameObject(typeof(NetManager).Name);
                nm.AddComponent<NetManager>();
                if (nm.GetComponent<NetManager>())
                {
                    LogUtil.Success("====== Init NetManager ======");
                }
                else
                {
                    LogUtil.Danger("====== NetManager ģ��ȱʧ ======");
                    success = false;
                }
            }
            else
            {
                LogUtil.SampleLog("====== Not Set NetManager ======");
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            // ģ��������� �����������ʧ�ܵ�ģ��
            if (success)
            {
                bool check = false;
                float waitTime = 5.0f;
                while (!check)
                {
                    waitTime -= 0.1f;
                    if (waitTime == 0) break;
                    yield return new WaitForSeconds(0.1f);
                    if (!ConfigManager.Instance.init) continue;
                    if (!ResManager.Instance.init) continue;
                    if (!UIManager.Instance.init) continue;
                    if (!AudioManager.Instance.init) continue;
                    if (!GameManager.Instance.init) continue;
                    if (net!=NetManager.NetEnum.None && !NetManager.Instance.init) continue;
                    check = true;
                }
                if(check)
                {
                    LogUtil.Warning("========= ��Ŀ������� =========");
                }
                else
                {
                    LogUtil.Danger("========= ��Ŀ����ʧ�� =========");
                }
            }
            else
            {
                LogUtil.Danger("========= ��Ŀ����ʧ�� =========");
            }
        }
        private void OnDestroy()
        {
            LogUtil.Danger($"{gameObject.name} Destory !");
        }
    }
}
