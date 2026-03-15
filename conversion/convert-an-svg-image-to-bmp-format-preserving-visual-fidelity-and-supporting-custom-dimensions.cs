using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Output BMP file path
        string outputPath = "output.bmp";
        // Desired dimensions for the output image
        int targetWidth = 800;
        int targetHeight = 600;

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage to access SVG-specific methods
            SvgImage svgImage = (SvgImage)image;

            // Resize the SVG while preserving visual fidelity
            svgImage.Resize(targetWidth, targetHeight, ResizeType.LanczosResample);

            // Prepare BMP save options
            BmpOptions bmpOptions = new BmpOptions();

            // Save the resized image as BMP
            svgImage.Save(outputPath, bmpOptions);
        }
    }
}