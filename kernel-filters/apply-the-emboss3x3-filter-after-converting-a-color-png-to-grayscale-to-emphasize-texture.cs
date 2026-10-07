// HOW-TO: Apply Emboss 3x3 Filter to Grayscale PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.png");
            string outputPath = Path.Combine("Output", "embossed.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterCachedImage rci = (RasterCachedImage)image;
                if (!rci.IsCached) rci.CacheData();
                rci.Grayscale();

                rci.Filter(rci.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                rci.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight surface texture in a PNG by converting it to grayscale and applying an Aspose.Imaging emboss filter for a stylized visual effect.
 * 2. When preparing product photos for a catalog where a subtle 3‑D relief is required, and you want to automate the conversion and embossing of PNG images with C#.
 * 3. When creating game assets that require a grayscale, embossed version of an image to serve as a height map, using Aspose.Imaging’s ConvolutionFilter in .NET.
 * 4. When generating printable artwork where emphasizing edges and texture improves readability in monochrome prints, and you need a C# routine to grayscale and emboss PNG files.
 * 5. When automating a batch process that converts color PNGs to grayscale and adds an emboss effect for a consistent branding style across a website, leveraging Aspose.Imaging for .NET.
 */
