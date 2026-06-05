using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\photo.dng";
            string outputPath = "Output\\photo.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;

                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(dngImage))
                {
                    Jpeg2000Options options = new Jpeg2000Options
                    {
                        Irreversible = false // lossless compression
                    };
                    jpeg2000Image.Save(outputPath, options);
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
 * 1. When a photographer wants to convert raw DNG files captured with a DSLR into lossless JPEG2000 for archival storage while preserving full color detail via demosaicing in a C# application.
 * 2. When a medical imaging system needs to ingest DNG raw scans and output them as lossless JPEG2000 to meet DICOM compatibility requirements using Aspose.Imaging for .NET.
 * 3. When a web service processes user‑uploaded raw photos and generates high‑quality, bandwidth‑efficient JPEG2000 thumbnails for fast preview without quality loss.
 * 4. When a digital asset management tool batch‑converts raw DNG assets to lossless JPEG2000 to enable efficient indexing and searching while keeping original image fidelity.
 * 5. When a scientific research pipeline requires converting raw sensor data in DNG format to a lossless JPEG2000 format for long‑term storage and reproducible analysis in C#.
 */