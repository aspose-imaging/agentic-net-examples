using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\input.pdf";
        string outputPath = @"C:\Data\output.svg";

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
                var multipage = image as Aspose.Imaging.IMultipageImage;
                if (multipage == null || multipage.Pages == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The input file does not contain multiple pages.");
                    return;
                }

                // Determine combined canvas size (stack pages vertically)
                int canvasWidth = 0;
                int canvasHeight = 0;
                foreach (var pageObj in multipage.Pages)
                {
                    var page = pageObj as Image;
                    if (page != null)
                    {
                        if (page.Width > canvasWidth)
                            canvasWidth = page.Width;
                        canvasHeight += page.Height;
                    }
                }

                // Create an SVG graphics canvas
                const int dpi = 96;
                var graphics = new SvgGraphics2D(canvasWidth, canvasHeight, dpi);

                // Render each page onto the canvas
                int currentY = 0;
                foreach (var pageObj in multipage.Pages)
                {
                    var page = pageObj as Image;
                    if (page == null) continue;

                    // Rasterize the page to PNG in memory
                    using (var ms = new MemoryStream())
                    {
                        page.Save(ms, new PngOptions());
                        ms.Position = 0;

                        // Load the rasterized page
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Draw the raster image at the current offset
                            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, currentY), new Aspose.Imaging.Size(raster.Width, raster.Height));
                        }
                    }

                    currentY += page.Height;
                }

                // Finalize SVG image and save
                using (Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = graphics.EndRecording())
                {
                    svgImage.Save(outputPath, new SvgOptions());
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
 * 1. When a developer needs to embed a multi‑page PDF brochure into a web page as a single scalable SVG graphic for responsive design.
 * 2. When an engineering application must combine several vector‑based PDF schematics into one SVG canvas for unified printing or annotation.
 * 3. When a reporting tool has to transform a paginated PDF invoice into a single SVG file to allow zoom‑able, client‑side rendering in a browser.
 * 4. When a GIS system wants to merge multiple PDF map sheets into one SVG layer to overlay with other vector data in C#.
 * 5. When an e‑learning platform requires converting a multi‑page PDF lesson into a single SVG asset to simplify asset management and reduce HTTP requests.
 */