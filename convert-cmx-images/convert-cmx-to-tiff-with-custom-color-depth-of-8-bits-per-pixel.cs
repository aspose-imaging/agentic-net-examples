using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.cmx";
        string outputPath = @"c:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Configure TIFF save options for 8 bits per color component
            var tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 8, 8, 8 },                         // 8 bits per channel (24‑bit color)
                Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb,
                Compression = Aspose.Imaging.FileFormats.Tiff.Enums.TiffCompressions.Lzw,
                PlanarConfiguration = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPlanarConfigs.Contiguous,
                ByteOrder = Aspose.Imaging.FileFormats.Tiff.Enums.TiffByteOrder.BigEndian
            };

            // Save as TIFF using the configured options
            cmxImage.Save(outputPath, tiffOptions);
        }
    }
}