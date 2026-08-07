using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.json";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access EXIF data
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                // Extract EXIF metadata
                ExifData exifData = tiffImage.ExifData;

                // Serialize EXIF data to JSON (indented for readability)
                string json = JsonSerializer.Serialize(exifData, new JsonSerializerOptions { WriteIndented = true });

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
 * 1. When a developer needs to audit camera settings and geolocation data stored in TIFF files for a digital asset management system, they can load the image with Aspose.Imaging, extract its EXIF metadata, and export it to a JSON file for easy indexing.
 * 2. When building a compliance tool that verifies medical imaging TIFFs contain required metadata such as patient ID and acquisition date, the code can read the TIFF, pull the EXIF tags, and serialize them to JSON for reporting.
 * 3. When integrating a C# application with a web service that consumes image metadata in JSON format, developers can use this snippet to convert TIFF EXIF information into a JSON payload for API requests.
 * 4. When performing bulk migration of legacy TIFF archives to a cloud‑based metadata repository, the program can iterate over each file, extract its EXIF data with Aspose.Imaging, and store the results as structured JSON files.
 * 5. When creating a diagnostic utility that helps photographers troubleshoot missing or incorrect EXIF fields in high‑resolution TIFF scans, the code provides a quick way to read the image, retrieve its metadata, and output it as readable JSON.
 */