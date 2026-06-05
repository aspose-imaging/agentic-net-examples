using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output paths
            string pngInputPath = "input4k.png";
            string jpegInputPath = "input1080.jpg";
            string pngOutputPath = "output4k.png";
            string jpegOutputPath = "output1080.jpg";

            // Validate input files
            if (!File.Exists(pngInputPath))
            {
                Console.Error.WriteLine($"File not found: {pngInputPath}");
                return;
            }
            if (!File.Exists(jpegInputPath))
            {
                Console.Error.WriteLine($"File not found: {jpegInputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));

            // Process 4K PNG with MagicWandTool
            long beforePng = GC.GetTotalMemory(true);
            using (RasterImage pngImage = (RasterImage)Image.Load(pngInputPath))
            {
                MagicWandTool
                    .Select(pngImage, new MagicWandSettings(10, 10))
                    .Apply();

                pngImage.Save(pngOutputPath, new PngOptions());
            }
            long afterPng = GC.GetTotalMemory(true);
            long pngMemoryUsed = afterPng - beforePng;

            // Process 1080p JPEG with MagicWandTool
            long beforeJpeg = GC.GetTotalMemory(true);
            using (RasterImage jpegImage = (RasterImage)Image.Load(jpegInputPath))
            {
                MagicWandTool
                    .Select(jpegImage, new MagicWandSettings(10, 10))
                    .Apply();

                jpegImage.Save(jpegOutputPath, new JpegOptions());
            }
            long afterJpeg = GC.GetTotalMemory(true);
            long jpegMemoryUsed = afterJpeg - beforeJpeg;

            // Output memory usage comparison
            Console.WriteLine($"Memory used for PNG (4K) MagicWand processing: {pngMemoryUsed} bytes");
            Console.WriteLine($"Memory used for JPEG (1080p) MagicWand processing: {jpegMemoryUsed} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}