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

                // Retrieve EXIF metadata
                ExifData exifData = tiffImage.ExifData;
                if (exifData == null)
                {
                    Console.Error.WriteLine("No EXIF data found in the TIFF image.");
                    return;
                }

                // Serialize EXIF data to JSON
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(exifData, jsonOptions);

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