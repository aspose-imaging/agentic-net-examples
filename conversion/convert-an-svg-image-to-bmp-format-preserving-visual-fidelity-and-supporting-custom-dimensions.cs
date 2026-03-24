using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired dimensions for the output bitmap
        int targetWidth = 800;   // custom width
        int targetHeight = 600;  // custom height

        // Load the SVG image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to SvgImage to access SVG-specific methods
            var svgImage = (SvgImage)image;

            // Resize while preserving aspect ratio (using nearest neighbour resample)
            svgImage.Resize(targetWidth, targetHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

            // Prepare BMP save options
            var bmpOptions = new BmpOptions();

            // Save the rasterized image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}