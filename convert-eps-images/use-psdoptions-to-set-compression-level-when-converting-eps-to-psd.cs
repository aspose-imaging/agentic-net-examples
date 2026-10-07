// HOW-TO: Convert EPS to PSD with RLE Compression Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                using (var options = new PsdOptions())
                {
                    options.CompressionMethod = CompressionMethod.RLE;
                    options.Source = new FileCreateSource(outputPath, false);
                    epsImage.Save(outputPath, options);
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
 * 1. When a designer needs to turn vector EPS artwork into a Photoshop PSD file while keeping the file size low by applying RLE compression.
 * 2. When an automated build process must batch‑convert EPS assets to PSDs for further editing in Photoshop without manual intervention.
 * 3. When a web application uploads EPS logos and must store them as compressed PSDs to save storage space on the server.
 * 4. When a printing workflow requires EPS files to be converted to PSDs with lossless compression before color‑proofing in Photoshop.
 * 5. When a migration script moves legacy EPS graphics into a PSD‑based asset library and wants to ensure consistent compression across all files.
 */
