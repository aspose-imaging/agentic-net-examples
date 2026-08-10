// HOW-TO: Convert EPS To Optimized 256‑Color PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/optimized.png";

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

            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Enable automatic palette adjustment (reduces colors)
                epsImage.AutoAdjustPalette = true;

                // Save as PNG with default options
                epsImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to embed a vector EPS logo into a web page that only supports PNG, reducing the palette to 256 colors to keep the file size low.
 * 2. When preparing print‑ready assets for a mobile app that requires PNG images with limited color depth to meet platform constraints.
 * 3. When converting legacy EPS illustrations to PNG for use in email newsletters where large file sizes must be minimized.
 * 4. When automating a batch process that transforms EPS diagrams into PNG thumbnails with a reduced color palette for faster loading.
 * 5. When optimizing EPS artwork for a content management system that only accepts PNG files and enforces a maximum of 256 colors per image.
 */
