using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] originalBytes = File.ReadAllBytes(inputPath);

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                var vectorRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                pngOptions.VectorRasterizationOptions = vectorRasterOptions;

                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        var filterOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);
                        raster.Filter(raster.Bounds, filterOptions);
                        raster.Save(outputPath);
                    }
                }
            }

            byte[] afterBytes = File.ReadAllBytes(inputPath);
            bool cssUnchanged = originalBytes.SequenceEqual(afterBytes);
            Console.WriteLine($"Embedded CSS unchanged: {cssUnchanged}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application converts user‑uploaded SVG icons to PNG thumbnails with an emboss filter, the developer can use this code to ensure the original SVG’s embedded CSS styles remain unchanged after processing.
 * 2. When an automated build pipeline generates high‑resolution PNG assets from SVG logos for print, the code helps verify that applying a convolution kernel does not corrupt the SVG’s style definitions used later for re‑rasterization.
 * 3. When a digital asset management system applies visual effects to SVG graphics before storing them as PNG, the snippet validates that the CSS styling embedded in the SVG file is preserved, preventing layout inconsistencies.
 * 4. When a C# desktop tool batch‑processes SVG diagrams into PNGs with Aspose.Imaging’s Emboss3x3 filter, the developer can check that the CSS rules inside the original SVG files are untouched, ensuring downstream SVG edits still work.
 * 5. When a CI/CD test suite validates image‑processing code that rasterizes SVG to PNG and applies a convolution filter, this example confirms that the file’s byte‑level CSS content is identical before and after the operation.
 */