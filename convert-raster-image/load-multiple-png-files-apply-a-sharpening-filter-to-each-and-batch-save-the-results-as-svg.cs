using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded directories (input PNGs and output SVGs)
        string inputDir = @"C:\Images\Input\";
        string outputDir = @"C:\Images\Output\";

        // List of PNG files to process
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

            // Determine output SVG path
            string outputFileName = Path.GetFileNameWithoutExtension(fileName) + ".svg";
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster filters
                RasterImage raster = (RasterImage)image;

                // Apply a sharpen filter to the whole image
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Prepare SVG save options with rasterization settings
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = raster.Size
                    }
                };

                // Save the processed image as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}