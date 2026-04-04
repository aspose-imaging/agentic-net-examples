using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputBmpPath = "C:\\temp\\background.bmp";
        string inputPngPath = "C:\\temp\\overlay.png";
        string outputTiffPath = "C:\\temp\\result.tif";

        // Validate input files
        if (!File.Exists(inputBmpPath))
        {
            Console.Error.WriteLine($"File not found: {inputBmpPath}");
            return;
        }
        if (!File.Exists(inputPngPath))
        {
            Console.Error.WriteLine($"File not found: {inputPngPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

        // Load background BMP and overlay PNG
        using (RasterImage background = (RasterImage)Image.Load(inputBmpPath))
        using (RasterImage overlay = (RasterImage)Image.Load(inputPngPath))
        {
            // Calculate center position
            int offsetX = (background.Width - overlay.Width) / 2;
            int offsetY = (background.Height - overlay.Height) / 2;

            // Blend overlay onto background
            Rectangle destRect = new Rectangle(offsetX, offsetY, overlay.Width, overlay.Height);
            background.SaveArgb32Pixels(destRect, overlay.LoadArgb32Pixels(overlay.Bounds));

            // Save result as TIFF
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            background.Save(outputTiffPath, tiffOptions);
        }
    }
}