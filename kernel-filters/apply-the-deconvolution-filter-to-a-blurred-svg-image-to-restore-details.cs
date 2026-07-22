using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\blurred.svg";
        string outputPath = @"C:\Images\restored.png";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output directory
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options to convert SVG to raster format
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Configure PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG into a memory stream
                using (var rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0; // Reset stream for reading

                    // Load the rasterized image as a RasterImage
                    using (Image rasterImageBase = Image.Load(rasterStream))
                    {
                        var rasterImage = (RasterImage)rasterImageBase;

                        // Apply a Gauss-Wiener deconvolution filter to restore details
                        // Parameters: radius = 5, sigma = 1.0 (adjust as needed)
                        var deconvolutionOptions = new GaussWienerFilterOptions(5, 1.0);
                        rasterImage.Filter(rasterImage.Bounds, deconvolutionOptions);

                        // Save the processed image
                        rasterImage.Save(outputPath);
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
 * 1. When a web application needs to convert user‑uploaded blurred SVG logos into sharp PNG thumbnails for display on high‑resolution screens.
 * 2. When an e‑commerce platform must restore details in scanned product diagrams saved as SVG before embedding them in PDF catalogs.
 * 3. When a digital archiving system processes old vector illustrations that have become blurry after compression and requires a deconvolution filter to improve readability.
 * 4. When a mobile app generates on‑the‑fly PNG previews from SVG icons and wants to enhance them with a Gauss‑Wiener deconvolution to compensate for rendering artifacts.
 * 5. When a scientific reporting tool imports blurred SVG charts and applies Aspose.Imaging’s deconvolution filter to produce clear raster images for publication‑quality PDFs.
 */