using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class SvgResizeExample
{
    static void Main()
    {
        // Path to the source SVG file
        string inputPath = @"C:\Images\source.svg";

        // Path where the resized SVG will be saved
        string outputPath = @"C:\Images\resized.svg";

        // Desired dimensions (the aspect ratio will be preserved by the Resize method)
        int newWidth = 300;
        int newHeight = 300;

        // Load the SVG image using the standard Image.Load method (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to SvgImage to access SVG‑specific functionality
            SvgImage svgImage = (SvgImage)image;

            // Resize while preserving aspect ratio.
            // ResizeType.LanczosResample provides high‑quality resampling; any ResizeType can be used.
            svgImage.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Save the resized SVG (lifecycle rule)
            svgImage.Save(outputPath);
        }

        Console.WriteLine("SVG image resized and saved to: " + outputPath);
    }
}