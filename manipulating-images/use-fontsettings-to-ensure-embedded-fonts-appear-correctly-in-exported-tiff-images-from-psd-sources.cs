using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\source.psd";
        string outputPath = @"C:\Images\Export\result.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure font handling so that fonts used in the PSD are embedded in the TIFF
        // Set a folder that contains the required TrueType fonts (adjust as needed)
        Aspose.Imaging.FontSettings.SetFontsFolder(@"C:\Windows\Fonts");
        Aspose.Imaging.FontSettings.UpdateFonts();

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                // Example: preserve original dimensions and color depth
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Compression = TiffCompressions.Lzw,
                Photometric = TiffPhotometrics.Rgb,
                ByteOrder = TiffByteOrder.LittleEndian
            };

            // Save the image as TIFF with the configured options
            image.Save(outputPath, tiffOptions);
        }
    }
}