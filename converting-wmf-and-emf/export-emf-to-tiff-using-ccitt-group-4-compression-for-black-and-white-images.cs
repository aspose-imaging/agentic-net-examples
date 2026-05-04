using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\input.emf";
            string outputPath = @"C:\Temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for CCITT Group 4 (Fax4) compression, 1-bit B/W
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 1 },
                    Compression = TiffCompressions.CcittFax4,
                    Photometric = TiffPhotometrics.MinIsBlack,
                    // Optional: set byte order, planar configuration if needed
                    ByteOrder = TiffByteOrder.LittleEndian,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save the image as TIFF with the specified options
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}