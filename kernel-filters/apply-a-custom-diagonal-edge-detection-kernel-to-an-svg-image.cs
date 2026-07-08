using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                // Prepare PNG options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Define a custom diagonal edge‑detection kernel
                        double[,] kernel = new double[,]
                        {
                            { -1, 0, 1 },
                            {  0, 0, 0 },
                            {  1, 0,-1 }
                        };

                        // Apply the convolution filter with the custom kernel
                        rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

                        // Save the filtered raster image to the output path
                        rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert vector graphics (SVG) into raster PNG files while emphasizing diagonal edges for technical documentation or UI icons.
 * 2. When an e‑learning platform wants to automatically generate stylized diagram thumbnails that highlight diagonal lines in flowcharts using a custom edge‑detection filter in C#.
 * 3. When a GIS application processes SVG map overlays and applies a diagonal edge‑detection kernel to accentuate road intersections before exporting to PNG for web tiles.
 * 4. When a marketing automation tool creates product mockups by rasterizing SVG logos and applying a diagonal edge filter to produce a sketch‑like effect for social media posts.
 * 5. When a quality‑control system inspects scanned engineering drawings by converting SVG schematics to PNG and using a custom diagonal edge‑detection kernel to detect misaligned components.
 */