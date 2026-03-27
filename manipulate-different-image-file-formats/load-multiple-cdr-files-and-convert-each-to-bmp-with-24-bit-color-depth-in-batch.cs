using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input CDR files
        string[] inputPaths = new string[]
        {
            @"C:\input\file1.cdr",
            @"C:\input\file2.cdr"
        };

        // Hardcoded output directory
        string outputDirectory = @"C:\output";

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output BMP path (same name, .bmp extension)
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image cdrImage = Image.Load(inputPath))
            {
                // Convert to 24‑bpp BMP
                using (BmpImage bmpImage = new BmpImage((RasterImage)cdrImage, 24, BitmapCompression.Rgb, 96.0, 96.0))
                {
                    // Save the BMP file
                    bmpImage.Save(outputPath);
                }
            }
        }
    }
}