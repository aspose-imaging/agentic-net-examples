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
            string inputPath = "input.jp2";
            string outputPath = "output_lossless.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Jpeg2000Image image = new Jpeg2000Image(inputPath))
            {
                Jpeg2000Options options = new Jpeg2000Options();
                options.Irreversible = false; // Ensure lossless compression

                image.Save(outputPath, options);
            }

            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed (lossless) size: {compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application must store DICOM scans as JPEG2000 files without losing diagnostic detail, a developer can use this code to apply lossless compression and verify the reduced file size.
 * 2. When an archival system for cultural‑heritage photographs needs to preserve original quality while minimizing storage costs, a developer can run this routine to compress JPEG2000 images losslessly and compare the saved space.
 * 3. When a satellite‑imagery processing pipeline requires transmitting high‑resolution images without quality degradation, a developer can employ this example to create a lossless JPEG2000 payload and measure the bandwidth savings.
 * 4. When a digital publishing platform wants to embed losslessly compressed JPEG2000 graphics in e‑books and ensure the files meet device size constraints, a developer can use the code to compress and report the size difference.
 * 5. When a compliance audit demands proof that image assets are stored in a lossless format, a developer can automate the conversion and size comparison with this snippet to demonstrate that the JPEG2000 files retain visual fidelity while being smaller.
 */