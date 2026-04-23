using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("TIFF image is not a raster image.");
                    return;
                }

                using (WebPOptions options = new WebPOptions { KeepMetadata = true })
                {
                    raster.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}