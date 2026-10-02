// HOW-TO: Generate JPEG2000 Image From ARGB Pixel Array In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.jp2";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 256;
            int height = 256;
            int[] pixels = new int[width * height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte r = (byte)(x * 255 / (width - 1));
                    byte g = (byte)(y * 255 / (height - 1));
                    byte b = 0;
                    int argb = (255 << 24) | (r << 16) | (g << 8) | b;
                    pixels[y * width + x] = argb;
                }
            }

            var options = new Jpeg2000Options();

            using (var canvas = new Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image(width, height, options))
            {
                canvas.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height), pixels);
                canvas.Save(outputPath, options);
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
 * 1. When you need to programmatically create a high‑resolution JPEG2000 file from a custom‑generated ARGB bitmap for medical imaging or satellite data pipelines.
 * 2. When you must export raw pixel buffers produced by a rendering engine into a lossless JPEG2000 format for archival storage while controlling bits‑per‑sample and color space.
 * 3. When integrating Aspose.Imaging into a C# application to convert procedural graphics into JPEG2000 for web‑based viewers that require JP2 support.
 * 4. When building a batch process that transforms dynamically created pixel arrays into JPEG2000 files to meet industry standards for digital publishing.
 * 5. When testing image‑processing algorithms and need to save the resulting pixel matrix as a JPEG2000 image to verify compression and color fidelity.
 */
