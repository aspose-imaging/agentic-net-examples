using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svgz";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVGZ image
        using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create rasterization options for vector image
            var rasterOptions = new VectorRasterizationOptions
            {
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Set up PNG save options with rasterization
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized image to a temporary PNG file
            string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            vectorImage.Save(tempPngPath, pngOptions);

            // Load the rasterized PNG as a RasterImage
            using (Aspose.Imaging.Image rasterImageBase = Aspose.Imaging.Image.Load(tempPngPath))
            {
                var rasterImage = (Aspose.Imaging.RasterImage)rasterImageBase;

                // Apply motion Wiener filter
                rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                // Save the processed image to the final output path
                rasterImage.Save(outputPath);
            }

            // Clean up temporary file
            try { File.Delete(tempPngPath); } catch { }
        }
    }
}