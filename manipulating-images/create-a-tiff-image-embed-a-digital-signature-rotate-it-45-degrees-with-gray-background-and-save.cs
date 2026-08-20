// HOW-TO: Create TIFF with Digital Signature and Rotate 45 Degrees in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output.tif";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Configure TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;

            // Create a 200x200 TIFF image (minimum size for digital signature)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
            {
                // Fill the image with a blue‑yellow gradient
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(tiffImage.Width, tiffImage.Height),
                    Color.Blue,
                    Color.Yellow);
                Graphics graphics = new Graphics(tiffImage);
                graphics.FillRectangle(brush, tiffImage.Bounds);

                // Embed a digital signature (password must be at least 4 characters)
                tiffImage.EmbedDigitalSignature("secure123");

                // Rotate 45 degrees with gray background, resizing proportionally
                tiffImage.Rotate(45f, true, Color.Gray);

                // Save the image (output path already bound via FileCreateSource)
                tiffImage.Save();
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
 * 1. When you need to generate a secure TIFF document that includes a digital signature for legal or archival purposes.
 * 2. When you want to programmatically add a gradient background to a TIFF file before applying security features.
 * 3. When an application must rotate scanned images by 45 degrees while preserving image quality and filling empty space with a gray background.
 * 4. When you require automated creation of LZW‑compressed TIFF files with specific bit depth and byte order for compatibility with legacy systems.
 * 5. When a workflow demands embedding a password‑protected digital signature into a TIFF image and then saving it to a predefined folder.
 */
