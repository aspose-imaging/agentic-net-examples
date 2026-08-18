// HOW-TO: Add Custom Photometric TIFF Frame and Save with JPEG Compression in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create options for the new frame with a custom photometric interpretation
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Photometric = TiffPhotometrics.MinIsBlack; // custom photometric
                frameOptions.BitsPerSample = new ushort[] { 1 }; // 1-bit per sample for B/W

                // Create a new frame (e.g., 100x100 pixels)
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Fill the new frame with a simple black‑to‑white gradient
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(newFrame.Width, newFrame.Height),
                    Color.Black,
                    Color.White);

                Graphics graphics = new Graphics(newFrame);
                graphics.FillRectangle(brush, newFrame.Bounds);

                // Add the new frame to the existing TIFF image
                tiffImage.AddFrame(newFrame);

                // Prepare save options using JPEG compression
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                saveOptions.CompressedQuality = 80; // optional quality setting

                // Save the updated TIFF image
                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When you need to insert a black‑to‑white gradient page into an existing multi‑page TIFF document while specifying a MinIsBlack photometric interpretation.
 * 2. When you want to create a 1‑bit per sample TIFF frame for low‑size archival storage and then compress the whole file using JPEG to reduce disk usage.
 * 3. When a scanning application must add a custom photometric TIFF page to a multi‑page scan and output the result as a JPEG‑compressed TIFF for faster web delivery.
 * 4. When you are building a medical imaging workflow that requires adding a binary mask layer to a TIFF series and saving the final file with JPEG compression for compatibility with PACS systems.
 * 5. When you need to programmatically modify a TIFF file in C# by adding a new frame with specific photometric settings and then compress the updated image for transmission over a network.
 */
