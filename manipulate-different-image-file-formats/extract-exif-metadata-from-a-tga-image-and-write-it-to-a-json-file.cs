using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.json";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the TGA image
        using (TgaImage image = (TgaImage)Image.Load(inputPath))
        {
            // Access EXIF data
            var exif = image.ExifData;

            // Convert EXIF properties to a dictionary for JSON serialization
            var exifDict = new Dictionary<string, object>();

            if (exif != null)
            {
                Type exifType = exif.GetType();
                foreach (PropertyInfo prop in exifType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    try
                    {
                        object value = prop.GetValue(exif);
                        exifDict[prop.Name] = value;
                    }
                    catch
                    {
                        // Ignore properties that cannot be read
                    }
                }
            }

            // Serialize dictionary to JSON
            string json = JsonSerializer.Serialize(exifDict, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON to output file
            File.WriteAllText(outputPath, json);
        }
    }
}