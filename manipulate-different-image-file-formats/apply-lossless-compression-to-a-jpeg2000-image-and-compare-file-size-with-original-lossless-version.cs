using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jp2";
            string outputPath = "Output\\sample_lossless.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(inputPath))
            {
                Jpeg2000Options options = new Jpeg2000Options(); // default is lossless (Irreversible = false)
                jpeg2000Image.Save(outputPath, options);
            }

            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
            if (originalSize > 0)
            {
                double ratio = (double)compressedSize / originalSize * 100;
                Console.WriteLine($"Size after compression: {ratio:F2}% of original");
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
 * 1. When a developer needs to archive high‑resolution medical scans in JPEG2000 format with lossless compression and verify how much storage space the compression saves.
 * 2. When a GIS application must store satellite imagery as lossless JPEG2000 files and compare the compressed size to the original to optimize bandwidth usage.
 * 3. When a digital asset management system requires converting existing JPEG2000 assets to a smaller lossless version using C# and Aspose.Imaging and log the percentage of size reduction.
 * 4. When an e‑learning platform wants to serve large textbook diagrams in lossless JPEG2000 to preserve detail, and the developer must measure the file‑size impact before deployment.
 * 5. When a printing workflow automates the preparation of artwork files in JPEG2000, applying lossless compression via Aspose.Imaging and checking the resulting file size to meet printer specifications.
 */