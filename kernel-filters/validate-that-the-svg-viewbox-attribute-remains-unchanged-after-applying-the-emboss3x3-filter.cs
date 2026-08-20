// HOW-TO: Check SVG ViewBox Stays Unchanged After Applying Emboss Filter In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";
            string tempPngPath = "temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read original viewBox
            string originalContent = File.ReadAllText(inputPath);
            string originalViewBox = "";
            int vbIdx = originalContent.IndexOf("viewBox=\"", StringComparison.Ordinal);
            if (vbIdx >= 0)
            {
                int start = vbIdx + "viewBox=\"".Length;
                int end = originalContent.IndexOf("\"", start, StringComparison.Ordinal);
                if (end > start)
                {
                    originalViewBox = originalContent.Substring(start, end - start);
                }
            }

            // Load SVG and rasterize to PNG
            using (Image img = Image.Load(inputPath))
            {
                SvgImage svgImg = (SvgImage)img;
                SvgRasterizationOptions rasterOpts = new SvgRasterizationOptions();
                rasterOpts.PageSize = svgImg.Size;
                PngOptions pngOpts = new PngOptions();
                pngOpts.VectorRasterizationOptions = rasterOpts;
                svgImg.Save(tempPngPath, pngOpts);
            }

            // Load raster PNG and apply Emboss3x3 filter
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                raster.Save(tempPngPath);
            }

            // Copy original SVG to output (unchanged)
            File.Copy(inputPath, outputPath, true);

            // Read viewBox from output SVG
            string outputContent = File.ReadAllText(outputPath);
            string outputViewBox = "";
            int vbIdxOut = outputContent.IndexOf("viewBox=\"", StringComparison.Ordinal);
            if (vbIdxOut >= 0)
            {
                int startOut = vbIdxOut + "viewBox=\"".Length;
                int endOut = outputContent.IndexOf("\"", startOut, StringComparison.Ordinal);
                if (endOut > startOut)
                {
                    outputViewBox = outputContent.Substring(startOut, endOut - startOut);
                }
            }

            // Validate viewBox unchanged
            if (originalViewBox == outputViewBox)
            {
                Console.WriteLine("ViewBox unchanged after applying Emboss3x3 filter.");
            }
            else
            {
                Console.WriteLine("ViewBox changed after applying Emboss3x3 filter.");
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
 * 1. When you need to ensure that applying an emboss convolution filter to an SVG‑derived PNG does not alter the original SVG’s viewBox coordinates.
 * 2. When you want to programmatically verify that vector graphics retain their scaling and positioning metadata after image‑processing operations in a .NET workflow.
 * 3. When integrating Aspose.Imaging into a pipeline that rasterizes SVG files, applies visual effects, and must preserve the SVG’s viewport for later re‑export or editing.
 * 4. When testing automated image‑conversion scripts to confirm that decorative filters like Emboss3x3 do not corrupt SVG layout information required for responsive web design.
 * 5. When building a C# utility that compares pre‑ and post‑filter SVG attributes to guarantee consistent rendering across different devices and browsers.
 */
