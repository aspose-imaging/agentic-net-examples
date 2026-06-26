using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG vector image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for BMP output
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = vectorImage.Size
                };

                // Create BMP options with the rasterization settings
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize the vector image into a memory stream
                using (var ms = new MemoryStream())
                {
                    vectorImage.Save(ms, bmpOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageWrapper = Image.Load(ms))
                    {
                        var rasterImage = (RasterImage)rasterImageWrapper;

                        // Apply median filter with kernel size 5
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as BMP
                        rasterImage.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to remove speckle noise from scanned ODG drawings before exporting them as BMP files for legacy Windows applications.
 * 2. When a workflow requires converting ODG vector graphics to a raster BMP format while smoothing out pixelated artifacts caused by low‑resolution rasterization.
 * 3. When an image‑processing pipeline must prepare ODG‑based floor plans for OCR or pattern‑recognition engines that expect a clean BMP input.
 * 4. When a desktop publishing system has to generate BMP thumbnails of ODG illustrations and wants to apply a median filter to preserve edge detail while reducing color noise.
 * 5. When a batch conversion tool must ensure that ODG diagrams retain visual quality after being rasterized to BMP for use in embedded systems with limited display capabilities.
 */