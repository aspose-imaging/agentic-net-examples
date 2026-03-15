using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Input raster image (any supported format)
        string inputPath = @"C:\Temp\input.png";
        // Desired SVG output path
        string outputPath = @"C:\Temp\output.svg";

        // Load the source image using the unified Image.Load method
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Example transformation: resize while preserving aspect ratio
            // (optional – remove if no transformation is needed)
            int targetWidth = 800;
            int targetHeight = 600;
            sourceImage.Resize(targetWidth, targetHeight, ResizeType.LanczosResample);

            // Prepare SVG saving options
            SvgOptions svgOptions = new SvgOptions();

            // Configure vector rasterization options to match the transformed image size
            // This ensures the SVG retains visual fidelity and remains fully scalable.
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = sourceImage.Size,          // Set page size to the image dimensions
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the transformed image as SVG using the Save method that accepts ImageOptionsBase
            sourceImage.Save(outputPath, svgOptions);
        }
    }
}