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
            // Hardcoded output path
            string outputPath = "C:\\temp\\multiframe.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 200;
            int height = 200;

            // Common Tiff options for all frames
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Photometric = TiffPhotometrics.Rgb;

            // Create the first frame of the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Fill first frame with red color
                Aspose.Imaging.Color red = Aspose.Imaging.Color.FromArgb(255, 255, 0, 0);
                Aspose.Imaging.Color[] redPixels = new Aspose.Imaging.Color[width * height];
                for (int i = 0; i < redPixels.Length; i++)
                {
                    redPixels[i] = red;
                }
                tiffImage.SavePixels(tiffImage.Bounds, redPixels);

                // Add second frame
                tiffImage.AddFrame(new TiffFrame(tiffOptions, width, height));

                // Set active frame to the second frame
                tiffImage.ActiveFrame = tiffImage.Frames[1];

                // Fill second frame with green color
                Aspose.Imaging.Color green = Aspose.Imaging.Color.FromArgb(255, 0, 255, 0);
                Aspose.Imaging.Color[] greenPixels = new Aspose.Imaging.Color[width * height];
                for (int i = 0; i < greenPixels.Length; i++)
                {
                    greenPixels[i] = green;
                }
                tiffImage.SavePixels(tiffImage.Bounds, greenPixels);

                // Save the multi-frame TIFF
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
 * 1. When a developer needs to generate a multi‑page scanned document such as an invoice in TIFF format with lossless LZW compression to reduce file size while preserving full‑color fidelity.
 * 2. When a medical imaging application must create a multi‑frame TIFF where each frame uses a specific photometric interpretation (e.g., RGB for color slides and grayscale for X‑ray images) and store it efficiently with LZW compression.
 * 3. When a GIS system wants to bundle several raster map tiles into a single multi‑frame TIFF, applying custom photometric settings per tile and LZW compression for faster transmission.
 * 4. When an archival software solution needs to programmatically assemble a series of photographs into one TIFF file with per‑frame color profiles and LZW compression to meet preservation standards.
 * 5. When a document management workflow requires converting a set of PDF pages into a multi‑frame TIFF with custom photometric interpretation and LZW compression to ensure compatibility with legacy scanning hardware.
 */