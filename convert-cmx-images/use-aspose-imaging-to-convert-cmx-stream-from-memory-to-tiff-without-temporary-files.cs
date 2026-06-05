using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected errors
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Temp\sample.cmx";
            string outputPath = @"C:\Temp\sample.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image from a memory stream (no temporary files)
            byte[] cmxData = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(cmxData))
            {
                // StreamContainer wraps the memory stream for Aspose.Imaging
                var streamContainer = new StreamContainer(memoryStream);
                var loadOptions = new CmxLoadOptions();

                // Initialize CmxImage with the stream container and load options
                using (var cmxImage = new CmxImage(streamContainer, loadOptions))
                {
                    // Prepare TIFF save options
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        BitsPerSample = new ushort[] { 8, 8, 8 },
                        Compression = TiffCompressions.Lzw,
                        Photometric = TiffPhotometrics.Rgb,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous
                    };

                    // Save directly to the output file path using the TIFF options
                    cmxImage.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}