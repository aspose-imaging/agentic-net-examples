using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.tif";
            string outputPath = @"C:\Images\exif.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access EXIF data
                TiffImage tiff = image as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                // Retrieve EXIF data
                ExifData exif = tiff.ExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("No EXIF data found.");
                    return;
                }

                // Convert EXIF properties to a dictionary for JSON serialization
                var dict = new Dictionary<string, object>();
                var props = exif.GetType().GetProperties();
                foreach (var prop in props)
                {
                    try
                    {
                        object value = prop.GetValue(exif);
                        // Encode byte arrays as Base64 strings for readability
                        if (value is byte[] bytes)
                        {
                            dict[prop.Name] = Convert.ToBase64String(bytes);
                        }
                        else
                        {
                            dict[prop.Name] = value;
                        }
                    }
                    catch
                    {
                        // Ignore properties that throw during get
                    }
                }

                // Serialize dictionary to formatted JSON
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract EXIF metadata from a TIFF image using Aspose.Imaging for .NET and serialize it to a JSON file for downstream analytics or API consumption.
 * 2. When a C# application must verify the presence of camera or scanner information embedded in a TIFF file and export that data in a readable JSON format for audit logging.
 * 3. When a workflow requires converting byte‑array EXIF tags (such as thumbnails) into Base64 strings and saving the complete metadata set as JSON to support cross‑platform data exchange.
 * 4. When an image‑processing service has to ensure the input TIFF exists, load it safely, and generate a JSON report of all EXIF properties for quality‑control dashboards.
 * 5. When a developer wants to automate the extraction of TIFF EXIF fields and store them in a structured JSON document to feed a metadata database or search index.
 */