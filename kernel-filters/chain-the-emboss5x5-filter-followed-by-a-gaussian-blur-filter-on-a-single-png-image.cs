using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

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

                // Apply the Emboss 5x5 convolution filter
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                // Apply a Gaussian blur filter (radius 5, sigma 4.0)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Output any error messages without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to programmatically add a subtle 3‑D emboss effect to product photos and then smooth the result with a Gaussian blur before saving the PNG for an e‑commerce site.
 * 2. When a C# desktop application processes scanned PNG documents, applying an emboss filter to highlight edges and a Gaussian blur to soften artifacts before archival.
 * 3. When a game‑asset pipeline written in .NET applies an Emboss5x5 convolution to terrain heightmaps and follows it with a Gaussian blur to create smooth, stylized textures for real‑time rendering.
 * 4. When a photo‑editing tool provides a one‑click “engraved look” feature that runs the Emboss5x5 filter then a Gaussian blur on a PNG image to produce a professional matte finish.
 * 5. When an automated reporting service generates PNG icons, using emboss to give depth and a Gaussian blur to ensure consistent visual weight across different screen resolutions.
 */