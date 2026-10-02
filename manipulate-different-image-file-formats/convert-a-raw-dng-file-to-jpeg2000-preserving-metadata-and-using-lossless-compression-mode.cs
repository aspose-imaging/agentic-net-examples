// HOW-TO: Convert DNG to JPEG2000 with Metadata Preservation in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.dng");
            string outputPath = Path.Combine("Output", "sample.jp2");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (Jpeg2000Options options = new Jpeg2000Options())
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
 * 1. When a photographer needs to archive raw DNG files as lossless JPEG2000 images while keeping EXIF and XMP metadata intact.
 * 2. When a digital asset management system must batch‑convert raw camera files to a web‑friendly JPEG2000 format without losing image quality.
 * 3. When a scientific imaging application requires converting RAW sensor data to JPEG2000 for long‑term storage while preserving calibration metadata.
 * 4. When a printing workflow needs to transform DNG files into JPEG2000 for high‑resolution proofing while retaining all embedded metadata.
 * 5. When a mobile app developer wants to support DNG uploads and store them as lossless JPEG2000 files on the server using Aspose.Imaging for .NET.
 */
