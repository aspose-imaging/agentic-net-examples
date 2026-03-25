using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage raster = (RasterImage)image;

            // Apply a median filter with a size of 5 to the entire image
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save the filtered image embedded in a PDF page
            PdfOptions pdfOptions = new PdfOptions();
            raster.Save(outputPath, pdfOptions);
        }
    }
}