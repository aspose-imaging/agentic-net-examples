using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options to preserve fidelity
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                // Use a neutral background; change if needed
                BackgroundColor = Color.White,

                // Preserve original size; can be changed for scaling
                PageSize = svgImage.Size,

                // Apply anti-aliasing for smooth edges
                SmoothingMode = SmoothingMode.AntiAlias,

                // Render text with high quality
                TextRenderingHint = TextRenderingHint.AntiAlias,

                // Scale factors (1.0 = original size). Adjust to resize while keeping aspect ratio.
                ScaleX = 1.0f,
                ScaleY = 1.0f
            };

            // Set up PNG save options and attach the rasterization settings
            PngOptions saveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized PNG
            svgImage.Save(outputPath, saveOptions);
        }
    }
}