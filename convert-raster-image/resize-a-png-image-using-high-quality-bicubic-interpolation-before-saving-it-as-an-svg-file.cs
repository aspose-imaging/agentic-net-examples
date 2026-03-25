using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Define new dimensions (example: double the size)
            int newWidth = image.Width * 2;
            int newHeight = image.Height * 2;

            // Resize using high‑quality bicubic interpolation
            image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

            // Prepare SVG save options with rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    // Set page size to match the resized image dimensions
                    PageSize = image.Size
                }
            };

            // Save the resized image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}