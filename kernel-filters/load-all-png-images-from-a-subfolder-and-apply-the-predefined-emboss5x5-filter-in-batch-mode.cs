using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative to the current directory)
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Get all PNG files in the input directory
        string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

        foreach (string inputPath in pngFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output file path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_embossed.png";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, apply Emboss5x5 filter, and save
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                raster.Save(outputPath);
            }
        }
    }
}