using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering
            RasterImage raster = (RasterImage)image;

            // Apply a median filter with a size of 5 to the whole image
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save the filtered image as a PDF.
            // The image occupies the whole page, which effectively centers it.
            PdfOptions pdfOptions = new PdfOptions();
            raster.Save(outputPath, pdfOptions);
        }
    }
}