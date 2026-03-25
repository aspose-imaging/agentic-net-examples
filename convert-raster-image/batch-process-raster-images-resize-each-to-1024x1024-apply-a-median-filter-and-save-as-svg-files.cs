using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output folders
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        // List of raster files to process
        string[] files = new[]
        {
            "photo1.jpg",
            "photo2.png",
            "photo3.bmp"
        };

        foreach (string fileName in files)
        {
            // Build full input path
            string inputPath = Path.Combine(inputFolder, fileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x1024 using default resampling
                image.Resize(1024, 1024);

                // Apply a median filter with kernel size 5
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Prepare output path with .svg extension
                string outputFileName = Path.GetFileNameWithoutExtension(fileName) + ".svg";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure SVG saving options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = new Size(1024, 1024)
                    }
                };

                // Save the processed image as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}