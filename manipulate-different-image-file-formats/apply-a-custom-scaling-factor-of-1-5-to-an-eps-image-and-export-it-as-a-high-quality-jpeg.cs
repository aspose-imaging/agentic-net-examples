// HOW-TO: Scale EPS Image by 1.5 and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Calculate new dimensions with a scaling factor of 1.5
                int newWidth = (int)Math.Round(image.Width * 1.5);
                int newHeight = (int)Math.Round(image.Height * 1.5);

                // Resize using a high‑quality resampling method
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare high‑quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // maximum quality
                };

                // Save as JPEG
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
 * 1. When you need to enlarge a vector EPS logo to fit a larger layout while preserving detail and then deliver it as a high‑resolution JPEG for web or print.
 * 2. When a printing workflow requires converting EPS artwork to JPEG with a custom 1.5× scale to match a specific DPI requirement.
 * 3. When an e‑commerce platform must generate product thumbnails from EPS source files at a larger size with maximum JPEG quality for product pages.
 * 4. When a desktop application automates batch processing of EPS diagrams, scaling each by 150 % and saving them as lossless‑quality JPEGs for archival.
 * 5. When a reporting tool needs to embed EPS charts into PDF reports by first scaling them and converting to high‑quality JPEG images for compatibility.
 */
