using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

public class Program
{
    public static void Main()
    {
        string inputPath = "C:\\temp\\source.png";
        string outputPath = "C:\\temp\\output.jp2";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image srcImage = Image.Load(inputPath))
            {
                RasterImage raster = srcImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Source image is not a raster image.");
                    return;
                }

                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false // lossless compression
                };

                using (Jpeg2000Image jp2Image = new Jpeg2000Image(raster))
                {
                    jp2Image.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}