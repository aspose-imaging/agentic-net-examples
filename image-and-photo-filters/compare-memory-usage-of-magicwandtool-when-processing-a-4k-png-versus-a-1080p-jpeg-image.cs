using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // 4K PNG processing
        string pngInputPath = @"C:\Images\input_4k.png";
        string pngOutputPath = @"C:\Images\output_4k.png";

        if (!File.Exists(pngInputPath))
        {
            Console.Error.WriteLine($"File not found: {pngInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

        long pngMemoryBefore = Cache.AllocatedMemoryBytesCount;

        using (RasterImage pngImage = (RasterImage)Image.Load(pngInputPath))
        {
            // Apply Magic Wand tool (example point and default threshold)
            MagicWandTool
                .Select(pngImage, new MagicWandSettings(100, 100))
                .Apply();

            pngImage.Save(pngOutputPath);
        }

        long pngMemoryAfter = Cache.AllocatedMemoryBytesCount;
        Console.WriteLine($"4K PNG processing memory usage: {pngMemoryAfter - pngMemoryBefore} bytes");

        // 1080p JPEG processing
        string jpegInputPath = @"C:\Images\input_1080p.jpg";
        string jpegOutputPath = @"C:\Images\output_1080p.jpg";

        if (!File.Exists(jpegInputPath))
        {
            Console.Error.WriteLine($"File not found: {jpegInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));

        long jpegMemoryBefore = Cache.AllocatedMemoryBytesCount;

        using (RasterImage jpegImage = (RasterImage)Image.Load(jpegInputPath))
        {
            // Apply Magic Wand tool (example point and default threshold)
            MagicWandTool
                .Select(jpegImage, new MagicWandSettings(100, 100))
                .Apply();

            jpegImage.Save(jpegOutputPath);
        }

        long jpegMemoryAfter = Cache.AllocatedMemoryBytesCount;
        Console.WriteLine($"1080p JPEG processing memory usage: {jpegMemoryAfter - jpegMemoryBefore} bytes");
    }
}