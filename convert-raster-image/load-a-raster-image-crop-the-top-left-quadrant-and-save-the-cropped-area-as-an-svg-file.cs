// HOW-TO: Crop Top Left Quadrant of PNG and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access cropping
                RasterImage rasterImage = (RasterImage)image;

                // Define top-left quadrant rectangle
                int cropWidth = rasterImage.Width / 2;
                int cropHeight = rasterImage.Height / 2;
                var cropArea = new Rectangle(0, 0, cropWidth, cropHeight);

                // Crop the image
                rasterImage.Crop(cropArea);

                // Save the cropped image as SVG
                var svgOptions = new SvgOptions();
                rasterImage.Save(outputPath, svgOptions);
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
 * 1. When you need to extract the upper‑left portion of a large PNG for use in a vector‑based web graphic.
 * 2. When generating scalable icons from raster screenshots by cropping a quadrant and converting it to SVG.
 * 3. When creating printable SVG assets from a specific region of a bitmap image in an automated C# workflow.
 * 4. When reducing file size by keeping only a quarter of an image and saving it in a resolution‑independent format.
 * 5. When integrating Aspose.Imaging into a batch process that trims images to a defined area and outputs them as SVG files.
 */
