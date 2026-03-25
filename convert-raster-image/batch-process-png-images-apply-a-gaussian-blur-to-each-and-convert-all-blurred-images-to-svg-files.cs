using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output directories
        string inputDir = @"C:\Images\Input\";
        string outputDir = @"C:\Images\Output\";

        // List of PNG files to process (add or remove names as needed)
        string[] pngFiles = new[]
        {
            "image1.png",
            "image2.png",
            "image3.png"
        };

        foreach (string fileName in pngFiles)
        {
            // Build full input path and verify existence
            string inputPath = Path.Combine(inputDir, fileName);
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare SVG output path
                string outputFileName = Path.GetFileNameWithoutExtension(fileName) + ".svg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the blurred image as SVG
                SvgOptions svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }
        }
    }
}