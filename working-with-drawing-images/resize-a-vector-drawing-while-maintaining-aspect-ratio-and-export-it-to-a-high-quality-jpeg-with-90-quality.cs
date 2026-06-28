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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\vector.svg";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Desired maximum dimensions
                const int maxWidth = 800;
                const int maxHeight = 600;

                // Compute scaling factor while preserving aspect ratio
                double widthScale = (double)maxWidth / image.Width;
                double heightScale = (double)maxHeight / image.Height;
                double scale = Math.Min(widthScale, heightScale);
                if (scale > 1) scale = 1; // Do not upscale

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Resize using a high‑quality resample method
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare JPEG save options with 90% quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    // Optional: set resolution unit and DPI if needed
                    ResolutionUnit = ResolutionUnit.Inch,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                };

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos for product listings, it can use this C# code to resize the vector while preserving aspect ratio and save a 90 % quality JPEG for fast browser rendering.
 * 2. When an e‑commerce platform must convert scalable vector graphics of product diagrams into printable JPEG images at a maximum size of 800×600 pixels, the code ensures the images are down‑scaled without distortion and retain high visual fidelity.
 * 3. When a content management system automatically creates responsive images for blog posts from SVG illustrations, developers can employ this snippet to produce optimized JPEGs that fit within layout constraints while maintaining the original proportions.
 * 4. When a desktop reporting tool needs to embed company branding SVG files into PDF reports as raster images, the code resizes the vectors to the required dimensions and exports them as high‑quality JPEGs for consistent appearance across devices.
 * 5. When a mobile app backend processes vector icons uploaded by designers and must deliver them as compressed JPEG assets for low‑bandwidth networks, this C# routine resizes the SVGs, keeps the aspect ratio, and saves them with 90 % quality to balance size and clarity.
 */