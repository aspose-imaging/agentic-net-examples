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
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the input image as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Options for the TIFF image (first frame)
                TiffOptions imageOptions = new TiffOptions(TiffExpectedFormat.Default);
                imageOptions.Compression = TiffCompressions.Lzw;
                imageOptions.Photometric = TiffPhotometrics.Rgb;
                imageOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                imageOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Create a multi‑frame TIFF image with a default frame matching the raster size
                using (TiffImage tiffImage = (TiffImage)Image.Create(imageOptions, raster.Width, raster.Height))
                {
                    // Options for the custom frame with a different photometric interpretation
                    TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                    frameOptions.Compression = TiffCompressions.Lzw;
                    frameOptions.Photometric = TiffPhotometrics.MinIsBlack; // Custom photometric
                    frameOptions.BitsPerSample = new ushort[] { 1 }; // 1‑bit per pixel
                    frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                    // Create a new TIFF frame from the raster image using the custom options
                    TiffFrame customFrame = new TiffFrame(raster, frameOptions);

                    // Add the custom frame to the TIFF image
                    tiffImage.AddFrame(customFrame);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the multi‑frame TIFF image
                    tiffImage.Save(outputPath);
                }
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
 * 1. When a developer needs to archive scanned documents as a multi‑frame TIFF with lossless LZW compression while storing a binary (black‑and‑white) thumbnail using the MinIsBlack photometric interpretation.
 * 2. When an imaging application must combine a full‑color PNG preview and a 1‑bit mask layer into a single TIFF file for efficient storage and easy retrieval in medical imaging systems.
 * 3. When a GIS tool requires saving satellite imagery alongside a low‑resolution elevation mask in the same TIFF container, using different photometric settings for each frame.
 * 4. When a digital archiving workflow has to generate a multi‑page TIFF where the first page retains the original RGB colors and subsequent pages are stored as monochrome bitmaps to reduce file size.
 * 5. When a document management system needs to create a searchable TIFF bundle that includes a color cover page and a black‑text page, applying LZW compression to keep the file size small while preserving image fidelity.
 */