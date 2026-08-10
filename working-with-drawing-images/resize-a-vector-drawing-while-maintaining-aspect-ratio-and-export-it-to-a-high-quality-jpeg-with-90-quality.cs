// HOW-TO: Resize SVG to JPEG With Aspect Ratio and 90% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\vector.svg";
        string outputPath = @"C:\Images\Resized\vector_resized.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (e.g., SVG, EPS, etc.)
            using (Image image = Image.Load(inputPath))
            {
                // Desired maximum width (you can adjust as needed)
                const int targetWidth = 800;

                // Calculate new dimensions while preserving aspect ratio
                double scale = (double)targetWidth / image.Width;
                int newWidth = targetWidth;
                int newHeight = (int)Math.Round(image.Height * scale);

                // Resize using a high‑quality resampling method
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare JPEG save options with 90 % quality
                var jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    // Optional: set resolution to 96 dpi
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the resized image as JPEG
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
 * 1. When you need to generate web‑ready thumbnails from scalable SVG logos while preserving their proportions and saving them as high‑quality JPEGs.
 * 2. When an e‑commerce platform must convert product vector illustrations to fixed‑size JPEG images for email newsletters without distortion.
 * 3. When a reporting tool requires embedding resized vector diagrams into PDF reports that only support raster JPEG images at a specific resolution.
 * 4. When a mobile app backend must downscale user‑uploaded EPS files to 800 px width JPEGs with 90 % quality to reduce bandwidth.
 * 5. When a digital asset management system automates batch processing of SVG assets, resizing them uniformly and storing them as JPEGs for legacy applications.
 */
