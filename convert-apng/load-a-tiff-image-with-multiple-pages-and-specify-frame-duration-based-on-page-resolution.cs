using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                TiffFrame[] frames = tiff.Frames;
                for (int i = 0; i < frames.Length; i++)
                {
                    TiffFrame frame = frames[i];
                    // Example: set duration proportional to the sum of horizontal and vertical resolution
                    int durationMs = (int)(frame.HorizontalResolution + frame.VerticalResolution);
                    Console.WriteLine($"Frame {i}: Resolution {frame.HorizontalResolution}x{frame.VerticalResolution}, Duration {durationMs} ms");
                    // Note: Actual setting of frame duration would require modifying TIFF tags,
                    // which is beyond this simple demonstration.
                }

                tiff.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}