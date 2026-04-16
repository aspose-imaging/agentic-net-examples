using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path (relative)
        string inputPath = "Input/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply sharpening filter (kernel size 5, sigma 4.0)
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image to a MemoryStream as PDF
            using (MemoryStream pdfStream = new MemoryStream())
            {
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(pdfStream, pdfOptions);

                // Example output: report the size of the generated PDF
                Console.WriteLine($"PDF saved to memory stream, size: {pdfStream.Length} bytes");
            }
        }
    }
}