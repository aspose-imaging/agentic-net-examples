using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    static void Main(string[] args)
    {
        // Hardcoded list of input raster image files
        string[] inputFiles = new string[]
        {
            @"C:\Images\input1.png",
            @"C:\Images\input2.jpg"
        };

        // Hardcoded output directory
        string outputFolder = @"C:\Images\Output";

        foreach (string inputPath in inputFiles)
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Construct the output SVG file path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".svg");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing operations
                RasterImage raster = (RasterImage)image;

                // Resize the image to 800x800 pixels
                raster.Resize(800, 800);

                // Apply Gaussian blur (radius 5, sigma 4.0) to the entire image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare SVG export options with appropriate rasterization settings
                SvgOptions svgOptions = new SvgOptions();
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();
                rasterizationOptions.PageSize = raster.Size;
                svgOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save the processed image as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}