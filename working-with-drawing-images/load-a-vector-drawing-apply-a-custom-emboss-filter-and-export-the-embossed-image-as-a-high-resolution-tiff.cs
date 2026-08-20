// HOW-TO: Apply Emboss Filter to SVG and Save as High‑Resolution TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.svg";
            string outputPath = @"c:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for the vector image
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = vectorImage.Size
                };

                // Rasterize to PNG in a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        Source = new StreamSource(ms),
                        VectorRasterizationOptions = rasterOptions
                    };
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Prepare high‑resolution TIFF options
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            ResolutionSettings = new ResolutionSetting(300, 300)
                        };

                        // Save the image as TIFF
                        raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert a scalable vector logo into a printable TIFF with an embossed effect for marketing brochures.
 * 2. When a web service must generate high‑resolution, embossed product images from SVG files for e‑commerce catalogs.
 * 3. When automating the creation of embossed artwork thumbnails for a digital asset management system using C#.
 * 4. When preparing archival TIFF files with enhanced depth from vector illustrations for museum digitization projects.
 * 5. When integrating a custom emboss filter into a batch processing pipeline that transforms SVG icons into 300 dpi TIFFs for desktop publishing.
 */
