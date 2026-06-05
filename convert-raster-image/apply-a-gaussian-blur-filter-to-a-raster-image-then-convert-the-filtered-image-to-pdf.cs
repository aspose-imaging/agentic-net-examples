using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string filteredImagePath = "output/filtered.png";
            string pdfOutputPath = "output/filtered.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(filteredImagePath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 4.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the filtered image (optional, can be omitted if only PDF is needed)
                rasterImage.Save(filteredImagePath);

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the filtered image as PDF
                image.Save(pdfOutputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}