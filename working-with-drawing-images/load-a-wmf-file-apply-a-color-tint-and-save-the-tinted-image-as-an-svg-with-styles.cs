using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true // render text as shapes
                };

                // Configure rasterization options with a color tint (background color)
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.LightBlue, // tint color
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the tinted image as SVG
                wmfImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy WMF vector graphics to modern SVG files while applying a brand‑specific background tint for consistent web display.
 * 2. When an application must generate scalable SVG icons from WMF drawings and ensure the icons inherit a corporate color scheme by setting a LightBlue background.
 * 3. When a reporting tool has to embed WMF charts into HTML reports as SVGs with tinted backgrounds to match the report’s theme without losing vector quality.
 * 4. When a batch‑processing script must automate the transformation of a library of WMF assets into SVG format with a uniform color overlay for use in responsive UI designs.
 * 5. When a C# service processes user‑uploaded WMF files, applies a visual tint for accessibility contrast, and returns the result as an SVG with text rendered as shapes for cross‑platform compatibility.
 */