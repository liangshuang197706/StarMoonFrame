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
        [Header("项目基本设置")]

        [Header("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ")]
        [Header("联机设置")]
        public NetManager.NetEnum net;
        /// <summary>
        /// Start中执行启动框架
        /// </summary>
        private void Start()
        {
            LogUtil.Warning("========= 项目启动 =========");
            StartCoroutine(InitGame());
        }
        /// <summary>
        /// 协程:启动项目核心框架
        /// </summary>
        /// <returns></returns>
        IEnumerator InitGame()
        {
            // 检查根路径是否存在
            bool success = PathManager.CheckPath();
            if(success) LogUtil.Success("====== 资源根路径 ======");
            else LogUtil.Danger("====== 资源根路径无效或缺失！    ======");

            LogUtil.SampleLog("====== S M F 框架启动中 ======");
            yield return new WaitForSeconds(0.1f);

            #region 资源管理模块
            GameObject res = new GameObject(typeof(ResManager).Name);
            res.AddComponent<ResManager>();
            if (res.GetComponent<ResManager>())
            {
                LogUtil.Success("====== Init ResManager    ======");
            }
            else
            {
                LogUtil.Danger("====== ResManager 模块缺失    ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region 配置管理模块
            GameObject config = new GameObject(typeof(ConfigManager).Name);
            config.AddComponent<ConfigManager>();
            if (config.GetComponent<ConfigManager>())
            {
                LogUtil.Success("====== Init ConfigManager    ======");
            }
            else
            {
                LogUtil.Danger("====== ConfigManager 模块缺失    ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region UI管理模块
            GameObject ui = new GameObject(typeof(UIManager).Name);
            ui.AddComponent<UIManager>();
            if (ui.GetComponent<UIManager>())
            {
                LogUtil.Success("====== Init UIManager      ======");
            }
            else
            {
                LogUtil.Danger("====== UIManager 模块缺失      ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region 音效管理模块
            GameObject am = new GameObject(typeof(AudioManager).Name);
            am.AddComponent<AudioManager>();
            if (am.GetComponent<AudioManager>())
            {
                LogUtil.Success("====== Init AudioManager ======");
            }
            else
            {
                LogUtil.Danger("====== AudioManager 模块缺失 ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region 游戏管理模块
            GameObject gm = new GameObject(typeof(GameManager).Name);
            gm.AddComponent<GameManager>();
            if(gm.GetComponent<GameManager>())
            {
                LogUtil.Success("====== Init GameManager ======");
            }
            else
            {
                LogUtil.Danger("====== GameManager 模块缺失 ======");
                success = false;
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            #region 网络管理模块
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
                    LogUtil.Danger("====== NetManager 模块缺失 ======");
                    success = false;
                }
            }
            else
            {
                LogUtil.SampleLog("====== Not Set NetManager ======");
            }
            #endregion
            yield return new WaitForSeconds(0.1f);

            // 模块启动检查 检查有无启动失败的模块
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
                    LogUtil.Warning("========= 项目启动完毕 =========");
                }
                else
                {
                    LogUtil.Danger("========= 项目启动失败 =========");
                }
            }
            else
            {
                LogUtil.Danger("========= 项目启动失败 =========");
            }
        }
        private void OnDestroy()
        {
            LogUtil.Danger($"{gameObject.name} Destory !");
        }
    }
}
