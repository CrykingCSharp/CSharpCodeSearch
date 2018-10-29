using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CodeSearch
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dt = new Dictionary<string, string>();
        object slock = new object();
        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;
        int iSearchCnt = 0,iTotalDrivers=0;//搜索了的盘符个数 总盘符数
        void FileSearch(string driver)
        {
            string s = driver;
            
            {
                DriveInfo di = new DriveInfo(s);
                Console.WriteLine(di.DriveType);
                if (false==di.IsReady)
                {
                    return;
                }
                try
                {
                    string[] ast = Directory.GetFiles(s, "*.cs");
                    if (ast.Length == 0)
                        ast = Directory.GetDirectories(s);
                    else
                    {
                        foreach (string s2 in ast)
                        {
                            string t2 = s2.Substring(s2.LastIndexOf('\\') + 1);
                            //lb_codefile.Items.Add(t2);
                            //dt.Add(i.ToString() + t2, s2);
                            
                            lock (slock)
                            {
                                AddToListBox(i, t2, s2);
                                i++;
                            }
                        }
                    }
                    foreach (string s1 in ast)
                    {
                        tb2.Invoke(new Action(() =>
                        {
                            tb2.Text = string.Format("正在搜索:{0}",s1);
                        }));
                        try
                        {
                            if (s1.Contains(@"Program Files") || s1.Contains(@"C:\Windows")
                                || s1.Contains(@"C:\Python33") || s1.Contains(@"D:\cygwin64")
                                || s1.Contains("System Volume Information")) continue;
                            string[] atmp = Directory.GetFiles(s1, "*.cs", SearchOption.AllDirectories);
                            if (atmp.Length != 0)
                            {
                                foreach (string s2 in atmp)
                                {
                                    string t2 = s2.Substring(s2.LastIndexOf('\\') + 1);
                                    //lb_codefile.Items.Add(t2);
                                    //dt.Add(i.ToString() + t2, s2);
                                    AddToListBox(i, t2, s2);
                                    lock (slock)
                                    {
                                        i++;
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                        if (lab1.InvokeRequired&&i>0)
                        {
                            lab1.Invoke(new Action<int>((c) =>
                            {
                                lab1.Text = string.Format(":.CS文件数({0})", c);
                            }),i);
                        }
                    }
                    iSearchCnt++;
                    if (iSearchCnt == iTotalDrivers-1)
                    {
                        tb2.Invoke(new Action(() =>
                        {
                            tb2.Text = "搜索完成";
                        }));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        void AddToListBox(int i,string file,string path)
        {
            Invoke(new Action(() =>
            {
                lb_codefile.Items.Add(file);
                dt.Add(i.ToString() + file, path);
                //lb_codefile.Refresh();
            }));
        }

        bool bSearch = false;
        List<string> sFiles = new List<string>();//已搜索的包含了代码的文件集合
        int iCnt = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb1.Text.Trim())) return;

            int iFileCount = lb_codefile.Items.Count;

            for(iCnt = 0; iCnt < iFileCount; iCnt = iCnt + 10)
            {
                string s = SelectFile(iCnt, 10 + iCnt);
                if (s.Length > 0)
                {
                    sFiles.Add(s);
                    break;
                }
            }
            if (false == bSearch)
            {
                //本地搜索不到,去网上搜索
                System.Diagnostics.Process.Start(@"IEXPLORE.EXE", @"http://cn.bing.com/search?q=" + tb1.Text);
            }
        }

        string SelectFile(int s,int e)
        {
            string res = "";
            StringBuilder sb = new StringBuilder();

            for (int i = s; i < e; i++)
            {
                string strfile = dt[i + lb_codefile.Items[i].ToString()].ToString();
                sb.Clear();
                if (sFiles.Contains(strfile))
                {
                    continue;
                }
                if(bSearch==false)
                { 
                using (StreamReader sr = new StreamReader(strfile, Encoding.Default))
                {
                    sb.Append(sr.ReadToEndAsync());
                    if (sb.ToString().Contains(tb1.Text))
                    {
                        tb2.Text = lb_codefile.Items[i].ToString() + "\r\n\r\n" + sb.ToString();
                        bSearch = true;
                        res=strfile;
                        break;
                    }
                }
                }
            }

            return res;
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] astr = Directory.GetLogicalDrives();
            iTotalDrivers = astr.Length;
            for (int i = 0; i < iTotalDrivers; i++)
            {
                Task t = new Task(drive => FileSearch((string)drive), astr[i]);
                t.Start();
            }
            tb2.Text = "正在扫描电脑中所有.cs文件,请等待...";
            //Task.Run(()=> FileSearch());
        }

        private void Lb_codefile_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox lb1 = (ListBox)sender;
            if (lb1.SelectedIndex > 0)
            {
                string strfile = dt[lb1.SelectedIndex.ToString() + lb1.Text].ToString();
                StringBuilder sb = new StringBuilder(5000);
                try
                {
                    using (StreamReader sr = new StreamReader(strfile, Encoding.Default))
                    {
                        sb.Append(sr.ReadToEnd());
                    }
                    tb2.Text = string.Format("文件路径{0}{1}{2}", strfile, Environment.NewLine, sb.ToString());
                }
                catch
                {
                    tb2.Text = "未找到文件";
                }
            }
        }
    }
}
