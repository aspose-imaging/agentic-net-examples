using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/thumbnail.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Tiff.TiffImage tiff = (Aspose.Imaging.FileFormats.Tiff.TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var frame = tiff.Frames[0];
                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)frame)
                {
                    int thumbWidth = 150;
                    int thumbHeight = 150;
                    raster.Resize(thumbWidth, thumbHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);
                    raster.Save(outputPath, new WebPOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}