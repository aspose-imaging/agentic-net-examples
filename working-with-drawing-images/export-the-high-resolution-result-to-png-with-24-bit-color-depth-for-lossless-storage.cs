// HOW-TO: Convert High Resolution TIFF to 24‑Bit PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\highres.tif";
            string outputPath = "Output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions
                {
                    BitDepth = 24,
                    ColorType = PngColorType.Truecolor,
                    Source = new FileCreateSource(outputPath, false)
                })
                {
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
 * 1. When a developer needs to archive high‑resolution scanned documents as lossless PNG files for long‑term storage.
 * 2. When an application must convert multi‑megapixel TIFF images to 24‑bit PNG for web display without sacrificing color fidelity.
 * 3. When a printing workflow requires transforming TIFF source files into true‑color PNGs before sending them to a raster image processor.
 * 4. When a GIS system needs to export detailed TIFF map tiles as PNGs to reduce file size while keeping full 24‑bit color depth.
 * 5. When a desktop utility must batch‑process user‑uploaded TIFF photos and save them as PNGs for compatibility with downstream .NET image libraries.
 */
