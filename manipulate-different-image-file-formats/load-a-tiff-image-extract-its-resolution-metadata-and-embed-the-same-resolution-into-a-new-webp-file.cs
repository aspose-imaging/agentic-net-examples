using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                TiffImage tif = tiffImage as TiffImage;
                if (tif == null)
                {
                    Console.Error.WriteLine("Loaded image is not a TIFF.");
                    return;
                }

                double dpiX = tif.HorizontalResolution;
                double dpiY = tif.VerticalResolution;

                WebPOptions webpOptions = new WebPOptions();
                webpOptions.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);

                tiffImage.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}