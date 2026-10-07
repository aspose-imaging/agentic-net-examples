// HOW-TO: Apply Emboss Filter to JPEG and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\embossed.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                raster.Filter(raster.Bounds, filterOptions);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to give a JPEG photograph a raised‑relief look and store the result as a lossless TIFF for archival purposes.
 * 2. When a web service must generate embossed thumbnails from user‑uploaded JPEGs before saving them in a TIFF‑based document repository.
 * 3. When an automated batch job applies a 3×3 convolution kernel to convert color images into embossed versions for printing on high‑resolution TIFF media.
 * 4. When a desktop application requires applying a custom emboss filter to an image and then exporting it to TIFF to maintain compatibility with legacy imaging systems.
 * 5. When you want to preprocess scanned JPEG images with an emboss effect to enhance edge detection before further analysis in a TIFF workflow.
 */
