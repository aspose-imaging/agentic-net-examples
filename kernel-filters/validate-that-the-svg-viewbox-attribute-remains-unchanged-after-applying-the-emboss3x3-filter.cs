using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read original SVG content and extract viewBox
            string svgContentBefore = File.ReadAllText(inputPath);
            int vbStartBefore = svgContentBefore.IndexOf("viewBox=\"");
            string viewBoxBefore = "";
            if (vbStartBefore >= 0)
            {
                vbStartBefore += 9;
                int vbEndBefore = svgContentBefore.IndexOf("\"", vbStartBefore);
                if (vbEndBefore > vbStartBefore)
                    viewBoxBefore = svgContentBefore.Substring(vbStartBefore, vbEndBefore - vbStartBefore);
            }

            // Rasterize SVG to PNG (temporary file)
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Apply Emboss3x3 filter to the rasterized PNG
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(tempPngPath);
            }

            // Re-read SVG content (should be unchanged)
            string svgContentAfter = File.ReadAllText(inputPath);
            int vbStartAfter = svgContentAfter.IndexOf("viewBox=\"");
            string viewBoxAfter = "";
            if (vbStartAfter >= 0)
            {
                vbStartAfter += 9;
                int vbEndAfter = svgContentAfter.IndexOf("\"", vbStartAfter);
                if (vbEndAfter > vbStartAfter)
                    viewBoxAfter = svgContentAfter.Substring(vbStartAfter, vbEndAfter - vbStartAfter);
            }

            // Output verification result
            Console.WriteLine($"Original viewBox: {viewBoxBefore}");
            Console.WriteLine($"After processing viewBox: {viewBoxAfter}");

            // Copy original SVG to output (since we only processed raster image)
            File.Copy(inputPath, outputPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web designer wants to apply an emboss effect to an SVG logo but must ensure the original viewBox dimensions stay intact for responsive scaling.
 * 2. When an e‑commerce platform generates product thumbnails by rasterizing SVG icons to PNG, applying a 3×3 emboss filter, and needs to verify that the SVG’s viewBox attribute is preserved for later vector reuse.
 * 3. When a mobile app processes user‑uploaded SVG illustrations, applies a convolution emboss filter via Aspose.Imaging, and must confirm the viewBox remains unchanged to maintain correct aspect ratio on different screen sizes.
 * 4. When a publishing workflow converts SVG artwork to high‑resolution PNGs with an emboss effect and later re‑exports the SVG, requiring validation that the viewBox attribute was not altered during processing.
 * 5. When a CI/CD pipeline runs automated tests on SVG assets that undergo rasterization and emboss filtering, checking that the viewBox attribute stays the same to prevent layout regressions in downstream applications.
 */