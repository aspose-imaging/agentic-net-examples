using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Configure high‑quality JPEG options
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 100,
                CompressionType = JpegCompressionMode.Progressive,
                // Set vector rasterization options for proper rendering of the vector image
                VectorRasterizationOptions = (VectorRasterizationOptions)cdr.GetDefaultOptions(
                    new object[] { Color.White, cdr.Width, cdr.Height })
            };

            // Save as JPEG
            cdr.Save(outputPath, jpegOptions);
        }
    }
}