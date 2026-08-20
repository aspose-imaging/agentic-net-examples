// HOW-TO: Set JPEG Color Type to Grayscale and Save Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with Grayscale color type
                var saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Grayscale,
                    // Optional: set quality and other parameters as needed
                    Quality = 100,
                    BitsPerChannel = 8,
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the image as a grayscale JPEG
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to generate a smaller file size for printing by converting color images to grayscale JPEGs using Aspose.Imaging in a .NET application.
 * 2. When a web service must deliver grayscale thumbnails of uploaded BMP files to reduce bandwidth and improve loading speed.
 * 3. When an archival system requires all stored photos to be in a standard grayscale JPEG format for consistent viewing across devices.
 * 4. When a medical imaging workflow converts scanned documents to grayscale JPEGs to meet DICOM compliance while preserving resolution.
 * 5. When a batch processing script automates conversion of color BMP assets to grayscale JPEGs for use in machine‑learning preprocessing.
 */
