using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = "C:\\Images\\Input";
            string outputFolder = "C:\\Images\\Output";

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputFolder);
            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x1024
                    image.Resize(1024, 1024);

                    // Apply median filter if the image is raster
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));
                    }

                    // Build output path with .svg extension
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".svg");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare SVG save options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

                    // Save the processed image as SVG
                    image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to batch‑process a folder of JPEG or PNG photos, resize each to a uniform 1024 × 1024 pixel canvas, reduce noise with a median filter, and export the results as scalable SVG files for web display.
 * 2. When an e‑commerce platform must convert product thumbnail images into vector‑compatible SVGs while preserving image dimensions and cleaning up artifacts before uploading to a CDN.
 * 3. When a digital archiving system requires automated conversion of scanned raster documents into SVG format, standardizing size and applying a median filter to improve readability for OCR pipelines.
 * 4. When a mobile app backend has to prepare user‑uploaded screenshots for responsive UI components by resizing them, smoothing pixel noise, and delivering them as lightweight SVG assets.
 * 5. When a GIS application needs to transform a collection of raster map tiles into vector SVG layers, ensuring each tile is resized to 1024 × 1024 and denoised with a median filter for consistent rendering.
 */