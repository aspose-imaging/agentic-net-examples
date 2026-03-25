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
            // Prepare SVG rasterization options with transparent background
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Aspose.Imaging.Color.Transparent
            };

            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as SVG without background
            image.Save(outputPath, svgOptions);
        }
    }
}