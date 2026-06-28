using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\source.eps";
        string outputPath = @"C:\Images\Resized\output.jpg";

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

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new height to maintain aspect ratio for width = 2000
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

                // Resize using Mitchell cubic interpolation
                image.Resize(newWidth, newHeight, ResizeType.Mitchell);

                // Save as JPEG with default options
                image.Save(outputPath, new JpegOptions());
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
 * 1. When a print designer needs to convert high‑resolution EPS artwork to a web‑friendly JPEG of exactly 2000 px width while preserving the original aspect ratio, they can use this C# Aspose.Imaging code.
 * 2. When an e‑commerce platform must generate product thumbnails from vector EPS logos and ensure consistent width across all images, the snippet resizes and saves them as JPEGs automatically.
 * 3. When a publishing workflow requires batch processing of EPS files into JPEGs for digital distribution, this code demonstrates how to load, resize with Mitchell interpolation, and export the images in .NET.
 * 4. When a mobile app backend needs to serve scaled‑down JPEG previews of large EPS diagrams without distortion, the example shows the calculation of proportional height and saving with default JPEG options.
 * 5. When a content management system must validate that an EPS file exists, create the output folder, and then produce a 2000‑pixel‑wide JPEG for SEO‑optimized web pages, the provided C# routine handles the entire process.
 */