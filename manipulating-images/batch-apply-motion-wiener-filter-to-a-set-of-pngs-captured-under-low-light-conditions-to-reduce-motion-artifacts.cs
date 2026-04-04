using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        // List of PNG files to process
        string[] files = new string[]
        {
            "image1.png",
            "image2.png",
            "image3.png"
        };

        foreach (string fileName in files)
        {
            string inputPath = Path.Combine(inputDir, fileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + "_filtered.png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load, apply MotionWiener filter, and save
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));
                raster.Save(outputPath);
            }
        }
    }
}