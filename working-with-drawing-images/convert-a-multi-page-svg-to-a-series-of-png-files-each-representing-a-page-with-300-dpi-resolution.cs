// HOW-TO: Convert Multi‑Page SVG to High‑Resolution PNG Pages in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input SVG path
            string inputPath = "input.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for PNG pages
            string outputDir = "output";

            // Load the SVG (or any vector) image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare common PNG options (300 DPI)
                PngOptions pngOptions = new PngOptions();
                pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                // Set vector rasterization options if the source is a vector image
                if (image is VectorImage)
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;
                }

                // Attempt to treat the image as a multipage vector image
                IMultipageImage multipage = image as IMultipageImage;

                if (multipage != null && multipage.PageCount > 0)
                {
                    // Export each page to a separate PNG file
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set MultiPageOptions to export only the current page
                        pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                        // Save the current page as PNG
                        image.Save(outputPath, pngOptions);
                    }
                }
                else
                {
                    // Single-page SVG case
                    string outputPath = Path.Combine(outputDir, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    // No MultiPageOptions needed for single page
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate printable PNG assets from a multi‑page SVG diagram for a catalog, preserving 300 DPI quality.
 * 2. When an application must split a vector‑based SVG brochure into separate high‑resolution PNG files for web preview thumbnails.
 * 3. When a reporting tool exports charts as a multi‑page SVG and you require each page as a PNG image for inclusion in PDF reports.
 * 4. When automating a build pipeline that converts design assets stored as SVG pages into PNGs for mobile app resources at a specific DPI.
 * 5. When a legacy system only accepts PNG images and you must rasterize each page of a multi‑page SVG invoice at 300 DPI for archival.
 */
