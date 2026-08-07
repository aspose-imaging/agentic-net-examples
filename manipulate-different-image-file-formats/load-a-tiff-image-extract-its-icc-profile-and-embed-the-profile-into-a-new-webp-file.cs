using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new WebPOptions
                {
                    KeepMetadata = true
                };
                image.Save(outputPath, options);
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
 * 1. When a developer needs to convert high‑resolution scanned TIFF documents to lightweight WebP images while preserving the original color accuracy by embedding the embedded ICC profile.
 * 2. When an e‑commerce platform wants to generate web‑optimized product photos from TIFF assets and ensure consistent colors across browsers by copying the ICC profile into the WebP files.
 * 3. When a digital archivist must migrate legacy TIFF images to a modern web‑friendly format without losing color management information, using C# and Aspose.Imaging to embed the ICC profile in the WebP output.
 * 4. When a mobile app backend processes user‑uploaded TIFF files and creates compressed WebP thumbnails that retain the source image’s color profile for accurate display on iOS and Android devices.
 * 5. When a printing workflow needs to preview TIFF artwork as WebP previews in a web portal while keeping the embedded ICC profile so designers can verify color fidelity before final print.
 */