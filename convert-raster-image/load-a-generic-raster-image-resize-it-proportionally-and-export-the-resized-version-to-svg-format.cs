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
            // Determine new size while preserving aspect ratio (e.g., 50% scaling)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize proportionally
            image.Resize(newWidth, newHeight);

            // Prepare SVG rasterization options
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Set page size to the resized image dimensions
                PageSize = image.Size
            };

            // Prepare SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the resized image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}