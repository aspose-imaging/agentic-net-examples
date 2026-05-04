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
        string inputFolder = @"C:\InputBmp";
        string outputFolder = @"C:\OutputSvg";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .svg extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for filtering and resizing
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply median filter with size 5 to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Resize to 300x300 pixels
                    rasterImage.Resize(300, 300);

                    // Save as SVG using SvgOptions (raster image will be embedded)
                    SvgOptions svgOptions = new SvgOptions();
                    rasterImage.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}