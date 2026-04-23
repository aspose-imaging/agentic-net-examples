using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image, resize with high‑quality bicubic interpolation, and save as SVG
        using (Image image = Image.Load(inputPath))
        {
            // Desired dimensions (example: 400x400)
            int newWidth = 400;
            int newHeight = 400;

            // High‑quality bicubic interpolation
            image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

            // Save the resized image as SVG
            var svgOptions = new SvgOptions();
            image.Save(outputPath, svgOptions);
        }
    }
}