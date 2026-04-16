using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.png";
        string outputPath = "Output/sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel operations
            RasterImage raster = (RasterImage)image;

            // Resize to half of original dimensions
            int newWidth = raster.Width / 2;
            int newHeight = raster.Height / 2;
            raster.Resize(newWidth, newHeight); // default NearestNeighbourResample

            // Apply a median filter with kernel size 5
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

            // Save the processed image as PDF
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                raster.Save(outputPath, pdfOptions);
            }
        }
    }
}