using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.png";
        string outputPath = "Output\\result.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image, apply median filter, and save as PDF
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Apply a median filter with size 5 to the entire image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

            // Save the processed image as PDF (PDF supports transparency)
            raster.Save(outputPath, new PdfOptions());
        }
    }
}