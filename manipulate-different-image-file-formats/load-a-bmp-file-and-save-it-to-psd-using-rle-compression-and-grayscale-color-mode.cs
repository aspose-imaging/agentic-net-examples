// HOW-TO: Convert BMP to PSD With RLE Compression And Grayscale In C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to transform legacy BMP assets into Photoshop PSD files while preserving file size using RLE compression.
 * 2. When an application must generate grayscale PSD layers from bitmap images for batch processing in a graphics pipeline.
 * 3. When a .NET service converts user‑uploaded BMP pictures into PSD format for compatibility with Adobe Photoshop editing tools.
 * 4. When automating the preparation of print‑ready files, developers require BMP to PSD conversion with lossless compression to maintain image quality.
 * 5. When integrating image conversion into a workflow that stores source images as BMP and needs them in PSD format for further manipulation in design software.
 */
