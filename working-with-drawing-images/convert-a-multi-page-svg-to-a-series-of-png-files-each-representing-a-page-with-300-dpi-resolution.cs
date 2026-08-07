using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input SVG file (multi‑page)
            string inputPath = "Input/multipage.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for PNG pages
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image supports multiple pages
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input file is not a multipage vector image.");
                    return;
                }

                int pageCount = multipage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        // Set 300 DPI resolution
                        pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                        // Configure rasterization of the vector page
                        pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageSize = image.Size
                        };

                        // Export only the current page
                        pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                        // Save the page as PNG
                        image.Save(outputPath, pngOptions);
                    }
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
 * 1. When a developer needs to generate high‑resolution printable PNG assets from a multi‑page SVG brochure for a marketing campaign, they can use this code to rasterize each page at 300 DPI.
 * 2. When an e‑learning platform must convert multi‑page SVG lesson diagrams into separate PNG slides for offline viewing on tablets, this snippet automates the page‑by‑page export with proper resolution.
 * 3. When a document management system imports vector‑based invoices stored as multi‑page SVG files and must store them as PNG thumbnails for quick preview, the code provides a reliable C# solution.
 * 4. When a web service creates downloadable PNG versions of each page of a multi‑page SVG technical drawing to meet client specifications for 300 DPI raster images, this example shows how to perform the conversion with Aspose.Imaging.
 * 5. When a CI/CD pipeline needs to validate the visual fidelity of each page in a multi‑page SVG design by comparing generated 300 DPI PNGs against baseline images, the code can be integrated into automated tests.
 */