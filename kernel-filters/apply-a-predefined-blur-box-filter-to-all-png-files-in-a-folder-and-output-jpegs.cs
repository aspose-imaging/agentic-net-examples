using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output folders
        string inputFolder = "input";
        string outputFolder = "output";

        // Ensure output folder exists
        Directory.CreateDirectory(outputFolder);

        // Get all PNG files in the input folder
        string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

        foreach (string inputPath in pngFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path with .jpg extension
            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

            // Ensure the directory for the output file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Create a blur box kernel (size 5) and apply it
                double[,] kernel = ConvolutionFilter.GetBlurBox(5);
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Set JPEG save options (optional quality setting)
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save the processed image as JPEG
                raster.Save(outputPath, jpegOptions);
            }
        }
    }
}