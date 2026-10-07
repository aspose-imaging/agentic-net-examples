// HOW-TO: Save JPEG As Lossless PNG With Maximum Compression In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\source.jpg";
            string outputPath = "Output\\archival.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.PngCompressionLevel = PngCompressionLevel.ZipLevel9;
                    image.Save(outputPath, options);
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
 * 1. When you need to archive photographic assets in a format that preserves every pixel while reducing file size, you can convert JPEGs to lossless PNGs using Aspose.Imaging in C#.
 * 2. When a legal or compliance system requires image evidence to be stored without any quality loss, this code creates a PNG archive with the highest zip compression level.
 * 3. When a web application must generate thumbnails for a digital library and keep the original visual fidelity for future re‑processing, the JPEG‑to‑PNG conversion ensures lossless storage.
 * 4. When migrating legacy image collections to a cloud storage solution that only accepts PNG, the snippet provides an automated way to re‑encode JPEG files with maximum compression.
 * 5. When building a backup utility that compresses image files while guaranteeing no degradation, the Aspose.Imaging PNG options let you save JPEGs as archival‑grade PNGs in C#.
 */
