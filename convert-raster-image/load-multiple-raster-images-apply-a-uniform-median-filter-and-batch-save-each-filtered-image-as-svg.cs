using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        // List of raster image file names to process
        string[] inputFiles = new[]
        {
            "image1.png",
            "image2.jpg",
            "image3.bmp"
        };

        // Ensure the output directory exists (unconditional per requirements)
        Directory.CreateDirectory(outputFolder);

        foreach (string fileName in inputFiles)
        {
            string inputPath = Path.Combine(inputFolder, fileName);
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output SVG path
            string outputFileName = Path.GetFileNameWithoutExtension(fileName) + ".svg";
            string outputPath = Path.Combine(outputFolder, outputFileName);

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply a median filter of size 5 to the entire image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as SVG
                SvgOptions svgOptions = new SvgOptions();
                rasterImage.Save(outputPath, svgOptions);
            }
        }
    }
}