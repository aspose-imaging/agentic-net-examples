using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options
            var svgOptions = new SvgOptions();

            // Set vector rasterization options to define page size
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = vectorOptions;

            // If the GIF has multiple frames, export all frames
            if (image is IMultipageImage multipage && multipage.PageCount > 1)
            {
                // Export all pages (frames) of the GIF
                svgOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount));
            }

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}