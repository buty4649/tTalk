using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading;
using System.Windows.Forms;

namespace tTalk
{
    class Program : MarshalByRefObject
    {
        static Main main;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            main = new Main();

            /* 多重起動チェック */
            if (tTalk.Properties.Settings.Default.no_tasktray_icon)
            {
                /* Mutexの作成 */
                Mutex mutex = new Mutex(false, Application.ProductName);

                /* 多重起動チェック */
                if (mutex.WaitOne(0, false))
                {
                    /* 初回起動 */
                    ChannelServices.RegisterChannel(new IpcServerChannel(Application.ProductName), false);
                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(Program), "Program", WellKnownObjectMode.Singleton);


                    /* アプリケーションを起動 */
                    MainFromRun();
                }
                else
                {
                    /* 既に起動されていた */
                    ChannelServices.RegisterChannel(new IpcClientChannel(), false);
                    RemotingConfiguration.RegisterWellKnownClientType(typeof(Program), "ipc://" + Application.ProductName + "/Program");

                    /* 元のウインドウを起動 */
                    new Program().StartupNextInstance();
                }

                /* Mutexを削除 */
                mutex.Close();
            }
            else
            {
                /* 通常起動 */
                MainFromRun();
            }
        }

        static void MainFromRun()
        {
            main.Run();
            Application.Run();
        }

        public void StartupNextInstance()
        {
            main.Invoke((Action)delegate
            {
                main.RestoreWindow(null, null);
            });
        }
    }
}
