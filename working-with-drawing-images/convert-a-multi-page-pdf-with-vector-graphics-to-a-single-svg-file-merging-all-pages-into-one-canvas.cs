// HOW-TO: Merge Multi‑Page PDF Vector Graphics Into One SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.pdf";
        string outputPath = @"C:\Temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PDF (vector multipage image)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to vector multipage image to access pages
                var vectorMultiPage = image as VectorMultipageImage;
                if (vectorMultiPage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a vector multipage image.");
                    return;
                }

                // Determine canvas size: width = max page width, height = sum of page heights
                int canvasWidth = 0;
                int canvasHeight = 0;
                foreach (var page in vectorMultiPage.Pages)
                {
                    canvasWidth = Math.Max(canvasWidth, page.Width);
                    canvasHeight += page.Height;
                }

                // Create an SVG canvas
                var graphics = new SvgGraphics2D(canvasWidth, canvasHeight, 96);

                int yOffset = 0;
                foreach (var page in vectorMultiPage.Pages)
                {
                    // Rasterize the current page to a PNG in memory
                    using (var ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        page.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load the rasterized page
                        using (RasterImage rasterPage = (RasterImage)Image.Load(ms))
                        {
                            // Draw the raster page onto the SVG canvas at the current offset
                            graphics.DrawImage(rasterPage, new Point(0, yOffset), new Size(page.Width, page.Height));
                        }
                    }

                    yOffset += page.Height;
                }

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the merged SVG
                    svgImage.Save(outputPath);
                }
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
 * 1. When you need to embed an entire multi‑page PDF brochure as a single scalable SVG graphic on a website.
 * 2. When you want to combine several PDF report pages into one SVG file for high‑quality printing or vector editing.
 * 3. When you must convert PDF vector drawings into a single SVG canvas while keeping them resolution‑independent in a C# application.
 * 4. When you are developing a document viewer that displays all PDF pages together as one SVG element.
 * 5. When you require automated batch processing to merge PDF pages into a single SVG for downstream workflows.
 */
