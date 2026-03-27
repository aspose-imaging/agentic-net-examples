using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using System.Text.Json;

class Program
{
    static void Main()
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

        // Ensure the output directory exists
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
            var exifData = tiff.ExifData;

            // Serialize EXIF data to JSON
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(exifData, jsonOptions);

            // Write JSON to the output file
            File.WriteAllText(outputPath, json);
        }
    }
}