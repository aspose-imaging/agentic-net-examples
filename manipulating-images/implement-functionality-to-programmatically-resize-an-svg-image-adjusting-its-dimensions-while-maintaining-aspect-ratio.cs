using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Desired width for the resized image
            int targetWidth = 200;

            // Calculate height to preserve aspect ratio
            double scale = (double)targetWidth / svgImage.Width;
            int targetHeight = (int)Math.Round(svgImage.Height * scale);

            // Resize while maintaining aspect ratio
            svgImage.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

            // Save the resized SVG
            svgImage.Save(outputPath);
        }
    }
}