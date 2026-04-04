using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input PSD files and corresponding sigma values for Gaussian blur
        string[] inputPaths = {
            @"C:\Images\image1.psd",
            @"C:\Images\image2.psd",
            @"C:\Images\image3.psd"
        };

        double[] sigmaValues = { 2.0, 4.5, 3.2 };
        int radius = 5; // Common radius for all images

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output PNG path (same folder, .png extension)
            string outputPath = Path.ChangeExtension(inputPath, ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PSD, apply Gaussian blur, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(radius, sigmaValues[i]));
                raster.Save(outputPath, new PngOptions());
            }
        }
    }
}