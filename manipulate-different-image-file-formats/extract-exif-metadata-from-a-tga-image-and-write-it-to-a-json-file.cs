using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.json";

        try
        {
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
                if (exif == null)
                {
                    Console.WriteLine("No EXIF data found.");
                    return;
                }

                // Convert EXIF properties to a dictionary for JSON serialization
                var dict = new Dictionary<string, object>();
                foreach (PropertyInfo prop in exif.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    try
                    {
                        var value = prop.GetValue(exif);
                        if (value != null)
                        {
                            dict[prop.Name] = value;
                        }
                    }
                    catch
                    {
                        // Ignore properties that throw on get
                    }
                }

                // Serialize to JSON with indentation
                string json = JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true });

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