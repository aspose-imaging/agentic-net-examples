using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel operations
            RasterImage raster = (RasterImage)image;

            // Resize to 1024x1024 pixels
            raster.Resize(1024, 1024);

            // Apply a median filter with a kernel size of 5
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save the processed image as PDF
            PdfOptions pdfOptions = new PdfOptions();
            raster.Save(outputPath, pdfOptions);
        }
    }
}