#region License
/*
Copyright © 2014-2018 European Support Limited

Licensed under the Apache License, Version 2.0 (the "License")
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0 

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/
#endregion


using GingerPlugInsNET.ActionsLib;
using GingerPlugInsNET.PlugInsLib;
using System;
using System.IO;

namespace StandAloneActions
{
    public class GingerFilePlugin : IStandAloneAction
    {
        //TODO: check if it works on Linux and Mac !!!!

        [GingerAction("Amdocs.Ginger.StandAloneActions.FileAction.FileExist", "Check if File Exist")]
        public void FileExist(ref GingerAction GA, string FilePath)
        {
            if (File.Exists(FilePath))
            {
                GA.Output.Add("Value", "True");
            }
            else
            {
                GA.Output.Add("Value", "False");
            }
            GA.ExInfo = "FileExist: " + FilePath;
        }

        [GingerAction("File.Copy", "Copy file")]
        public void FileCopy(ref GingerAction GA, string SourceFileName, string destFileName, bool overWrite = false)
        {
            if (File.Exists(SourceFileName))
            {
                File.Copy(SourceFileName, destFileName, overWrite);
            }
            else
            {
                throw new Exception("File not found for copy: " + SourceFileName);
            }
            GA.ExInfo = "File copied: " + SourceFileName + "==>" + destFileName;
        }

        [GingerAction("File.Info", "Get file information")]
        public void aFileInfo(ref GingerAction GA, string FilePath)
        {
            if (File.Exists(FilePath))
            {
                FileInfo FI = new FileInfo(FilePath);
                GA.Output.Add("Length", FI.Length.ToString());
                GA.Output.Add("Extension", FI.Extension);
                GA.Output.Add("LastAccessTime", FI.LastAccessTime.ToString());
                GA.Output.Add("LastAccessTimeUtc", FI.LastAccessTimeUtc.ToString());
                GA.Output.Add("CreationTime", FI.CreationTime.ToString());
                GA.Output.Add("CreationTimeUtc", FI.CreationTimeUtc.ToString());
                GA.Output.Add("CreationTimeUtc", FI.LastWriteTime.ToString());
                GA.Output.Add("LastWriteTimeUtc", FI.LastWriteTimeUtc.ToString());
            }
            else
            {
                throw new Exception("File not found" + FilePath);
            }
            GA.ExInfo = "File info: " + FilePath;
        }


        [GingerAction("File.Info", "Get file information")]
        public void ReadLines(ref GingerAction GA, string FilePath)
        {
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                int i = 0;
                foreach(string line in lines)
                {
                    i++;
                    GA.Output.Add("Line", line, i.ToString() );
                }
            }
            else
            {
                throw new Exception("File not found" + FilePath);
            }
            GA.ExInfo = "File info: " + FilePath;
        }


        [GingerAction("File.Info", "Get file information")]
        public void SearchText(ref GingerAction GA, string FilePath, string searchText)
        {
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                int i = 0;
                foreach (string line in lines)
                {
                    i++;
                    if (line.Contains(searchText))
                    {
                        GA.Output.Add("Found at Line", line, i.ToString());
                    }
                }
            }
            else
            {
                throw new Exception("File not found" + FilePath);
            }
            GA.ExInfo = "File info: " + FilePath;
        }


        [GingerAction("File.Create", "Get file information")]
        public void CreateFile(ref GingerAction GA, string FilePath)
        {
            File.Create(FilePath);
            //if (File.Exists(FilePath))
            //{
                
            //    int i = 0;
            //    foreach (string line in lines)
            //    {
            //        i++;
            //        if (line.Contains(searchText))
            //        {
            //            GA.Output.Add("Found at Line", line, i);
            //        }
            //    }
            //}
            //else
            //{
            //    throw new Exception("File not found" + FilePath);
            //}
            GA.ExInfo = "File create: " + FilePath;
        }

        [GingerAction("File.Create", "Get file information")]
        public void DeleteFile(ref GingerAction GA, string FilePath)
        {
            File.Delete(FilePath);
            //if (File.Exists(FilePath))
            //{

            //    int i = 0;
            //    foreach (string line in lines)
            //    {
            //        i++;
            //        if (line.Contains(searchText))
            //        {
            //            GA.Output.Add("Found at Line", line, i);
            //        }
            //    }
            //}
            //else
            //{
            //    throw new Exception("File not found" + FilePath);
            //}
            GA.ExInfo = "File create: " + FilePath;
        }


        [GingerAction("File.Move", "Get file information")]
        public void Move(ref GingerAction GA, string SourceFileName, string DestintionFileName)
        {
            File.Move (SourceFileName, DestintionFileName);
            //if (File.Exists(FilePath))
            //{

            //    int i = 0;
            //    foreach (string line in lines)
            //    {
            //        i++;
            //        if (line.Contains(searchText))
            //        {
            //            GA.Output.Add("Found at Line", line, i);
            //        }
            //    }
            //}
            //else
            //{
            //    throw new Exception("File not found" + FilePath);
            //}
            // GA.ExInfo = "File create: " + FilePath;
        }

        [GingerAction("File.Move", "Get file information")]
        public void WriteAllText(ref GingerAction GA, string fileName, string content)
        {
            File.WriteAllText (fileName, content);
            //if (File.Exists(FilePath))
            //{

            //    int i = 0;
            //    foreach (string line in lines)
            //    {
            //        i++;
            //        if (line.Contains(searchText))
            //        {
            //            GA.Output.Add("Found at Line", line, i);
            //        }
            //    }
            //}
            //else
            //{
            //    throw new Exception("File not found" + FilePath);
            //}
            // GA.ExInfo = "File create: " + FilePath;
        }

        [GingerAction("File.Move", "Get file information")]
        public void WriteLines(ref GingerAction GA, string fileName, string content)
        {
            ///File.WriteAllLines .WriteAllText(fileName, content);
            //if (File.Exists(FilePath))
            //{

            //    int i = 0;
            //    foreach (string line in lines)
            //    {
            //        i++;
            //        if (line.Contains(searchText))
            //        {
            //            GA.Output.Add("Found at Line", line, i);
            //        }
            //    }
            //}
            //else
            //{
            //    throw new Exception("File not found" + FilePath);
            //}
            // GA.ExInfo = "File create: " + FilePath;
        }

    }
}