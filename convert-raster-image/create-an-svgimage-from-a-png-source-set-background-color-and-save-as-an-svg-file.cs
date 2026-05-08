using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\result.svg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image pngImage = Image.Load(inputPath))
            {
                // Cast to RasterImage to obtain dimensions
                RasterImage raster = pngImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Create a new SVG image with the same dimensions as the PNG
                using (SvgImage svgImage = new SvgImage(raster.Width, raster.Height))
                {
                    // Set the background color of the SVG image
                    svgImage.BackgroundColor = Aspose.Imaging.Color.LightGray;
                    svgImage.HasBackgroundColor = true;

                    // Save the SVG image to the output path
                    svgImage.Save(outputPath, new SvgOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}