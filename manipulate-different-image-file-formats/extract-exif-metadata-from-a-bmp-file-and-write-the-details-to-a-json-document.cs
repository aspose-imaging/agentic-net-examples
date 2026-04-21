using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Retrieve EXIF data if present
                ExifData exifData = image.Metadata?.ExifData;
                var exifDictionary = new Dictionary<string, object?>();

                if (exifData != null)
                {
                    // Use reflection to collect all readable properties
                    PropertyInfo[] properties = exifData.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var prop in properties)
                    {
                        if (prop.CanRead)
                        {
                            try
                            {
                                object? value = prop.GetValue(exifData);
                                if (value != null)
                                {
                                    exifDictionary[prop.Name] = value;
                                }
                            }
                            catch
                            {
                                // Ignore properties that throw on get
                            }
                        }
                    }
                }

                // Serialize the dictionary to JSON
                string json = JsonSerializer.Serialize(exifDictionary, new JsonSerializerOptions { WriteIndented = true });

                // Write JSON to the output file
                File.WriteAllText(outputPath, json);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}