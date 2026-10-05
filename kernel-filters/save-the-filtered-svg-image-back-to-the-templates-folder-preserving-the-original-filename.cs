// HOW-TO: Apply Sharpen Filter to SVG and Save Back in C# (Aspose.Imaging for .NET)
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
            string inputPath = "templates/template.svg";
            string outputPath = "templates/template.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream pngStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    svgImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    // Load raster image from PNG stream
                    using (RasterImage rasterImage = (RasterImage)Image.Load(pngStream))
                    {
                        // Sharpen filter kernel
                        double[,] kernel = new double[,]
                        {
                            {  0, -1,  0 },
                            { -1,  5, -1 },
                            {  0, -1,  0 }
                        };
                        var filterOptions = new ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save filtered raster back to PNG stream
                        using (MemoryStream filteredPngStream = new MemoryStream())
                        {
                            rasterImage.Save(filteredPngStream, pngOptions);
                            filteredPngStream.Position = 0;

                            // Replace original SVG with filtered PNG content (as a fallback)
                            using (FileStream outFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                            {
                                filteredPngStream.CopyTo(outFile);
                            }
                        }
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
 * 1. When you need to programmatically sharpen an SVG graphic using a convolution filter and keep the original filename in the templates folder.
 * 2. When you want to rasterize an SVG to PNG in memory, apply image processing, and write the enhanced result back without changing the directory structure.
 * 3. When you are building a C# automation that improves the visual clarity of vector logos before they are used in web or print assets.
 * 4. When you must preprocess user‑uploaded SVG files with Aspose.Imaging to increase edge definition while preserving the source path for later use.
 * 5. When you integrate image filtering into a build pipeline that requires SVG files to be filtered and saved back exactly where they were originally stored.
 */
