using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"C:\Images\frame1.tif";
            string inputPath2 = @"C:\Images\frame2.tif";

            // Hardcoded output file path
            string outputPath = @"C:\Images\combined.tif";

            // Verify that each input file exists
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define options for the first frame (LZW compression)
            TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
            options1.Compression = TiffCompressions.Lzw;
            options1.BitsPerSample = new ushort[] { 8, 8, 8 };
            options1.Photometric = TiffPhotometrics.Rgb;
            options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Define options for the second frame (CCITT Group 3 Fax compression)
            TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
            options2.Compression = TiffCompressions.CcittFax3;
            options2.BitsPerSample = new ushort[] { 1 };
            options2.Photometric = TiffPhotometrics.MinIsBlack;
            options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Load each source image as a TiffFrame using its specific options
            TiffFrame frame1 = new TiffFrame(inputPath1, options1);
            TiffFrame frame2 = new TiffFrame(inputPath2, options2);

            // Create a new multi‑frame TIFF image starting with the first frame
            using (TiffImage tiffImage = new TiffImage(frame1))
            {
                // Append the second frame
                tiffImage.AddFrame(frame2);

                // Save the combined TIFF to the output path
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}