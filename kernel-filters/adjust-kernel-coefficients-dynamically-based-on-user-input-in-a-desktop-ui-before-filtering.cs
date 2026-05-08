using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                Console.WriteLine("Enter kernel size (odd integer):");
                string sizeStr = Console.ReadLine();
                int size = int.TryParse(sizeStr, out var parsedSize) ? parsedSize : 5;

                Console.WriteLine("Enter sigma (double):");
                string sigmaStr = Console.ReadLine();
                double sigma = double.TryParse(sigmaStr, out var parsedSigma) ? parsedSigma : 4.0;

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(size, sigma);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}