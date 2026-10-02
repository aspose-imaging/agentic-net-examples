// HOW-TO: Export PNG Mask Pixels to Binary File Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\mask.png";
            string outputPath = "Output\\mask.bin";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage maskImage = (RasterImage)Image.Load(inputPath))
            {
                int pixelCount = maskImage.Width * maskImage.Height;
                int[] pixels = new int[pixelCount];
                maskImage.SaveArgb32Pixels(new Rectangle(0, 0, maskImage.Width, maskImage.Height), pixels);

                using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (int pixel in pixels)
                    {
                        bw.Write(pixel);
                    }
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
 * 1. When you need to feed a refined segmentation mask from a PNG into a custom computer‑vision algorithm that expects raw ARGB32 integers stored in a binary file.
 * 2. When integrating Aspose.Imaging with a C# pipeline to convert mask images into a compact binary format for fast loading in GPU‑accelerated inference engines.
 * 3. When exporting pixel‑level mask data for training deep‑learning models that require binary label files rather than image files.
 * 4. When building a cross‑platform vision system where the mask must be transmitted over a network as a binary payload to reduce bandwidth.
 * 5. When creating a preprocessing step that reads a PNG mask, extracts its pixel values, and writes them to a .bin file for use by legacy C/C++ vision libraries.
 */
