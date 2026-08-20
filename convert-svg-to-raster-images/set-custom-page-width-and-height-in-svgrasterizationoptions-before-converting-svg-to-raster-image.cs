// HOW-TO: Set Custom Width and Height for SVG to PNG Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with custom page size
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();

                // Set custom width and height (in pixels)
                rasterOptions.PageWidth = 800;   // custom width
                rasterOptions.PageHeight = 600;  // custom height

                // Optional: set background color, smoothing, etc.
                rasterOptions.BackgroundColor = Aspose.Imaging.Color.White;
                rasterOptions.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;
                rasterOptions.TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias;

                // Prepare PNG save options and attach rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate PNG thumbnails of SVG logos at a specific 800×600 pixel size for a web gallery.
 * 2. When a desktop application must render SVG diagrams into fixed‑size PNG files to fit into a predefined UI panel.
 * 3. When preparing print‑ready images, you set exact pixel dimensions to ensure the SVG artwork scales correctly before saving as PNG.
 * 4. When creating batch reports that embed SVG charts as PNGs with uniform dimensions for consistent layout across pages.
 * 5. When exporting SVG assets for mobile apps, you rasterize them to a specific width and height to meet device resolution requirements.
 */
