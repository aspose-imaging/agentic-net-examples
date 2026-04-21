using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string backgroundPath = "C:\\temp\\background.bmp";
        string overlayPath = "C:\\temp\\overlay.png";
        string outputPath = "C:\\temp\\result.tif";

        if (!File.Exists(backgroundPath))
        {
            Console.Error.WriteLine($"File not found: {backgroundPath}");
            return;
        }
        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
        {
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                int offsetX = (background.Width - overlay.Width) / 2;
                int offsetY = (background.Height - overlay.Height) / 2;

                Rectangle destRect = new Rectangle(offsetX, offsetY, overlay.Width, overlay.Height);
                background.SaveArgb32Pixels(destRect, overlay.LoadArgb32Pixels(overlay.Bounds));

                Source tiffSource = new FileCreateSource(outputPath, false);
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = tiffSource })
                {
                    background.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}