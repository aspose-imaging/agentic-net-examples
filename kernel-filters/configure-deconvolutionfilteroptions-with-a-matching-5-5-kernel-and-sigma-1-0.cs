using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image and apply deconvolution filter
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

            // Configure Gaussian deconvolution filter with 5x5 kernel and sigma 1.0
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianDeconvolutionFilterOptions(5, 1.0);

            // Apply filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}