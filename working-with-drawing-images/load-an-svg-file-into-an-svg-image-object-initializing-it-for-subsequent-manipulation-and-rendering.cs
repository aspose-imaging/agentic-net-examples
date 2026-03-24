using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Temp\input.svg";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the SVG image
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Example usage: display image dimensions
            Console.WriteLine($"Loaded SVG - Width: {svgImage.Width}, Height: {svgImage.Height}");

            // Optional: rasterize and save as PNG
            string outputPath = @"C:\Temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure rasterization options
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image
            svgImage.Save(outputPath, pngOptions);
        }
    }
}