using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

namespace BmpOptionsLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the BMP file whose options we want to list
            string bmpPath = @"C:\temp\sample.bmp";

            // Load the BMP image using the standard load rule
            using (Image image = Image.Load(bmpPath))
            {
                // Cast to BmpImage to access BMP‑specific properties
                BmpImage bmpImage = image as BmpImage;
                if (bmpImage == null)
                {
                    Console.WriteLine("The specified file is not a BMP image.");
                    return;
                }

                // Bits per pixel
                Console.WriteLine($"BitsPerPixel: {bmpImage.BitsPerPixel}");

                // Compression type
                Console.WriteLine($"Compression: {bmpImage.Compression}");

                // Palette information (if present)
                if (bmpImage.Palette != null)
                {
                    Console.WriteLine($"Palette entries: {bmpImage.Palette.Length}");
                }
                else
                {
                    Console.WriteLine("Palette: None");
                }

                // Resolution settings
                if (bmpImage.ResolutionSettings != null)
                {
                    Console.WriteLine($"Horizontal DPI: {bmpImage.ResolutionSettings.HorizontalResolution}");
                    Console.WriteLine($"Vertical DPI:   {bmpImage.ResolutionSettings.VerticalResolution}");
                }

                // Full frame flag (if applicable)
                Console.WriteLine($"FullFrame: {bmpImage.FullFrame}");

                // KeepMetadata flag (if applicable)
                Console.WriteLine($"KeepMetadata: {bmpImage.KeepMetadata}");
            }
        }
    }
}