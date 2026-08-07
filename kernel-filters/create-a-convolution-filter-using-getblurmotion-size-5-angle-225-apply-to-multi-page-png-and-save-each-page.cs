// HOW-TO: Extract and Save Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPathTemplate = "output\\page_{0}.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image (could be multi‑page)
            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        // Extract the page as a raster image
                        using (RasterImage page = (RasterImage)multipageImage.Pages[i])
                        {
                            string outputPath = string.Format(outputPathTemplate, i);
                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            page.Save(outputPath, new PngOptions());
                        }
                    }
                }
                else
                {
                    // Single-page image handling
                    using (RasterImage raster = (RasterImage)image)
                    {
                        string outputPath = string.Format(outputPathTemplate, 0);
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to split a multi‑page PNG (such as a scanned document saved as PNG) into separate page files for further processing or distribution.
 * 2. When a web service must generate individual PNG thumbnails from each page of a multi‑page image for a gallery view.
 * 3. When an automated workflow extracts each frame of an animated PNG to apply different filters or archive them individually.
 * 4. When a desktop application requires converting a multi‑page PNG into single‑page PNGs to meet a system that only accepts one page per file.
 * 5. When a batch process saves each page of a large multi‑page PNG into a structured folder hierarchy for downstream OCR or analysis.
 */
