using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (PngImage raster = (PngImage)Image.Load(ms))
                    {
                        raster.Grayscale();
                        raster.Save(outputPath);
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
 * 1. When a web application needs to generate black‑and‑white thumbnails from user‑uploaded SVG icons for a product catalog, a developer can load the SVG, rasterize it to PNG and apply the grayscale method to ensure a consistent visual style.
 * 2. When an automated reporting tool must embed grayscale versions of vector diagrams (SVG) into PDF or email attachments, the code converts the SVG to a PNG image and removes color using Aspose.Imaging’s Grayscale function.
 * 3. When a mobile‑app server prepares low‑bandwidth preview images of SVG maps for older devices, the developer can rasterize the SVG to PNG and apply a grayscale color matrix to reduce file size while preserving detail.
 * 4. When a content‑management system enforces accessibility guidelines by providing monochrome alternatives for SVG logos, the developer uses this code to load the SVG, rasterize it, convert it to a grayscale PNG, and store it for compliance.
 * 5. When a batch‑processing pipeline needs to convert a collection of SVG assets into grayscale PNG assets for printing on monochrome printers, the developer employs Aspose.Imaging to load each SVG, rasterize with page size, apply Grayscale, and save the result.
 */