using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\imgbackup\";//最终一定要以 \ 结束字符串

            DirectoryInfo folder = new DirectoryInfo(path);

            foreach (FileInfo file in folder.GetFiles("*.jpg"))
            {
                string time = (file.LastWriteTime).ToShortDateString();//2014/3/26
                string year = time.Substring(0, 4);
                Console.WriteLine(year);
                if (!Directory.Exists(path + year))
                {
                    Directory.CreateDirectory(path + year);
                }
                //移动
                file.MoveTo(path + year + "/" + file.Name);
                Console.WriteLine("扫描并分类至" + year + "年 " + file.FullName);
            }
            Console.ReadLine();
        }
    }
}
