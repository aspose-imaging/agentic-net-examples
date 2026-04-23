using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = new string[]
            {
                @"C:\input\file1.cdr",
                @"C:\input\file2.cdr"
            };

            string[] outputPaths = new string[]
            {
                @"C:\output\file1.tif",
                @"C:\output\file2.tif"
            };

            // Process each file
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    var loadOptions = new CdrLoadOptions(); // default options
                    using (var cdrImage = new Aspose.Imaging.FileFormats.Cdr.CdrImage(stream, loadOptions))
                    {
                        // Configure TIFF save options with LZW compression
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            BitsPerSample = new ushort[] { 8, 8, 8 },
                            ByteOrder = TiffByteOrder.BigEndian,
                            Compression = TiffCompressions.Lzw,
                            Photometric = TiffPhotometrics.Rgb,
                            PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                            Predictor = TiffPredictor.Horizontal
                        };

                        // Save as TIFF
                        cdrImage.Save(outputPath, tiffOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}