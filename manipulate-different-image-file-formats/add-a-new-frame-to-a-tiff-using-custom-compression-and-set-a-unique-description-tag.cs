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
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.tif";

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
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Create a new frame (100x100 pixels) with the above options
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the modified TIFF to the output path
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
 * 1. When a developer needs to create a multi‑page TIFF for a document scanning workflow and wants each page compressed with LZW to reduce file size.
 * 2. When an imaging application must append a thumbnail or preview image to an existing TIFF without re‑encoding the original pages.
 * 3. When a medical imaging system stores additional diagnostic images in a single TIFF container and requires RGB photometric interpretation with contiguous planar configuration.
 * 4. When a GIS tool adds a new raster layer to a geospatial TIFF dataset while preserving 8‑bit per channel color depth.
 * 5. When a digital archiving solution programmatically updates a TIFF archive by inserting a new frame and saving the result to a network share.
 */