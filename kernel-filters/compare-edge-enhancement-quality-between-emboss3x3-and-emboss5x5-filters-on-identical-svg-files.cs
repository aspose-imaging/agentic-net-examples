using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG path
            string inputPath = @"C:\Images\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output paths for the two filtered images
            string outputPath3x3 = @"C:\Images\sample_Emboss3x3.png";
            string outputPath5x5 = @"C:\Images\sample_Emboss5x5.png";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3x3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5x5));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize the SVG to a raster image (default size)
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    // Apply 3x3 emboss filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save result of 3x3 emboss
                    rasterImage.Save(outputPath3x3);
                }

                // Reload the original SVG for the second filter to avoid cumulative effects
                using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
                {
                    // Apply 5x5 emboss filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                    // Save result of 5x5 emboss
                    rasterImage.Save(outputPath5x5);
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
 * 1. When a web designer wants to preview how different emboss filters affect the visual depth of SVG icons before publishing them as PNG assets.
 * 2. When a GIS analyst needs to evaluate edge enhancement on vector map symbols to choose the optimal filter for printed map legends.
 * 3. When a game developer is converting SVG UI elements to raster textures and must compare 3x3 versus 5x5 emboss filters to maintain consistent shading across devices.
 * 4. When a digital archivist processes SVG illustrations for an online museum catalog and wants to determine which emboss kernel preserves fine line details best.
 * 5. When a marketing team creates product brochures and requires side‑by‑side PNG outputs to decide whether the 3x3 or 5x5 emboss filter yields a more striking embossed effect for promotional graphics.
 */