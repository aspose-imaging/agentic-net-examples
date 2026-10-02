// HOW-TO: Convert CorelDRAW CDR to TIFF with LZW Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (TiffOptions options = new TiffOptions(TiffExpectedFormat.Default))
                {
                    options.Compression = TiffCompressions.Lzw;
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
 * 1. When you need to archive vector drawings from CorelDRAW as lossless TIFF files for long‑term storage.
 * 2. When a printing workflow requires CDR artwork to be supplied as TIFF images with LZW compression to reduce file size without quality loss.
 * 3. When converting design assets for a document management system that only accepts TIFF format but must preserve the original colors.
 * 4. When generating thumbnails or previews of CDR files for a web gallery and want the TIFF output to be efficiently compressed.
 * 5. When integrating CorelDRAW files into a .NET application that processes images and needs them in a TIFF format compatible with other imaging libraries.
 */
