using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Output SVG file path
        string outputPath = "output_resized.svg";

        // Desired dimensions (width and height)
        int targetWidth = 800;
        int targetHeight = 600;

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage to access vector-specific methods
            SvgImage svgImage = (SvgImage)image;

            // Resize while preserving aspect ratio
            svgImage.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

            // Save the resized image as SVG to preserve vector quality
            svgImage.Save(outputPath, new SvgOptions());
        }
    }
}