using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // All runtime errors are caught and reported without crashing.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it unconditionally).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods.
                RasterImage raster = (RasterImage)image;

                // Apply a median filter with a kernel size of 5 to the whole image.
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as a PDF. The image will be placed on the page;
                // Aspose.Imaging centers it by default when using PdfOptions.
                var pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Any unexpected exception is reported here.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}