// HOW-TO: Convert JPEG to LZW Compressed TIFF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.jpg";
            string outputPath = "C:\\temp\\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.ByteOrder = TiffByteOrder.BigEndian;
                tiffOptions.Compression = TiffCompressions.Lzw;
                tiffOptions.Predictor = TiffPredictor.Horizontal;
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

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

/*
 * Real-World Use Cases:
 * 1. When you need to archive high‑resolution photographs while reducing file size, you can convert JPEG files to LZW‑compressed TIFF using C# and Aspose.Imaging.
 * 2. When a document management system requires TIFF images with lossless compression for reliable printing, this code creates the required format from existing JPEGs.
 * 3. When migrating legacy image assets to a format that supports metadata and lossless storage, developers can use this snippet to batch‑convert JPEGs to LZW‑compressed TIFFs.
 * 4. When implementing a web service that receives user‑uploaded JPEGs and stores them as compact TIFF files for long‑term retention, the code provides the conversion logic.
 * 5. When preparing images for scientific analysis that demands TIFF’s planar configuration and LZW compression to balance quality and storage efficiency, this example performs the conversion in C#.
 */
