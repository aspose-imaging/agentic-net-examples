using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded collection of source TIFF files (could be any supported format)
        string[] inputPaths = new string[]
        {
            @"C:\Images\Input1.tif",
            @"C:\Images\Input2.tif",
            @"C:\Images\Input3.tif"
        };

        // Corresponding output paths – same folder, different file name suffix
        string[] outputPaths = new string[]
        {
            @"C:\Images\Output\Result1.tif",
            @"C:\Images\Output\Result2.tif",
            @"C:\Images\Output\Result3.tif"
        };

        // Iterate over the collection
        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Input file existence check – no exceptions, just return on failure
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (unconditional call)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF export options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    // Example settings – can be adjusted as needed
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.LittleEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save the image to the target path with the specified options
                image.Save(outputPath, tiffOptions);
            }
        }
    }
}