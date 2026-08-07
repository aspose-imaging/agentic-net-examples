using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image from file stream
            using (FileStream svgStream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(svgStream))
            {
                // Set up rasterization options for SVG to raster conversion
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

                // Set up PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG into a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Apply Gaussian blur filter
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Apply a sharpen filter (used here as a simple edge‑detection kernel)
                        rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

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
 * 1. When a web developer wants to generate a blurred background thumbnail from an SVG logo and then highlight its edges for a hover effect in a responsive UI.
 * 2. When an e‑learning platform needs to preprocess SVG diagrams by softening details with Gaussian blur and then extracting outlines to create printable PNG worksheets.
 * 3. When a GIS application must convert vector map symbols to raster PNG tiles, applying blur to reduce visual clutter and edge detection to emphasize boundaries for better map readability.
 * 4. When a marketing automation tool automatically creates stylized product icons by blurring the original SVG artwork and then applying a custom edge‑detection kernel to produce a sharp, high‑contrast PNG for email campaigns.
 * 5. When a medical imaging system imports SVG anatomical illustrations, applies blur to simulate depth of field and edge detection to accentuate structures before embedding the result in a patient report PDF.
 */