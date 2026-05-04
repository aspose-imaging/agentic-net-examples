using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string sharpenedImagePath = @"C:\Images\sample_sharpened.png";
        string pdfOutputPath = @"C:\Images\sample_sharpened.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply sharpen filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Ensure output directory exists for the sharpened image
                Directory.CreateDirectory(Path.GetDirectoryName(sharpenedImagePath));
                // Save the sharpened raster image
                rasterImage.Save(sharpenedImagePath);

                // Ensure output directory exists for the PDF
                Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));
                // Save the sharpened image as a PDF page
                var pdfOptions = new PdfOptions();
                rasterImage.Save(pdfOutputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}