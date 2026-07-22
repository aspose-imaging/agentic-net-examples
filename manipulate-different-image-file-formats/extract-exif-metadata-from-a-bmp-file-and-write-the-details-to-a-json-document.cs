using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\exif.json";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Retrieve EXIF data if present
                var exifData = image.Metadata?.ExifData;
                var exifDictionary = new Dictionary<string, object>();

                if (exifData != null)
                {
                    // Reflect over all public instance properties of the EXIF data object
                    PropertyInfo[] properties = exifData.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo prop in properties)
                    {
                        try
                        {
                            object value = prop.GetValue(exifData);
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to audit BMP files for embedded camera settings before importing them into a digital asset management system, they can extract EXIF metadata and store it in a JSON file for easy indexing.
 * 2. When a software solution must generate a searchable catalog of legacy BMP images by reading their EXIF tags and exporting the data to JSON for integration with a web API.
 * 3. When a forensic analyst wants to preserve image provenance by extracting BMP EXIF information and saving it as a structured JSON report for evidence documentation.
 * 4. When an automated pipeline processes user‑uploaded BMP pictures and requires the EXIF metadata to be logged in JSON format for compliance and auditing purposes.
 * 5. When a developer builds a cross‑platform image viewer that reads BMP EXIF details and writes them to a JSON configuration file to display metadata alongside the image.
 */