using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)image)
                {
                    if (!raster.IsCached)
                        raster.CacheData();

                    int newWidth = raster.Width / 2;
                    int newHeight = raster.Height / 2;
                    raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                    string password = "Passw0rd10";
                    raster.EmbedDigitalSignature(password);

                    raster.Save(outputPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}