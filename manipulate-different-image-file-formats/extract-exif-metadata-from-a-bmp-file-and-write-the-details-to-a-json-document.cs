using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.json";

        // Ensure any runtime exception is reported cleanly
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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Retrieve EXIF data if present
                ExifData exif = image.Metadata?.ExifData;

                // Prepare a dictionary to hold EXIF properties
                var exifDictionary = new Dictionary<string, object?>();

                if (exif != null)
                {
                    // Reflect over all public properties of the EXIF data object
                    var properties = exif.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        try
                        {
                            object? value = prop.GetValue(exif);
                            // Store only non-null values for clarity
                            if (value != null)
                            {
                                exifDictionary[prop.Name] = value;
                            }
                        }
                        catch
                        {
                            // Ignore any property that throws during retrieval
                        }
                    }
                }

                // Serialize the dictionary to JSON (empty object if no EXIF data)
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