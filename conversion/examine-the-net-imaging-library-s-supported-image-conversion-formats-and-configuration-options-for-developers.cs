using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace AsposeImagingDemo
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.gif";
            string outputJpeg = @"C:\temp\output.jpg";
            string outputPng = @"C:\temp\output.png";
            string outputBmp = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputJpeg));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPng));
            Directory.CreateDirectory(Path.GetDirectoryName(outputBmp));

            // Display registered image creation formats
            var registeredFormats = ImageCreatorsRegistry.RegisteredFormats;
            Console.WriteLine($"Registered image creation formats: {registeredFormats}");

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // JPEG conversion
                var jpegOptions = new JpegOptions { Quality = 80 };
                bool canSaveJpeg = image.CanSave(jpegOptions);
                Console.WriteLine($"Can save to JPEG: {canSaveJpeg}");
                if (canSaveJpeg)
                {
                    image.Save(outputJpeg, jpegOptions);
                    Console.WriteLine($"Saved JPEG to {outputJpeg}");
                }

                // PNG conversion
                var pngOptions = new PngOptions();
                bool canSavePng = image.CanSave(pngOptions);
                Console.WriteLine($"Can save to PNG: {canSavePng}");
                if (canSavePng)
                {
                    image.Save(outputPng, pngOptions);
                    Console.WriteLine($"Saved PNG to {outputPng}");
                }

                // BMP conversion
                var bmpOptions = new BmpOptions();
                bool canSaveBmp = image.CanSave(bmpOptions);
                Console.WriteLine($"Can save to BMP: {canSaveBmp}");
                if (canSaveBmp)
                {
                    image.Save(outputBmp, bmpOptions);
                    Console.WriteLine($"Saved BMP to {outputBmp}");
                }
            }
        }
    }
}