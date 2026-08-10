// HOW-TO: How To Apply Lossless Compression To JPEG2000 And Compare File Size In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.jp2";
            string outputPath = @"c:\temp\output_lossless.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the original JPEG2000 image
            using (Jpeg2000Image originalImage = new Jpeg2000Image(inputPath))
            {
                // Prepare lossless JPEG2000 options (Irreversible = false by default)
                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false, // Ensure lossless DWT 5-3 compression
                    Codec = Jpeg2000Codec.J2K // Use raw codestream format
                };

                // Save the image with lossless compression
                originalImage.Save(outputPath, options);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size   : {originalSize} bytes");
            Console.WriteLine($"Compressed size : {compressedSize} bytes");
            Console.WriteLine($"Size reduction  : {originalSize - compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to archive high‑resolution JPEG2000 images without quality loss while minimizing storage space.
 * 2. When you are building a medical‑imaging application that must store DICOM JPEG2000 scans losslessly and verify the size reduction.
 * 3. When a GIS system requires lossless compression of satellite JPEG2000 tiles before uploading them to a cloud repository.
 * 4. When you want to benchmark Aspose.Imaging’s lossless JPEG2000 codec against the original file size in a C# performance test.
 * 5. When an e‑learning platform must generate smaller, lossless JPEG2000 assets for offline delivery and report the saved bytes.
 */
