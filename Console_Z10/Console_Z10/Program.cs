using System;
using System.IO;

namespace Console_Z10
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\temp";
            if (Directory.Exists(path) == true)
                Directory.Delete(path, true);

            DirectoryInfo dir = new(path);
            dir.CreateSubdirectory("K1");
            dir.CreateSubdirectory("K2");

            CreateFile(path);

            File.AppendAllText(path + "\\K2\\t3.txt", File.ReadAllText(path + "\\K1\\t1.txt"));
            File.AppendAllText(path + "\\K2\\t3.txt", File.ReadAllText(path + "\\K1\\t2.txt"));

            FileInfo(path);

            File.Move(path + "\\K1\\t2.txt", path + "\\K2\\t2.txt", true);
            File.Copy(path + "\\K1\\t1.txt", path + "\\K2\\t1.txt");

            Directory.Move(path + "\\K2", path + "\\ALL");
            Directory.Delete(path + "\\K1", true);

            FileInfo(path);
        }
        static void CreateFile(string path)
        {
            StreamWriter t1 = new StreamWriter(new FileStream(path + "\\K1\\t1.txt", FileMode.Create));
            t1.WriteLine("Утин Дмитрий Сергеевич, 2003 года рождения, место жительства г.Радужный");
            StreamWriter t2 = new StreamWriter(new FileStream(path + "\\K1\\t2.txt", FileMode.Create));
            t2.WriteLine("Утина Юлия Ивановна, 1983 года рождения, место жительства г.Радужный");
            StreamWriter t3 = new StreamWriter(new FileStream(path + "\\K2\\t3.txt", FileMode.Create));
            t1.Close();
            t2.Close();
            t3.Close();
        }
        static void FileInfo(string path)
        {
            string[] files;
            Console.WriteLine("|----------------------------");
            Console.WriteLine("| Подкаталоги в {0}:", path);
            string[] dirs = Directory.GetDirectories(path);
            foreach (string s in dirs)
            {
                Console.WriteLine("| {0}", s);
            }

            if (Directory.Exists(path + "\\K1") == true)
            {
                Console.WriteLine("|----------------------------");
                Console.WriteLine("| Файлы в {0}:", path + "\\K1");
                files = Directory.GetFiles(path + "\\K1");
                foreach (string s in files)
                {
                    Console.WriteLine("| {0}", s);
                }
            }

            if (Directory.Exists(path + "\\K2") == true)
            {
                Console.WriteLine("|----------------------------");
                Console.WriteLine("| Файлы в {0}:", path + "\\K2");
                files = Directory.GetFiles(path + "\\K2");
                foreach (string s in files)
                {
                    Console.WriteLine("| {0}", s);
                }
            }

            if (Directory.Exists(path + "\\ALL") == true)
            {
                Console.WriteLine("|----------------------------");
                Console.WriteLine("| Файлы в {0}:", path + "\\ALL");
                files = Directory.GetFiles(path + "\\ALl");
                foreach (string s in files)
                {
                    Console.WriteLine("| {0}", s);
                }
            }
        }
    }
}
