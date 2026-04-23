using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.svg";

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
            // Resize proportionally (example: reduce size by 50%)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;
            image.Resize(newWidth, newHeight);

            // Prepare SVG rasterization options
            var vectorOptions = new SvgRasterizationOptions
            {
                // Preserve the resized image size
                PageSize = image.Size
            };

            // Prepare SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save the resized image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}