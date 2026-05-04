using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\inverted.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int a = pixel & unchecked((int)0xFF000000);
                    int rgb = pixel & 0x00FFFFFF;
                    int inv = (~rgb) & 0x00FFFFFF;
                    pixels[i] = a | inv;
                }
                raster.SaveArgb32Pixels(raster.Bounds, pixels);

                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}