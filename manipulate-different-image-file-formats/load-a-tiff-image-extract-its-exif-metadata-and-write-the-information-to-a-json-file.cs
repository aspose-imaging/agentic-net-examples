using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\exif.json";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access ExifData
                TiffImage tiff = image as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                // Retrieve EXIF metadata
                var exifData = tiff.ExifData;
                if (exifData == null)
                {
                    Console.Error.WriteLine("No EXIF data found in the TIFF image.");
                    return;
                }

                // Serialize EXIF data to JSON
                string json = JsonSerializer.Serialize(exifData, new JsonSerializerOptions { WriteIndented = true });

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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to audit camera settings and geolocation data from scanned TIFF photographs by extracting EXIF metadata and storing it in a readable JSON report.
 * 2. When a digital archiving system must catalog TIFF documents and preserve their metadata for search indexing, requiring conversion of EXIF tags to JSON for database ingestion.
 * 3. When a medical imaging application has to validate patient and equipment information embedded in TIFF X‑ray files by reading EXIF fields and exporting them as JSON for compliance logs.
 * 4. When a GIS workflow processes aerial TIFF imagery and must extract sensor orientation and GPS coordinates from EXIF data to feed into mapping software via a JSON file.
 * 5. When a batch processing tool needs to generate metadata inventories of large TIFF asset libraries, using C# to read EXIF data and serialize it into JSON for downstream analytics.
 */