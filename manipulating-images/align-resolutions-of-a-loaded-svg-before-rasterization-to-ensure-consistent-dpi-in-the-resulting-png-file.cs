using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify that the input SVG file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage for vector‑specific properties
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options (page size matches the SVG size)
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Set PNG save options and align DPI via ResolutionSettings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                ResolutionSettings = new ResolutionSetting(300, 300) // 300 DPI horizontal and vertical
            };

            // Rasterize the SVG to PNG with the specified DPI
            svgImage.Save(outputPath, pngOptions);
        }
    }
}