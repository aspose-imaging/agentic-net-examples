// HOW-TO: Create BMP Image from Raw ARGB Byte Array in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.raw";
            string outputPath = @"C:\temp\output.bmp";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Read raw pixel data (expected 4 bytes per pixel: ARGB)
            byte[] rawBytes = File.ReadAllBytes(inputPath);

            // Define image dimensions (must match the raw data size)
            int width = 100;
            int height = 100;
            int bytesPerPixel = 4; // ARGB

            if (rawBytes.Length < width * height * bytesPerPixel)
            {
                Console.Error.WriteLine("Insufficient pixel data in input file.");
                return;
            }

            // Convert byte array to int[] where each int represents a pixel (ARGB)
            int[] pixels = new int[width * height];
            for (int i = 0; i < width * height; i++)
            {
                int offset = i * bytesPerPixel;
                // Assemble ARGB (assuming input order is A,R,G,B)
                int a = rawBytes[offset];
                int r = rawBytes[offset + 1];
                int g = rawBytes[offset + 2];
                int b = rawBytes[offset + 3];
                pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
            }

            // Prepare BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24, // 24‑bpp BMP
                Compression = BitmapCompression.Rgb
            };

            // Create the image from raw pixel data
            using (Image image = Image.Create(bmpOptions, width, height, pixels))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the BMP image
                image.Save(outputPath);
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
 * 1. When you receive sensor data as a raw ARGB byte stream and need to generate a BMP file for visualization or archival in a .NET application.
 * 2. When converting proprietary raw image formats from legacy equipment into standard BMP files for compatibility with Windows imaging tools.
 * 3. When generating thumbnail previews from raw pixel buffers in memory without writing intermediate files, using Aspose.Imaging to create the BMP directly.
 * 4. When building a custom graphics pipeline that assembles pixel values programmatically and must output a 24‑bpp BMP for further processing or printing.
 * 5. When migrating raw video frame data to bitmap images for frame‑by‑frame analysis in C# using Aspose.Imaging’s Image.Create method.
 */
