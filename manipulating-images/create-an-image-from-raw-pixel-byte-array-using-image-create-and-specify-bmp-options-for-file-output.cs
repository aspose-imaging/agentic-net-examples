// HOW-TO: Create BMP Image from Raw Pixel Byte Array in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 100;
            int height = 100;
            byte[] rawData = new byte[width * height * 4];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int idx = (y * width + x) * 4;
                    rawData[idx] = (byte)(x % 256);       // Blue
                    rawData[idx + 1] = (byte)(y % 256);   // Green
                    rawData[idx + 2] = 0;                 // Red
                    rawData[idx + 3] = 255;               // Alpha
                }
            }

            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++)
            {
                int baseIdx = i * 4;
                byte b = rawData[baseIdx];
                byte g = rawData[baseIdx + 1];
                byte r = rawData[baseIdx + 2];
                byte a = rawData[baseIdx + 3];
                colors[i] = Color.FromArgb(a, r, g, b);
            }

            Source src = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = src };

            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                canvas.SavePixels(new Rectangle(0, 0, width, height), colors);
                canvas.Save();
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
 * 1. When you need to generate a BMP file from sensor data that provides pixel values as a byte array, you can use this code to build the image directly in C#.
 * 2. When converting procedural graphics or algorithm‑generated color maps into a standard BMP file for legacy applications, this approach lets you write the pixel buffer without intermediate image libraries.
 * 3. When exporting a frame from a video decoding routine that supplies RGBA bytes, you can create a BMP snapshot using Aspose.Imaging’s Image.Create and SavePixels methods.
 * 4. When building a custom thumbnail generator that assembles pixel data on the fly and must save it as a BMP for compatibility with older Windows tools, this code provides a straightforward solution.
 * 5. When integrating a medical imaging device that streams raw pixel data, you can turn the byte stream into a BMP image for quick visual inspection or archival using the Aspose.Imaging API.
 */
