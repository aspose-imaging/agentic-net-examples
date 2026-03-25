using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\resized_output.svg";

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
            // Desired dimensions (example: 800x600)
            int newWidth = 800;
            int newHeight = 600;

            // Resize using Lanczos resampling for high quality
            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Prepare SVG export options with rasterization settings
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Preserve the resized dimensions
                PageSize = image.Size
            };

            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the resized image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}