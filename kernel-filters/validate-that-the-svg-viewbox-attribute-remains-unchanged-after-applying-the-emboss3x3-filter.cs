using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string pngPath = "output.png";
            string filteredPath = "filtered.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(filteredPath));

            // Extract original viewBox attribute
            string originalContent = File.ReadAllText(inputPath);
            string originalViewBox = ExtractViewBox(originalContent);

            // Load SVG and rasterize to PNG
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
                };
                svgImage.Save(pngPath, pngOptions);
            }

            // Load raster PNG, apply Emboss3x3 filter, and save filtered image
            using (Image img = Image.Load(pngPath))
            {
                RasterImage raster = (RasterImage)img;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(filteredPath);
            }

            // Re-extract viewBox after processing (should be unchanged)
            string afterContent = File.ReadAllText(inputPath);
            string afterViewBox = ExtractViewBox(afterContent);

            // Validate viewBox integrity
            if (originalViewBox == afterViewBox)
            {
                Console.WriteLine("ViewBox attribute unchanged after applying Emboss3x3 filter.");
            }
            else
            {
                Console.WriteLine("ViewBox attribute was modified.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple helper to extract the viewBox attribute value from SVG content
    static string ExtractViewBox(string svgContent)
    {
        const string marker = "viewBox=\"";
        int start = svgContent.IndexOf(marker, StringComparison.Ordinal);
        if (start < 0) return string.Empty;
        start += marker.Length;
        int end = svgContent.IndexOf('"', start);
        if (end < 0) return string.Empty;
        return svgContent.Substring(start, end - start);
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web designer needs to generate embossed PNG thumbnails from SVG icons while guaranteeing that the original SVG viewBox (which defines the icon’s coordinate system) stays unchanged for responsive scaling.
 * 2. When an e‑commerce platform converts product vector illustrations (SVG) to raster images with an emboss effect and must verify that the viewBox attribute is preserved so the images render correctly on different device resolutions.
 * 3. When a GIS application processes map symbols stored as SVG files, applies a 3×3 emboss filter for visual emphasis, and checks the viewBox to ensure the symbols retain their geographic alignment after rasterization.
 * 4. When a publishing workflow automates the creation of embossed PNG assets from SVG artwork for print, and the developer needs to confirm that the viewBox remains intact to maintain the intended layout dimensions.
 * 5. When a mobile app generates embossed PNG assets from SVG UI elements on the fly and validates the viewBox to avoid distortion when the assets are later scaled or animated.
 */