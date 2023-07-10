
using Newtonsoft.Json;

namespace TellariniPietro.common
{
    /// <summary>
    /// Class to load and save JSON files.
    /// </summary>
    public static class JsonUtils
    {
        private const string DEFAULT_DATA = "data/";

        /// <summary>
        /// Load a JSON file from the given filepath and convert it to the given type.
        /// The method loads the file from the resources folder.
        /// </summary>
        /// <typeparam name="E">The type of the object to load.</typeparam>
        /// <param name="filepath">The path of the JSON file.</param>
        /// <returns>The object loaded from the JSON file.</returns>
        public static E Load<E>(string filepath)
        {
            string json;
            try
            {
                using (Stream stream = typeof(JsonUtils).Assembly.GetManifestResourceStream(filepath))
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"File not found: {filepath}");
                Console.WriteLine(e.Message);
                return default;
            }

            return JsonConvert.DeserializeObject<E>(json);
        }

        /// <summary>
        /// Load a JSON file from the given filepath and convert it to the given type.
        /// The method loads the file from the root folder outside the executable.
        /// </summary>
        /// <typeparam name="E">The type of the object to load.</typeparam>
        /// <param name="filePath">The path of the JSON file.</param>
        /// <returns>The object loaded from the JSON file.</returns>
        public static E LoadData<E>(string filePath)
        {
            try
            {
                using (StreamReader fileReader = File.OpenText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (E)serializer.Deserialize(fileReader, typeof(E));
                }
            }
            catch (IOException)
            {
                return Load<E>(DEFAULT_DATA + filePath);
            }
        }

        /// <summary>
        /// Save a list of objects into a JSON file.
        /// The method saves the file to the root folder outside the executable.
        /// </summary>
        /// <typeparam name="E">The type of the object to save.</typeparam>
        /// <param name="data">The list of objects to save.</param>
        /// <param name="filePath">The path of the JSON file.</param>
        public static void SaveData<E>(List<E> data, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Saving Data");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while saving the data:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
