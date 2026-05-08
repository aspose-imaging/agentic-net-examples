using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.png";
            string outputPath = "sample_filtered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and cast to RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // ----- Median Filter -----
                DateTime medianStart = DateTime.Now;
                Console.WriteLine($"Median filter start: {medianStart:O}");
                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
                DateTime medianEnd = DateTime.Now;
                Console.WriteLine($"Median filter end:   {medianEnd:O}");

                // ----- Gaussian Blur Filter -----
                DateTime gaussianStart = DateTime.Now;
                Console.WriteLine($"Gaussian blur start: {gaussianStart:O}");
                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                DateTime gaussianEnd = DateTime.Now;
                Console.WriteLine($"Gaussian blur end:   {gaussianEnd:O}");

                // ----- Sharpen Filter -----
                DateTime sharpenStart = DateTime.Now;
                Console.WriteLine($"Sharpen filter start: {sharpenStart:O}");
                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                DateTime sharpenEnd = DateTime.Now;
                Console.WriteLine($"Sharpen filter end:   {sharpenEnd:O}");

                // Save the processed image as PNG
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}