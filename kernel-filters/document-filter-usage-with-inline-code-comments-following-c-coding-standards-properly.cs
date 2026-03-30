using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

namespace AsposeImagingDemo
{
    /// <summary>
    /// Demonstrates applying a sharpen filter to a PNG image using Aspose.Imaging.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.SharpenFilter.png";

            // Verify that the input file exists; report error and exit if not.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists before saving.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image from disk.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to gain access to the Filter method.
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter with a kernel size of 5 and sigma of 4.0
                // to the entire image bounds.
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new SharpenFilterOptions(5, 4.0));

                // Save the processed image to the specified output path.
                rasterImage.Save(outputPath);
            }
        }
    }
}