using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input PSD file
        string inputPath = "Input\\sample.psd";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output PDF file
        string outputPath = "Output\\blurred.pdf";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD, apply Gaussian blur, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            // Gaussian blur with radius 5 and sigma 3
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 3.0));
            raster.Save(outputPath, new PdfOptions());
        }
    }
}