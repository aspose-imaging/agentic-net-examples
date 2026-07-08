using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

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
                // Cast to RasterImage to access cropping functionality
                RasterImage raster = (RasterImage)image;

                // Define the top-left quadrant rectangle
                var cropArea = new Rectangle(0, 0, raster.Width / 2, raster.Height / 2);

                // Crop the image
                raster.Crop(cropArea);

                // Prepare SVG save options with rasterization settings
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = raster.Size
                    }
                };

                // Save the cropped image as SVG
                raster.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to extract the top‑left quarter of a PNG screenshot and convert it to a scalable SVG for responsive web design, this code provides a quick C# solution using Aspose.Imaging.
 * 2. When an e‑learning platform wants to generate lightweight vector icons from high‑resolution raster assets by cropping a specific quadrant and saving it as SVG, the example demonstrates the required image processing steps.
 * 3. When a mobile app needs to create thumbnail previews of user‑uploaded photos by cropping the upper‑left area and storing them in SVG format for resolution‑independent display, the code shows how to accomplish it with Aspose.Imaging for .NET.
 * 4. When a GIS application must isolate a corner of a raster map tile and export it as an SVG overlay for further vector editing, this snippet illustrates the necessary cropping and raster‑to‑vector conversion.
 * 5. When a digital publishing workflow requires converting a portion of a scanned document (e.g., the top‑left quadrant) into an SVG graphic to embed in HTML articles, the example provides the exact C# implementation.
 */