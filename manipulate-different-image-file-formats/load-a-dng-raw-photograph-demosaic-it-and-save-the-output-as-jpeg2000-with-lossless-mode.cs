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

            using (Image img = Image.Load(inputPath))
            {
                DngImage dng = (DngImage)img;

                using (Jpeg2000Image jp2 = new Jpeg2000Image(dng))
                {
                    using (Jpeg2000Options options = new Jpeg2000Options())
                    {
                        options.Irreversible = false; // lossless compression
                        jp2.Save(outputPath, options);
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
 * 1. When a photography studio needs to convert raw DNG files from a high‑resolution camera into lossless JPEG2000 images for archival storage while preserving color fidelity using C# and Aspose.Imaging.
 * 2. When a medical imaging application must demosaic raw DNG scans of tissue samples and save them as lossless JPEG2000 files for secure transmission and compliance with DICOM standards.
 * 3. When a digital asset management system requires automated batch processing of raw DNG photographs into JPEG2000 format with lossless compression to reduce file size without sacrificing quality.
 * 4. When a scientific research project needs to programmatically load DNG raw satellite imagery, perform demosaicing, and export it as a lossless JPEG2000 image for further analysis in .NET.
 * 5. When a web service that delivers high‑quality print‑ready images must convert client‑uploaded DNG files to lossless JPEG2000 using Aspose.Imaging in C# to ensure consistent color and detail across platforms.
 */