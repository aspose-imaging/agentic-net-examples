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
            string outputPath = "output\\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load existing TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Configure options for the new frame
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Deflate;
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Create a new blank frame (100x100 pixels) with the specified options
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the updated TIFF to the output path
                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to append a blank 100 × 100 pixel page to an existing multi‑page TIFF file while using Deflate compression to keep the file size low.
 * 2. When building a document‑scanning workflow in C# that must add a new scanned page to a TIFF archive without re‑encoding the original pages.
 * 3. When creating a multi‑resolution TIFF where each additional frame is stored with RGB photometric and contiguous planar configuration for compatibility with imaging software.
 * 4. When generating a TIFF‑based report that requires inserting a placeholder frame for later image data, ensuring the new frame uses the same bit depth (8‑bit per channel) as the rest of the document.
 * 5. When implementing a server‑side image processing service that must dynamically add frames to uploaded TIFF files while preserving custom compression settings using Aspose.Imaging for .NET.
 */