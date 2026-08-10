// HOW-TO: Extract BMP EXIF Metadata and Save as JSON in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Retrieve metadata (may be null for BMP)
                var metadata = image.Metadata;
                var exifData = metadata?.ExifData;

                // Prepare a dictionary to hold EXIF tag values
                var exifDict = new Dictionary<string, object>();

                if (exifData != null)
                {
                    // Use reflection to read all public readable properties
                    var props = exifData.GetType().GetProperties();
                    foreach (var prop in props)
                    {
                        if (prop.CanRead)
                        {
                            try
                            {
                                var value = prop.GetValue(exifData);
                                // Skip null values to keep JSON concise
                                if (value != null)
                                {
                                    exifDict[prop.Name] = value;
                                }
                            }
                            catch
                            {
                                // Ignore any property that throws during get
                            }
                        }
                    }
                }

                // Serialize dictionary to JSON with indentation
                string json = JsonSerializer.Serialize(exifDict, new JsonSerializerOptions { WriteIndented = true });

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
 * 1. When you need to read camera or device information stored in a BMP file and store it in a portable JSON format for further analysis or reporting.
 * 2. When a legacy system produces BMP images with embedded EXIF tags and you must migrate the metadata to a modern database that accepts JSON payloads.
 * 3. When building a C# application that validates image compliance by comparing EXIF fields such as resolution or orientation against business rules.
 * 4. When creating an automated pipeline that extracts image properties from BMP files and feeds them to a logging service or analytics dashboard in JSON.
 * 5. When you want to provide end‑users a downloadable JSON file that lists all available EXIF attributes from their uploaded BMP pictures.
 */
