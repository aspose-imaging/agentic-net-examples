using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input TIFF path and output TIFF path.
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ImagingNet <input.tif> <output.tif>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the source TIFF image.
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF save options with LZW compression to reduce file size.
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw
                };

                // Save the image using the configured options.
                image.Save(outputPath, saveOptions);
            }

            Console.WriteLine($"Compressed TIFF saved to: {outputPath}");
        }
    }
}