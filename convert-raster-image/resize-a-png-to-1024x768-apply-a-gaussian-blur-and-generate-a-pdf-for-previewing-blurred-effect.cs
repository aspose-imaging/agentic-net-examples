using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/input.png";
        string outputPdfPath = "output/preview.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel operations
            RasterImage raster = (RasterImage)image;

            // Resize to 1024x768 using nearest neighbour resampling
            raster.Resize(1024, 768, ResizeType.NearestNeighbourResample);

            // Apply Gaussian blur (radius 5, sigma 4.0)
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the result as a PDF for preview
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                raster.Save(outputPdfPath, pdfOptions);
            }
        }
    }
}