using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "C:\\temp\\input.png";
            string outputPngPath = "C:\\temp\\output_blurred.png";
            string outputPdfPath = "C:\\temp\\preview.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768
                image.Resize(1024, 768);

                // Apply Gaussian blur to the entire image
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image as PNG
                raster.Save(outputPngPath, new PngOptions());

                // Save a PDF preview of the blurred image
                raster.Save(outputPdfPath, new PdfOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}