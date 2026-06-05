using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\sample.png";
            string outputPath = @"c:\temp\sample.GaussianBlurSharpen.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (radius: 5, sigma: 4.0) to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));

                // Apply Sharpen filter (kernel size: 5, sigma: 4.0) to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to reduce high‑frequency noise in a PNG screenshot before enhancing edge details for a UI preview, they can apply Gaussian blur followed by a sharpen filter using Aspose.Imaging in C#.
 * 2. When preparing product photos for an e‑commerce website, a developer may blur background artifacts in a PNG and then sharpen the main subject to improve visual clarity with the provided filter sequence.
 * 3. When generating thumbnails for a digital asset management system, a developer can smooth out compression artifacts in PNG images with Gaussian blur and then restore sharpness to maintain recognizability.
 * 4. When processing scanned documents saved as PNG files, a developer might first blur speckles caused by scanning and then sharpen text edges to improve OCR accuracy using the Aspose.Imaging filter pipeline.
 * 5. When creating stylized graphics for a game’s UI, a developer can apply a subtle Gaussian blur to soften color transitions in a PNG and subsequently sharpen outlines to achieve a crisp, polished look.
 */