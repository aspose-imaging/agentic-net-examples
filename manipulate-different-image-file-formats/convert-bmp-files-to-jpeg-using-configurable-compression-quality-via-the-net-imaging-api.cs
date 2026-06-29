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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Desired JPEG quality (1-100)
            int jpegQuality = 85;

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options
                var jpegOptions = new JpegOptions
                {
                    Quality = jpegQuality,
                    BitsPerChannel = 8,
                    CompressionType = JpegCompressionMode.Progressive,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the image as JPEG with the specified options
                image.Save(outputPath, jpegOptions);
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
 * 1. When a desktop application needs to batch‑convert legacy BMP screenshots to smaller JPEG files for faster web upload while controlling the compression quality.
 * 2. When an e‑commerce platform generates product thumbnails from high‑resolution BMP assets and must save them as progressive JPEGs with a specific quality setting to balance visual fidelity and page load speed.
 * 3. When a document‑management system receives scanned BMP images and must store them as JPEGs with 96 dpi resolution and 8‑bit channels to reduce storage costs without losing readability.
 * 4. When a Windows service processes user‑uploaded BMP logos and needs to output JPEG files with configurable quality for email newsletters that support only JPEG image format.
 * 5. When a photo‑editing tool offers a “Save As JPEG” feature that lets developers specify the compression level, resolution unit, and progressive encoding for BMP files using the Aspose.Imaging .NET API.
 */