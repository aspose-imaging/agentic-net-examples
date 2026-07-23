using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\rawpixels.bin";
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions (must match raw data size)
            int width = 100;
            int height = 100;

            // Read raw pixel data (assumed 32‑bpp ARGB)
            byte[] rawData = File.ReadAllBytes(inputPath);
            int expectedLength = width * height * 4;
            if (rawData.Length < expectedLength)
            {
                Console.Error.WriteLine("Insufficient pixel data.");
                return;
            }

            // Convert byte array to int[] pixel array
            int[] pixels = new int[width * height];
            for (int i = 0; i < pixels.Length; i++)
            {
                int offset = i * 4;
                int a = rawData[offset];
                int r = rawData[offset + 1];
                int g = rawData[offset + 2];
                int b = rawData[offset + 3];
                pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
            }

            // Set BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 32,
                Compression = Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create image from pixel array and save
            using (Image image = Image.Create(bmpOptions, width, height, pixels))
            {
                image.Save();
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
 * 1. When a developer receives raw sensor data from a medical imaging device and needs to convert the 32‑bpp ARGB byte stream into a BMP file for analysis or archival.
 * 2. When a game engine exports framebuffer data as a binary file and the developer must reconstruct the screenshot as a BMP image for debugging or user sharing.
 * 3. When a batch processing tool reads raw pixel dumps from a legacy camera system and creates BMP files to feed into a third‑party image viewer that only supports BMP.
 * 4. When a security application captures screen pixels in memory, stores them as a raw byte array, and later needs to generate a BMP file for forensic reporting.
 * 5. When a data‑visualization service receives generated pixel arrays from a GPU compute job and uses Aspose.Imaging to write them as BMP files for inclusion in reports or email attachments.
 */