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
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\vector.svg";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (e.g., SVG, EPS, etc.)
            using (Image image = Image.Load(inputPath))
            {
                // Desired maximum dimensions
                const int maxWidth = 1200;
                const int maxHeight = 1200;

                // Compute scaling factor while preserving aspect ratio
                double widthScale = (double)maxWidth / image.Width;
                double heightScale = (double)maxHeight / image.Height;
                double scale = Math.Min(widthScale, heightScale);
                if (scale > 1) scale = 1; // Do not upscale beyond original size

                int newWidth = (int)Math.Round(image.Width * scale);
                int newHeight = (int)Math.Round(image.Height * scale);

                // Resize using a high‑quality resampling algorithm
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare JPEG save options with 90 % quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    // Optional: keep resolution at 96 dpi
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the rasterized image as JPEG
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
 * 1. When a web application must generate thumbnail previews of user‑uploaded SVG logos that fit within a 1200 × 1200 pixel box while preserving the original aspect ratio and then serve them as high‑quality JPEGs for browsers that do not support SVG.
 * 2. When an e‑commerce platform needs to convert scalable product illustrations (e.g., EPS or SVG files) into optimized 90 % quality JPEG images for email newsletters, ensuring the images are resized proportionally to avoid distortion.
 * 3. When a desktop publishing tool automates the preparation of print‑ready assets by loading vector artwork, resizing it with Lanczos resampling to maintain visual fidelity, and exporting a JPEG with 90 % quality for inclusion in PDF catalogs.
 * 4. When a content management system processes batch uploads of vector graphics, using Aspose.Imaging in C# to limit each image to a maximum width or height of 1200 px, keep the original aspect ratio, and store the result as a high‑quality JPEG for faster page loads.
 * 5. When a mobile app backend needs to serve responsive images by converting scalable SVG icons into JPEGs that are no larger than 1200 px in either dimension, applying high‑quality resampling and a 90 % JPEG compression setting to balance image clarity with bandwidth usage.
 */