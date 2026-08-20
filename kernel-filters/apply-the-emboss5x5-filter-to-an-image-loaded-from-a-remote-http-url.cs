// HOW-TO: Apply Emboss 5x5 Convolution Filter to JPEG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                PngOptions pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When you need to add a stylized emboss effect to a JPEG photo before converting it to a PNG for web display.
 * 2. When you want to preprocess scanned documents with a 5x5 emboss filter to enhance edge contrast prior to archival storage.
 * 3. When building a batch image pipeline that automatically applies the Aspose.Imaging Emboss5x5 filter to user‑uploaded pictures and outputs PNG thumbnails.
 * 4. When creating a C# utility that transforms product images by embossing them to highlight texture details for e‑commerce catalogs.
 * 5. When developing a desktop application that lets users apply a classic emboss effect to their pictures and save the result in lossless PNG format.
 */
