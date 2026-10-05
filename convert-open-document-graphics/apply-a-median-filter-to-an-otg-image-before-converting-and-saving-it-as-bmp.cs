// HOW-TO: Apply Median Filter to OTG Image and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.bmp");

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    vectorImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(memoryStream))
                    {
                        var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                        raster.Filter(raster.Bounds, medianOptions);

                        var bmpOptions = new BmpOptions();
                        raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to reduce speckle noise in a vector‑based OTG diagram before converting it to a BMP for legacy Windows applications.
 * 2. When an automated pipeline must rasterize OTG graphics, apply a median filter for smoothing, and store the result as BMP for printing on industrial equipment.
 * 3. When a desktop utility processes user‑uploaded OTG files, cleans them with a median filter, and saves them as BMP to maintain compatibility with older image viewers.
 * 4. When a batch job converts a collection of OTG assets to BMP while applying noise reduction to improve OCR accuracy on the resulting bitmaps.
 * 5. When a C# service integrates Aspose.Imaging to preprocess OTG images with a median filter before delivering BMP files to a third‑party reporting system.
 */
