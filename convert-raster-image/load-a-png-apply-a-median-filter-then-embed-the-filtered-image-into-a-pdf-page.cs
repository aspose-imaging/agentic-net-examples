using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input/input.png";
        string outputPath = "output/output.pdf";

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
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply a median filter with size 5 to the entire image
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Prepare PDF options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Save the filtered image as a PDF page
                raster.Save(outputPath, pdfOptions);
            }
        }
    }
}