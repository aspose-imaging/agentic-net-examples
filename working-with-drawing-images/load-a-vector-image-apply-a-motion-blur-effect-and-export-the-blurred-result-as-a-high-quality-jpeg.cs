using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (SVG)
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size,
                    BackgroundColor = Color.White
                };

                // Prepare PNG options to rasterize the SVG into a memory stream
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImg;

                        // Apply motion blur (motion wiener) filter
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

                        // Configure high-quality JPEG options
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 100
                        };

                        // Save the blurred image as JPEG
                        rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a web designer wants to convert scalable SVG icons into high‑resolution JPEG thumbnails with a motion‑blur effect for a dynamic gallery.
 * 2. When an e‑commerce platform needs to generate product preview images from vector logos, apply a motion blur to simulate movement, and store them as JPEGs for faster page loads.
 * 3. When a marketing automation tool creates animated email banners by rasterizing SVG assets, adding a motion‑blur filter, and exporting the result as a high‑quality JPEG for email clients.
 * 4. When a desktop publishing application processes user‑uploaded SVG illustrations, applies a motion‑blur effect to achieve a stylized look, and saves the output as JPEG for printing or web distribution.
 * 5. When a game development pipeline converts vector UI elements into blurred JPEG textures to reduce memory usage while preserving visual effects in C# using Aspose.Imaging.
 */