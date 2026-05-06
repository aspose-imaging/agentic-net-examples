using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.json";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load BMP image
            using (BmpImage image = (BmpImage)Image.Load(inputPath))
            {
                // Retrieve EXIF data if available
                var exifData = image.Metadata?.ExifData;

                // Prepare a dictionary to hold EXIF tag values
                var exifDictionary = new Dictionary<string, object>();

                if (exifData != null)
                {
                    var properties = exifData.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        try
                        {
                            var value = prop.GetValue(exifData);
                            if (value != null)
                            {
                                exifDictionary[prop.Name] = value;
                            }
                        }
                        catch
                        {
                            // Ignore properties that throw during get
                        }
                    }
                }

                // Serialize dictionary to JSON
                string json = JsonSerializer.Serialize(exifDictionary, new JsonSerializerOptions { WriteIndented = true });

                // Write JSON to output file
                File.WriteAllText(outputPath, json);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}