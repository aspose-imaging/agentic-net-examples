using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.jpg";

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

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Set desired quality (1-100)
                    Quality = 85,
                    // Optional: set progressive compression
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    // Preserve resolution from source
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save as JPEG with the specified options
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
 * 1. When a desktop application needs to reduce the file size of user‑uploaded BMP screenshots before storing them in a database, it can use this code to convert them to JPEG with a specified quality.
 * 2. When a batch‑processing service must generate web‑ready thumbnails from legacy BMP assets, the code enables conversion to progressive JPEG while preserving the original resolution.
 * 3. When an automated report generator creates high‑resolution BMP charts but must embed them in PDF files that only support JPEG, this snippet converts the charts with controllable compression.
 * 4. When a migration tool moves image files from a Windows file server to a cloud storage bucket that enforces size limits, the code compresses BMP images to JPEG using the desired quality level.
 * 5. When a mobile backend receives BMP images from IoT devices and needs to serve them to browsers efficiently, the code transforms the BMPs into JPEGs with configurable quality and progressive encoding.
 */