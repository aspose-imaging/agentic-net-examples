using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

public static class SvgToRasterPrerequisites
{
    // Demonstrates the required steps before rasterizing an SVG image.
    public static void ConvertSvgToPng(string svgFilePath, string outputPngPath)
    {
        // 1. Load the SVG image. Aspose.Imaging.Image.Load provides a unified loading mechanism.
        using (Image image = Image.Load(svgFilePath))
        {
            // 2. Ensure the loaded image is an SVG image.
            if (image is not SvgImage svgImage)
                throw new InvalidOperationException("The provided file is not a valid SVG image.");

            // 3. Create rasterization options. These options define how the vector content will be rasterized.
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the background color for the rasterized image (default is white).
                BackgroundColor = Color.White,

                // Define the output page size. Using the original SVG size preserves dimensions.
                PageSize = svgImage.Size,

                // Enable anti-aliasing for smoother lines and curves.
                SmoothingMode = SmoothingMode.AntiAlias,

                // Use anti-aliased text rendering.
                TextRenderingHint = TextRenderingHint.AntiAlias,

                // Optional: scale the output (1.0 = 100%). Adjust as needed.
                ScaleX = 1.0f,
                ScaleY = 1.0f
            };

            // 4. Create PNG save options and attach the rasterization options.
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // 5. Save the rasterized image to the desired format (PNG in this case).
            svgImage.Save(outputPngPath, pngOptions);
        }
    }

    // Example usage.
    public static void Main()
    {
        string inputSvg = @"C:\Images\example.svg";
        string outputPng = @"C:\Images\example_converted.png";

        ConvertSvgToPng(inputSvg, outputPng);

        Console.WriteLine("SVG has been rasterized to PNG successfully.");
    }
}