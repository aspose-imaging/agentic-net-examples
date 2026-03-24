using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

namespace EdgeDetectionExample
{
    class Program
    {
        static void Main()
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists; report and exit if not found
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it unconditionally)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image, apply an edge‑like sharpen filter, and save the result
            using (Image image = Image.Load(inputPath))
            {
                // Cast the generic Image to a TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply a sharpen filter to the whole image (acts as an edge detector)
                tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as PNG
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
    }
}