using System;
using System.IO;
using UnityEngine;

namespace Utility
{
    public static class SaveUtility
    {
        /// <summary>
        /// Grabs any public variable from an object and saves it to a file. 
        /// </summary>
        /// <param name="so">object to save</param>
        /// <param name="dir">Directory to save it to. /Directory/ </param>
        /// <param name="fileName">Name of the file to save it to.</param>
        public static void Save(object so, string dir, string fileName)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            fileName = FileNameFixer(fileName);
            dir = DirectoryFixer(dir);
            string json = JsonUtility.ToJson(so);
            File.WriteAllText(dir + fileName, json);
        }
        
        /// <summary>
        /// Loads a json file.
        /// </summary>
        /// <param name="filePath">Directory to load from </param>
        /// <param name="fileName">Name of the file to load from</param>
        /// <typeparam name="T">Expected object return type</typeparam>
        /// <returns>Object of type T</returns>
        public static T Load<T>(string filePath, string fileName)
        {
            return (T)Load(typeof(T), filePath, fileName);
        }

        /// <summary>
        /// Loads a Json File.
        /// </summary>
        /// <param name="type">Return type of object</param>
        /// <param name="directory">Directory to load from</param>
        /// <param name="fileName">Name of the file to load</param>
        /// <returns>Object of type T</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static object Load(Type type, string directory, string fileName)
        {
            object so;
            directory = DirectoryFixer(directory);
            fileName = FileNameFixer(fileName);
            
            
            if (File.Exists(directory + fileName))
            {
                var json = File.ReadAllText(directory + fileName);
                so = JsonUtility.FromJson(json, type);
            }
            else
            {
                throw new FileNotFoundException("Cannot find " + directory + fileName);
            }

            return so;
        }

        private static string DirectoryFixer(string directory)
        {
            if (!directory.Substring(directory.Length - 1).Equals("/"))
            {
                directory += "/";
            }
            if (!directory.Substring(0, 1).Equals("/"))
            {
                directory = "/" + directory;
            }

            return directory;
        }

        private static string FileNameFixer(string fileName)
        {
            if (fileName.Length >= 5)
            {
                if (!fileName.Substring(fileName.Length - 5, 5).Equals(".json"))
                {
                    fileName += ".json";
                }
            }
            else
            {
                fileName += ".json";
            }

            return fileName;
        }
        
    }
}