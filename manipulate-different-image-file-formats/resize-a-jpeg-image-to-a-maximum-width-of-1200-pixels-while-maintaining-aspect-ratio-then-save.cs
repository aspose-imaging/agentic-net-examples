// HOW-TO: Resize JPEG to Max Width 1200 Pixels While Keeping Aspect Ratio in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                int newWidth = image.Width;
                int newHeight = image.Height;

                if (image.Width > 1200)
                {
                    double ratio = 1200.0 / image.Width;
                    newWidth = 1200;
                    newHeight = (int)Math.Round(image.Height * ratio);
                }

                if (newWidth != image.Width || newHeight != image.Height)
                {
                    image.Resize(newWidth, newHeight);
                }

                image.Save(outputPath);
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
 * 1. When you need to generate web‑optimized JPEGs that never exceed 1200 px wide to improve page load speed.
 * 2. When processing user‑uploaded photos for a gallery and you must enforce a maximum width while preserving the original proportions.
 * 3. When creating thumbnails for email newsletters where the image width must be limited to 1200 px without distortion.
 * 4. When preparing product images for an e‑commerce site that requires a consistent maximum dimension for all JPEG files.
 * 5. When automating batch conversion of high‑resolution photos to a size suitable for mobile devices while keeping aspect ratio.
 */
