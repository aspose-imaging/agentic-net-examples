using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.png";
        string outputPath = "Output/cropped.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            int side = Math.Min(raster.Width, raster.Height);
            int left = (raster.Width - side) / 2;
            int top = (raster.Height - side) / 2;

            Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(left, top, side, side);

            raster.Crop(cropRect);

            raster.Save(outputPath);
        }
    }
}