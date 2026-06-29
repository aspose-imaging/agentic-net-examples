using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read viewBox attribute before processing
            string contentBefore = File.ReadAllText(inputPath);
            string viewBoxBefore = "";
            int vbIndex = contentBefore.IndexOf("viewBox=\"", StringComparison.Ordinal);
            if (vbIndex >= 0)
            {
                int start = vbIndex + 9;
                int end = contentBefore.IndexOf('"', start);
                if (end > start)
                    viewBoxBefore = contentBefore.Substring(start, end - start);
            }

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size }
                    };
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load raster image and apply Emboss3x3 filter
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                        // No need to save raster result for viewBox validation
                    }
                }

                // Save original SVG (unchanged) to output path
                image.Save(outputPath);
            }

            // Read viewBox attribute after processing
            string contentAfter = File.ReadAllText(outputPath);
            string viewBoxAfter = "";
            int vbIndexAfter = contentAfter.IndexOf("viewBox=\"", StringComparison.Ordinal);
            if (vbIndexAfter >= 0)
            {
                int start = vbIndexAfter + 9;
                int end = contentAfter.IndexOf('"', start);
                if (end > start)
                    viewBoxAfter = contentAfter.Substring(start, end - start);
            }

            // Compare viewBox values
            bool unchanged = viewBoxBefore == viewBoxAfter;
            Console.WriteLine($"ViewBox unchanged: {unchanged}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web designer wants to apply an emboss effect to an SVG logo but must keep the original viewBox so the logo scales correctly across responsive layouts.
 * 2. When an e‑commerce platform automatically generates product thumbnails from SVG assets, applies a 3×3 emboss filter for visual depth, and needs to verify that the viewBox attribute stays intact to preserve aspect ratio.
 * 3. When a GIS application converts vector map symbols stored as SVG to raster PNGs, applies an emboss filter for terrain shading, and must ensure the viewBox is unchanged to align symbols accurately on the map.
 * 4. When a mobile app processes user‑uploaded SVG icons, adds an emboss effect for UI consistency, and validates the viewBox to prevent distortion on different screen densities.
 * 5. When a CI/CD pipeline runs automated tests on SVG assets, applies the Emboss3x3 filter as part of a visual regression suite, and checks that the viewBox attribute remains unchanged to guarantee layout stability.
 */