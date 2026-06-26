using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Wrap the whole execution in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input and output file paths.
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image.
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options for transparent background.
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set background color to transparent.
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    // Optionally indicate that the image has no background color.
                    // This can be useful for some formats.
                    // HasBackgroundColor = false // Uncomment if needed.
                };

                // Set up PNG save options and attach the rasterization options.
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG.
                svgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any error message without crashing.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer uses Aspose.Imaging for .NET to convert SVG icons into PNG files with a transparent background for responsive UI overlays.
 * 2. When an e‑commerce platform employs the Aspose.Imaging C# library to turn product SVG illustrations into transparent PNG thumbnails that adapt to any site theme.
 * 3. When a mobile app builds high‑resolution PNG sprites from SVG logos using Aspose.Imaging’s rasterization options, preserving transparency for the app bundle.
 * 4. When a reporting service rasterizes SVG charts into PNG images via Aspose.Imaging for PDF export, needing a transparent background to match the document’s color scheme.
 * 5. When an automated CI/CD pipeline processes SVG brand assets into PNG assets with Aspose.Imaging for .NET, ensuring the output images retain transparency for email newsletters.
 */