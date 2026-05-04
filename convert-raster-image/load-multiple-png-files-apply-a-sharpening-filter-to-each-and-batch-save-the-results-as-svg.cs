using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PNG files
            string[] inputFiles = new[]
            {
                @"C:\Images\image1.png",
                @"C:\Images\image2.png",
                @"C:\Images\image3.png"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path (same folder, same name, .svg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Apply sharpening filter if the image is raster based
                    if (image is RasterImage rasterImage)
                    {
                        // Sharpen with kernel size 5 and sigma 4.0
                        rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
                    }

                    // Save the processed image as SVG
                    image.Save(outputPath, new SvgOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}