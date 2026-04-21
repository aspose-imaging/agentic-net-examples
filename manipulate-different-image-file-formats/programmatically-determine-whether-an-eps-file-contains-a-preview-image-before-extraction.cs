using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.eps";
        string outputPath = "output/preview.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            if (image.HasRasterPreview)
            {
                using (var preview = image.GetPreviewImage())
                {
                    if (preview != null)
                    {
                        preview.Save(outputPath, new PngOptions());
                        Console.WriteLine("Preview image extracted and saved.");
                    }
                    else
                    {
                        Console.WriteLine("Raster preview indicated but preview image is null.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No raster preview available in the EPS file.");
            }
        }
    }
}