using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

public interface IImageFilterService
{
    void ApplySharpenFilter(string inputPath, string outputPath);
}

public class ImageFilterService : IImageFilterService
{
    public void ApplySharpenFilter(string inputPath, string outputPath)
    {
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new SharpenFilterOptions());
            raster.Save(outputPath);
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            IImageFilterService filterService = new ImageFilterService();
            filterService.ApplySharpenFilter(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}