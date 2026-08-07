using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (ensure directory part exists)
            string outputPath = "output/output.tif";

            // Create output directory
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create a new TIFF image (200x200)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
            {
                // Fill the image with a red‑to‑blue gradient
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(tiffImage.Width, tiffImage.Height),
                    Color.Red,
                    Color.Blue);
                Graphics graphics = new Graphics(tiffImage);
                graphics.FillRectangle(brush, tiffImage.Bounds);

                // Embed a digital signature using a valid password
                tiffImage.EmbedDigitalSignature("secure123");

                // Rotate 45 degrees, resize canvas proportionally, gray background
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
 * 1. When a developer needs to create a 200×200 TIFF image with a red‑to‑blue gradient, embed a password‑protected digital signature, rotate it 45° with a gray background, and save it for secure archival of scanned documents.
 * 2. When a developer must programmatically generate a signed TIFF file for legal contracts that require a visual gradient watermark and a 45° rotation to meet specific layout guidelines.
 * 3. When a developer wants to produce a TIFF image for a medical imaging system that includes a gradient illustration, a digital signature for authenticity, and a rotated orientation to match device display requirements.
 * 4. When a developer is building an automated pipeline that creates signed TIFF assets for publishing, applying a 45° rotation with a gray canvas to ensure consistent presentation across different viewers.
 * 5. When a developer needs to embed a digital signature into a TIFF graphic, rotate it 45° with a gray background, and store the result using Aspose.Imaging in a .NET application that handles secure image processing.
 */