using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.dng";
        string outputPath = @"C:\temp\output.jp2";

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

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = image as DngImage;
                if (dngImage == null)
                {
                    Console.Error.WriteLine("Failed to load DNG image.");
                    return;
                }

                // Prepare JPEG2000 save options for lossless compression and metadata preservation
                Jpeg2000Options jpeg2000Options = new Jpeg2000Options
                {
                    Irreversible = false,          // lossless DWT 5-3
                    KeepMetadata = true,           // preserve original metadata
                    ExifData = dngImage.ExifData,  // copy EXIF data
                    XmpData = dngImage.XmpData     // copy XMP data
                };

                // Save as JPEG2000
                image.Save(outputPath, jpeg2000Options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}