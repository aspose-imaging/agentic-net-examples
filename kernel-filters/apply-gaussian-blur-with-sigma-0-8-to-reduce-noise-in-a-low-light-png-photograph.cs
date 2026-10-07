// HOW-TO: Apply Gaussian Blur With Sigma 0.8 To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(1, 0.8);
                raster.Filter(raster.Bounds, filterOptions);

                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);
                raster.Save(outputPath, options);
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
 * 1. When you need to reduce noise in a low‑light PNG photograph before publishing it on a website.
 * 2. When preprocessing images for OCR to remove grain that interferes with text extraction.
 * 3. When cleaning up dimly lit product photos so they appear clearer in e‑commerce listings.
 * 4. When smoothing sensor noise in surveillance PNG frames prior to long‑term storage.
 * 5. When applying a subtle blur to game asset PNGs captured in dark environments to improve visual consistency.
 */
