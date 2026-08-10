// HOW-TO: Resize JPEG to 1200px Width and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "c:\\temp\\sample.jpg";
            string outputPath = "c:\\temp\\sample_resized.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image using the JpegImage constructor
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Desired width
                int newWidth = 1200;
                // Compute height to preserve aspect ratio
                int newHeight = (int)Math.Round((double)jpegImage.Height * newWidth / jpegImage.Width);

                // Resize the image (default resampling)
                jpegImage.Resize(newWidth, newHeight);

                // Save the resized image as PNG
                jpegImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate web‑optimized thumbnails from high‑resolution JPEG photos while preserving their original proportions.
 * 2. When converting user‑uploaded JPEGs to lossless PNGs for archival or further image processing in a .NET application.
 * 3. When preparing product images for an e‑commerce site that requires a maximum width of 1200 pixels to ensure fast page loads.
 * 4. When standardizing image dimensions across a batch of photos before applying watermarking or other graphic overlays.
 * 5. When integrating image resizing into a server‑side API that receives JPEGs and returns PNGs at a consistent size for mobile apps.
 */
