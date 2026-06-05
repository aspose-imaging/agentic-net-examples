using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/softened.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the entire image
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Prepare PNG export options with text rendering hint
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save the blurred image as PNG
                raster.Save(outputPath, pngOptions);
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
 * 1. When a web designer needs to generate a softened PNG thumbnail from a layered PSD file to improve page load speed while preserving text clarity.
 * 2. When an e‑commerce platform automatically blurs product background PSD images, applies a specific text rendering hint for overlay labels, and saves the result as PNG for web display.
 * 3. When a digital publishing workflow converts high‑resolution PSD artwork into PNG assets with a Gaussian blur effect while ensuring crisp vector text using the SingleBitPerPixel rendering hint.
 * 4. When a mobile app creates stylized PNG icons from original PSD designs by applying a blur filter and configuring text rendering to keep text legible on low‑resolution screens.
 * 5. When an automated reporting system processes PSD charts, softens visual elements with a Gaussian blur, sets the appropriate text rendering hint, and exports the final image as PNG for inclusion in PDF reports.
 */