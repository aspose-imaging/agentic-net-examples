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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

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
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Custom dimensions for the new frame
                int newWidth = 200;
                int newHeight = 150;

                // Create the new TIFF frame
                TiffFrame newFrame = new TiffFrame(frameOptions, newWidth, newHeight);

                // Fill the frame with a gradient (optional visual content)
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(newFrame.Width, newFrame.Height),
                    Color.Blue,
                    Color.Yellow);
                Graphics graphics = new Graphics(newFrame);
                graphics.FillRectangle(brush, newFrame.Bounds);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Set specific resolution (DPI) for the TIFF image
                tiffImage.HorizontalResolution = 300;
                tiffImage.VerticalResolution = 300;

                // Save the updated TIFF image
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
 * 1. When a developer needs to generate a multi‑page TIFF document for archival purposes and wants each page to be compressed with LZW to reduce file size while preserving image quality.
 * 2. When creating a high‑resolution satellite image mosaic where each tile is added as a separate TIFF frame with custom width and height to match the geographic grid.
 * 3. When building a medical imaging application that appends additional DICOM‑derived scans to an existing TIFF file, using LZW compression and specific DPI settings for accurate measurements.
 * 4. When producing a printable product catalog where each product photo is inserted as a new TIFF frame with exact dimensions and resolution to meet pre‑press specifications.
 * 5. When developing a document management system that scans multi‑page contracts into a single TIFF file, adding each scanned page as a new frame with LZW compression to optimize storage and maintain consistent resolution across pages.
 */