// HOW-TO: Convert Multi‑Page TIFF to Lossless APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)tiffImage;
                TiffFrame firstFrame = tiff.Frames[0];
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
                {
                    apng.RemoveAllFrames();

                    foreach (TiffFrame frame in tiff.Frames)
                    {
                        apng.AddFrame((RasterImage)frame);
                    }

                    apng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to turn a scanned multi‑page document saved as TIFF into a high‑quality animated PNG for web display without losing image detail.
 * 2. When an application must generate a lossless APNG from a series of TIFF frames for use in mobile games or UI animations.
 * 3. When you have archival TIFF images and want to create a lightweight, transparent‑background animation for email newsletters.
 * 4. When a reporting tool requires converting multi‑page TIFF charts into an APNG to embed in HTML dashboards while preserving exact colors.
 * 5. When automating batch processing of TIFF files to APNG format in a C# service that must retain full resolution and alpha channel information.
 */
