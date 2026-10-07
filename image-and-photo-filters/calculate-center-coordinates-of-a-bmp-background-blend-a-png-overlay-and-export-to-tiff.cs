// HOW-TO: Blend PNG Overlay onto Center of BMP and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputBmpPath = "input.bmp";
            string inputPngPath = "overlay.png";
            string outputTiffPath = "output.tiff";

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            using (RasterImage background = (RasterImage)Image.Load(inputBmpPath))
            using (RasterImage overlay = (RasterImage)Image.Load(inputPngPath))
            {
                int offsetX = (background.Width - overlay.Width) / 2;
                int offsetY = (background.Height - overlay.Height) / 2;

                background.Blend(new Point(offsetX, offsetY), overlay, 127);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputTiffPath, false)
                };

                background.Save(outputTiffPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to place a logo PNG at the exact center of a BMP background and output the result as a high‑resolution TIFF for printing.
 * 2. When generating composite images for a catalog where the base photo is a BMP and the overlay is a semi‑transparent PNG that must be centered before saving to TIFF.
 * 3. When automating the creation of watermarked TIFF files by blending a PNG watermark onto the middle of a BMP image.
 * 4. When converting legacy BMP assets to TIFF while adding a centered PNG badge or icon with controlled opacity.
 * 5. When building a batch process that merges product images (BMP) with promotional overlays (PNG) and stores the final composition in TIFF format for archival.
 */
