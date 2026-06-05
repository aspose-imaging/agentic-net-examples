using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded file paths
        string inputPath = @"C:\Images\input.png";
        string resizedPngPath = @"C:\Images\resized.png";
        string outputSvgPath = @"C:\Images\output.svg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Desired dimensions (example: 800x600)
                int newWidth = 800;
                int newHeight = 600;

                // Resize using Lanczos resampling
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Ensure output directory exists for the resized PNG
                Directory.CreateDirectory(Path.GetDirectoryName(resizedPngPath));
                // Save the resized raster image as PNG
                image.Save(resizedPngPath, new PngOptions());

                // Ensure output directory exists for the SVG
                Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

                // Prepare SVG save options with rasterization settings
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Use the size of the resized image as the page size
                    PageSize = image.Size,
                    // High‑quality rendering settings
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the image as SVG (the raster image will be embedded in the SVG)
                image.Save(outputSvgPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}