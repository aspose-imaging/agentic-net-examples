using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputWebPPath = @"c:\temp\input.webp";
        string intermediateBmpPath = @"c:\temp\intermediate.bmp";
        string outputTiffPath = @"c:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputWebPPath))
        {
            Console.Error.WriteLine($"File not found: {inputWebPPath}");
            return;
        }

        // Load WebP image and save as BMP
        using (WebPImage webPImage = new WebPImage(inputWebPPath))
        {
            // Ensure the directory for the BMP exists
            Directory.CreateDirectory(Path.GetDirectoryName(intermediateBmpPath));

            // Save to BMP using default BMP options
            webPImage.Save(intermediateBmpPath, new BmpOptions());
        }

        // Verify the BMP was created before proceeding
        if (!File.Exists(intermediateBmpPath))
        {
            Console.Error.WriteLine($"File not found: {intermediateBmpPath}");
            return;
        }

        // Load the BMP image
        using (Image bmpImage = Image.Load(intermediateBmpPath))
        {
            // Prepare TIFF options with LZW compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Lzw,
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb,
                ByteOrder = Aspose.Imaging.FileFormats.Tiff.Enums.TiffByteOrder.LittleEndian,
                PlanarConfiguration = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPlanarConfigs.Contiguous
            };

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // Save BMP as TIFF with LZW compression
            bmpImage.Save(outputTiffPath, tiffOptions);
        }
    }
}