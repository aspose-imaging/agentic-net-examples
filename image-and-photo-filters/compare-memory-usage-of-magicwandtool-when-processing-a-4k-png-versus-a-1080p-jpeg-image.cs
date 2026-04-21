using System;
using System.IO;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string pngInputPath = "input\\input4k.png";
        string pngOutputPath = "output\\output4k.png";
        string jpegInputPath = "input\\input1080.jpg";
        string jpegOutputPath = "output\\output1080.jpg";

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

        try
        {
            // Process 4K PNG with MagicWandTool
            long memBeforePng = GC.GetTotalMemory(true);
            using (Aspose.Imaging.RasterImage pngImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(pngInputPath))
            {
                MagicWandTool.Select(pngImage, new MagicWandSettings(100, 100)).Apply();
                Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));
                pngImage.Save(pngOutputPath);
            }
            long memAfterPng = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory used for PNG MagicWand processing: {memAfterPng - memBeforePng} bytes");

            // Process 1080p JPEG with MagicWandTool
            long memBeforeJpeg = GC.GetTotalMemory(true);
            using (Aspose.Imaging.RasterImage jpegImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(jpegInputPath))
            {
                MagicWandTool.Select(jpegImage, new MagicWandSettings(100, 100)).Apply();
                Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));
                jpegImage.Save(jpegOutputPath);
            }
            long memAfterJpeg = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory used for JPEG MagicWand processing: {memAfterJpeg - memBeforeJpeg} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}