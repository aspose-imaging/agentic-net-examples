using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Windows\\System32\\drivers\\etc\\hosts";
            string outputPath = "output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage whiteImg = (RasterImage)Image.Create(
                new PngOptions { Source = new StreamSource(new MemoryStream()) }, 10, 10))
            {
                int[] whitePixels = new int[10 * 10];
                for (int i = 0; i < whitePixels.Length; i++)
                    whitePixels[i] = unchecked((int)0xFFFFFFFF);
                whiteImg.SaveArgb32Pixels(new Rectangle(0, 0, 10, 10), whitePixels);

                var whiteMask = MagicWandTool.Select(whiteImg, new MagicWandSettings(0, 0));
                var invertedWhiteMask = whiteMask.Invert();

                bool whiteTest = whiteMask.IsOpaque(0, 0) && invertedWhiteMask.IsTransparent(0, 0);
                Console.WriteLine($"White mask inversion test: {(whiteTest ? "PASS" : "FAIL")}");
            }

            using (RasterImage blackImg = (RasterImage)Image.Create(
                new PngOptions { Source = new StreamSource(new MemoryStream()) }, 10, 10))
            {
                int[] blackPixels = new int[10 * 10];
                for (int i = 0; i < blackPixels.Length; i++)
                    blackPixels[i] = unchecked((int)0xFF000000);
                blackImg.SaveArgb32Pixels(new Rectangle(0, 0, 10, 10), blackPixels);

                var blackMask = MagicWandTool.Select(blackImg, new MagicWandSettings(0, 0));
                var invertedBlackMask = blackMask.Invert();

                bool blackTest = blackMask.IsOpaque(0, 0) && invertedBlackMask.IsTransparent(0, 0);
                Console.WriteLine($"Black mask inversion test: {(blackTest ? "PASS" : "FAIL")}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}