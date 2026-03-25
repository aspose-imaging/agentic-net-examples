using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input PNG path
        string inputPath = "sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply sharpening filter (kernel size 5, sigma 4.0)
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as PDF into a MemoryStream
            using (MemoryStream pdfStream = new MemoryStream())
            {
                image.Save(pdfStream, new PdfOptions());

                // Example: output the size of the generated PDF
                Console.WriteLine($"PDF stream length: {pdfStream.Length} bytes");
            }
        }
    }
}