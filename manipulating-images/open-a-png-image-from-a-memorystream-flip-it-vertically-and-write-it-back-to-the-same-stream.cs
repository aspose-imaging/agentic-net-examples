using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Create a simple 1x1 PNG image in a memory buffer
        byte[] pngData;
        using (var tempStream = new MemoryStream())
        {
            using (var png = new PngImage(1, 1, PngColorType.TruecolorWithAlpha))
            {
                // Set a single red pixel (ARGB)
                png.SaveArgb32Pixels(new Rectangle(0, 0, 1, 1), new int[] { unchecked((int)0xFFFF0000) });
                png.Save(tempStream, new PngOptions());
            }
            pngData = tempStream.ToArray();
        }

        // Load the PNG from the memory stream
        using (var stream = new MemoryStream(pngData))
        {
            using (Image image = Image.Load(stream))
            {
                // Flip the image vertically
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Overwrite the original data in the same stream
                stream.Position = 0;
                image.Save(stream, new PngOptions());
            }

            Console.WriteLine($"Flipped image size: {stream.Length} bytes");
        }
    }
}