using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmz";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary raster file path
        string tempRasterPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

        // Load the WMZ (vector) image and rasterize to PNG
        using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
        {
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            vectorImage.Save(tempRasterPath, pngOptions);
        }

        // Load the rasterized PNG, apply MotionWiener filter, and save the result
        using (Aspose.Imaging.Image rasterImageContainer = Aspose.Imaging.Image.Load(tempRasterPath))
        {
            var rasterImage = (Aspose.Imaging.RasterImage)rasterImageContainer;

            // Apply MotionWiener filter: length=10, smooth=1.0, angle=90.0
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Clean up temporary file
        if (File.Exists(tempRasterPath))
        {
            try { File.Delete(tempRasterPath); } catch { /* ignore */ }
        }
    }
}