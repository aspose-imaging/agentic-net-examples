using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
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
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\exif.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access EXIF data
                TiffImage tiff = image as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                // Retrieve EXIF metadata
                ExifData exif = tiff.ExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("No EXIF data found in the TIFF image.");
                    return;
                }

                // Convert EXIF data to a dictionary for JSON serialization
                var exifDict = new Dictionary<string, object>();
                var properties = exif.GetType().GetProperties();
                foreach (var prop in properties)
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

                // Serialize dictionary to formatted JSON
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