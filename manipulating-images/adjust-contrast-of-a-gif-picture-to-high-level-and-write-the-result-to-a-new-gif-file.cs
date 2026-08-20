// HOW-TO: Increase GIF Contrast to Maximum Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.gif";
            string outputPath = "C:\\temp\\sample.adjusted.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                // Apply high contrast (maximum allowed value)
                gifImage.AdjustContrast(100f);

                // Save the modified image as GIF
                gifImage.Save(outputPath, new GifOptions());
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
 * 1. When you need to enhance the visual clarity of animated GIFs for a web gallery by boosting their contrast before publishing.
 * 2. When a marketing application automatically prepares product demo GIFs and requires high‑contrast images to stand out on social media.
 * 3. When a desktop tool processes user‑uploaded GIFs and must improve readability for low‑light screenshots by applying maximum contrast.
 * 4. When a reporting system generates GIF charts and wants to make the lines and colors more distinct for printed PDFs.
 * 5. When an e‑learning platform converts legacy GIF tutorials and needs to increase contrast to meet accessibility guidelines.
 */
