// HOW-TO: Extract TIFF EXIF Metadata to JSON Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.json";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access ExifData
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The provided file is not a TIFF image.");
                    return;
                }

                // Retrieve EXIF data
                var exifData = tiffImage.ExifData;
                var exifDictionary = new Dictionary<string, object>();

                if (exifData != null)
                {
                    // Use reflection to read all public properties of the ExifData object
                    var exifType = exifData.GetType();
                    foreach (var prop in exifType.GetProperties())
                    {
                        try
                        {
                            var value = prop.GetValue(exifData);
                            exifDictionary[prop.Name] = value;
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
 * 1. When you need to read camera information from a scanned TIFF file and store it in a machine‑readable JSON format for further analysis.
 * 2. When a digital archiving system must catalog TIFF images by extracting their EXIF tags and saving the data to a database via JSON.
 * 3. When a web service receives TIFF uploads and you want to expose the embedded metadata to client applications as JSON.
 * 4. When you are building a migration tool that converts legacy TIFF metadata into JSON files for integration with modern analytics pipelines.
 * 5. When you need to validate or audit the EXIF properties of TIFF documents by exporting them to a readable JSON report.
 */
