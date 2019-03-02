using System;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            String file1Name = "";
            Boolean file1Exists = false;
            String file2Name = "";
            Boolean file2Exists = false;
            string text1 = "";
            string text2 = "";
            int loop = 1;
            while(loop == 1)
            {
                Console.WriteLine("Document Merger\n");

                while (file1Exists == false)
                {
                    Console.WriteLine("Enter the name of file 1");
                    file1Name = Console.ReadLine();
                    if (File.Exists(file1Name))
                    {
                        Console.WriteLine("File exists");
                        file1Exists = true;
                        text1 = System.IO.File.ReadAllText(file1Name);
                        //Console.WriteLine(text1);
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }

                while (file2Exists == false)
                {
                    Console.WriteLine("Enter the name of file 2");
                    file2Name = Console.ReadLine();

                    if (File.Exists(file2Name))
                    {
                        Console.WriteLine("File exists");
                        file2Exists = true;
                        text2 = System.IO.File.ReadAllText(file2Name);
                        //Console.WriteLine(text2);
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                    if (file1Name == file2Name)
                    {
                        Console.WriteLine("You chose the same document twice");
                        file2Exists = false;
                    }
                }
                bool endsBool = file1Name.EndsWith(".txt", StringComparison.Ordinal);
                //Console.WriteLine(endsBool);
                if (endsBool == true)
                {
                    char[] file1CharArray = file1Name.ToCharArray();
                    int file1Length = file1CharArray.Length;
                    char[] file1NewCharArray = new char[file1Length - 4];

                    for (int i = 0; i < file1Length - 4; i++)
                    {
                        file1NewCharArray[i] = file1CharArray[i];
                        //Console.WriteLine(file1NewCharArray[i]);
                    }
                    string newFile1Name = new string(file1NewCharArray);
                    //Console.WriteLine(newFile1Name);
                    file1Name = newFile1Name;
                }
                endsBool = file2Name.EndsWith(".txt", StringComparison.Ordinal);
                if (endsBool == true)
                {
                    char[] file2CharArray = file2Name.ToCharArray();
                    int file2Length = file2CharArray.Length;
                    char[] file2NewCharArray = new char[file2Length - 4];

                    for (int i = 0; i < file2Length - 4; i++)
                    {
                        file2NewCharArray[i] = file2CharArray[i];
                        //Console.WriteLine(file1NewCharArray[i]);
                    }
                    string newFile2Name = new string(file2NewCharArray);
                    //Console.WriteLine(newFile2Name);
                    file2Name = newFile2Name;
                }
                string newFileName = file1Name + file2Name + ".txt";
                //Console.WriteLine(newFileName);
                string fullText = text1 + text2;
                try
                {
                    StreamWriter streamWriter = new StreamWriter(newFileName);
                    streamWriter.Write(fullText);
                    if (streamWriter != null)
                    {
                        streamWriter.Close();
                    }
                    Console.WriteLine("{0} was sucessfully saved. The document contains {1} characters.", newFileName, fullText.Length); //then exit program
                }
                catch (Exception e)
                {
                    Console.WriteLine("Program failed exception: " + e.Message);
                }

                Console.WriteLine("Would you like to merge two more files? \nEnter 1 for yes Enter \n2 for no");
                try
                {
                    loop = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                file1Exists = false;
                file2Exists = false;
            }
        }
    }
}
