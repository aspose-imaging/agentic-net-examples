using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string pngInput = "input_4k.png";
            string jpegInput = "input_1080p.jpg";
            string pngOutput = "output_4k_processed.png";
            string jpegOutput = "output_1080p_processed.jpg";

            // Validate input files
            if (!File.Exists(pngInput))
            {
                Console.Error.WriteLine($"File not found: {pngInput}");
                return;
            }
            if (!File.Exists(jpegInput))
            {
                Console.Error.WriteLine($"File not found: {jpegInput}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(pngOutput));
            Directory.CreateDirectory(Path.GetDirectoryName(jpegOutput));

            // Measure memory before processing PNG
            long beforePng = Process.GetCurrentProcess().PrivateMemorySize64;

            // Load 4K PNG and apply MagicWand
            using (RasterImage pngImage = (RasterImage)Image.Load(pngInput))
            {
                MagicWandTool.Select(pngImage, new MagicWandSettings(100, 100)).Apply();
                pngImage.Save(pngOutput, new PngOptions());
            }

            // Measure memory after processing PNG
            long afterPng = Process.GetCurrentProcess().PrivateMemorySize64;
            long pngMemoryUsed = afterPng - beforePng;

            // Measure memory before processing JPEG
            long beforeJpeg = Process.GetCurrentProcess().PrivateMemorySize64;

            // Load 1080p JPEG and apply MagicWand
            using (RasterImage jpegImage = (RasterImage)Image.Load(jpegInput))
            {
                MagicWandTool.Select(jpegImage, new MagicWandSettings(50, 50)).Apply();
                jpegImage.Save(jpegOutput, new JpegOptions());
            }

            // Measure memory after processing JPEG
            long afterJpeg = Process.GetCurrentProcess().PrivateMemorySize64;
            long jpegMemoryUsed = afterJpeg - beforeJpeg;

            // Output memory usage comparison
            Console.WriteLine($"Memory increase during PNG MagicWand processing: {pngMemoryUsed / 1024} KB");
            Console.WriteLine($"Memory increase during JPEG MagicWand processing: {jpegMemoryUsed / 1024} KB");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}