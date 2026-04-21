using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (guard against null/empty)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load existing TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Configure options for the new frame
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                frameOptions.Xresolution = new TiffRational(300, 1); // 300 DPI horizontal
                frameOptions.Yresolution = new TiffRational(300, 1); // 300 DPI vertical

                // Create a new frame with custom dimensions
                int newWidth = 200;
                int newHeight = 200;
                TiffFrame newFrame = new TiffFrame(frameOptions, newWidth, newHeight);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the modified TIFF image
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}