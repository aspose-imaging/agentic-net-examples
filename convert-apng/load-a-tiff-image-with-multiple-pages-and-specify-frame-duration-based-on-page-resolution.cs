using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
        {
            int frameIndex = 0;
            foreach (TiffFrame frame in tiff.Frames)
            {
                double avgDpi = (frame.HorizontalResolution + frame.VerticalResolution) / 2.0;
                int durationMs = (int)(1000 / avgDpi);
                Console.WriteLine($"Frame {frameIndex}: DPI={avgDpi:F2}, Duration={durationMs} ms");
                frameIndex++;
            }

            tiff.Save(outputPath);
        }
    }
}