using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image, apply Gaussian blur, and save
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            raster.Save(outputPath);
        }
    }
}