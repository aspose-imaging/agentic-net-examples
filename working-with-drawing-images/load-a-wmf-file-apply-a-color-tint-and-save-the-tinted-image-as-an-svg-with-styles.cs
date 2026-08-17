// HOW-TO: Apply Light Blue Tint to WMF and Export as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to WmfImage for vector-specific options
                WmfImage wmfImage = (WmfImage)image;

                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
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

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                wmfImage.Save(outputPath, saveOptions);
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
 * 1. When you need to convert legacy WMF vector graphics to modern SVG format while preserving visual appearance.
 * 2. When you want to add a uniform background color tint to a WMF before embedding it in web pages.
 * 3. When you must ensure text in the original WMF is rendered as shapes in the SVG for consistent font rendering across browsers.
 * 4. When automating batch processing of WMF files to generate SVG assets with a specific color theme in a C# application.
 * 5. When integrating Aspose.Imaging into a .NET workflow to transform vector drawings into scalable SVGs with custom background styling.
 */
