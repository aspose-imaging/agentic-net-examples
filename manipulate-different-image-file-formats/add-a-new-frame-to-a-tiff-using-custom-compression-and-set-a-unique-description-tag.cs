using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
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

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load existing TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Configure options for the new frame
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Compression = TiffCompressions.Lzw; // Custom compression
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Set a unique description tag (placeholder - adjust according to actual API)
                // Example: frameOptions.AddTag(new TiffAsciiTag(TiffTags.ImageDescription, "Added frame"));
                // If AddTag overload differs, replace with appropriate call.

                // Create a new frame (100x100 pixels) with the above options
                using (TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100))
                {
                    // Fill the new frame with a solid color (e.g., light gray)
                    SolidBrush brush = new SolidBrush(Color.LightGray);
                    Graphics graphics = new Graphics(newFrame);
                    graphics.FillRectangle(brush, newFrame.Bounds);

                    // Add the new frame to the TIFF image
                    tiffImage.AddFrame(newFrame);
                }

                // Save the modified TIFF image to the output path
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
 * 1. When a medical imaging application needs to append a new diagnostic scan to an existing multi‑page DICOM‑derived TIFF while using LZW compression to keep file size low and adding a unique description tag for patient metadata.
 * 2. When a digital archiving system must add a thumbnail preview as an extra frame to a high‑resolution scanned document TIFF, applying custom RGB photometric settings and embedding a caption tag for easy cataloging.
 * 3. When a GIS (Geographic Information System) tool wants to insert an updated map layer into a multi‑page satellite imagery TIFF, using contiguous planar configuration and a descriptive tag that records the capture date and sensor information.
 * 4. When a publishing workflow requires adding a color‑corrected proof page to a multi‑page magazine TIFF, employing LZW compression for faster transmission and setting an image description tag that identifies the proof version.
 * 5. When an e‑commerce platform generates product catalogs as multi‑page TIFFs and needs to append a new product photo frame with custom compression and a description tag that contains SKU and pricing details.
 */