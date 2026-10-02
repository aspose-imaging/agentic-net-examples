// HOW-TO: Load JPEG2000 Image With 4 MB Buffer In C# To Reduce Memory Usage (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jp2";
        string outputPath = "output.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath, new LoadOptions() { BufferSizeHint = 4 * 1024 * 1024 }))
            {
                string info = $"Width: {image.Width}, Height: {image.Height}";
                File.WriteAllText(outputPath, info);
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
 * 1. When processing large JPEG2000 files on a server with limited RAM, you can load the image using a 4 MB buffer to keep memory usage low.
 * 2. When extracting image dimensions from a JP2 file for metadata generation without loading the entire image into memory.
 * 3. When building a batch conversion tool that must read many high‑resolution JP2 images on a low‑end workstation, setting a custom buffer size prevents out‑of‑memory errors.
 * 4. When integrating Aspose.Imaging into a cloud function that has strict memory quotas, using BufferSizeHint ensures the function stays within the allocated limit.
 * 5. When creating a diagnostic utility that logs the width and height of JPEG2000 assets while preserving system performance.
 */
