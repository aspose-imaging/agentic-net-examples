using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            int beforePixel = raster.GetArgb32Pixel(0, 0);

            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(9, 1.0, 180.0));

            int afterPixel = raster.GetArgb32Pixel(0, 0);

            if (beforePixel == afterPixel)
                Console.WriteLine("Brightness unchanged.");
            else
                Console.WriteLine("Brightness may have changed.");

            raster.Save(outputPath);
        }
    }
}