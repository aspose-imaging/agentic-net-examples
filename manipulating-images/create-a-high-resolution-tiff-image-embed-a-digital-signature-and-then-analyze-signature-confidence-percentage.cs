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
            // Define output path
            string outputPath = "output.tif";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create TIFF options for the frame
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            frameOptions.Compression = TiffCompressions.Lzw;
            frameOptions.Photometric = TiffPhotometrics.Rgb;
            frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Define high resolution dimensions
            int width = 2000;
            int height = 2000;

            // Create a TIFF frame
            TiffFrame frame = new TiffFrame(frameOptions, width, height);

            // Fill the frame with a gradient
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame.Width, frame.Height),
                Color.Blue,
                Color.Yellow);
            Graphics graphics = new Graphics(frame);
            graphics.FillRectangle(gradientBrush, frame.Bounds);

            // Create TIFF image from the frame
            using (TiffImage tiffImage = new TiffImage(frame))
            {
                // Embed digital signature with a valid password
                tiffImage.ActiveFrame.EmbedDigitalSignature("secure123");

                // Analyze signature confidence percentage
                double confidence = tiffImage.ActiveFrame.AnalyzePercentageDigitalSignature("secure123");
                Console.WriteLine($"Signature confidence: {confidence}%");

                // Save the TIFF image
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
 * 1. When a medical imaging system must generate a high‑resolution TIFF scan of a pathology slide, embed a tamper‑proof digital signature, and verify the signature confidence before storing the file.
 * 2. When a government agency creates archival satellite photographs in TIFF format, signs them with a password‑protected digital signature, and checks the confidence percentage to ensure authenticity for legal records.
 * 3. When a publishing workflow produces print‑ready magazine pages as high‑resolution TIFFs, adds a digital signature to prevent unauthorized modifications, and validates the signature confidence to guarantee content integrity.
 * 4. When an engineering firm exports detailed CAD drawings as TIFF images, embeds a secure digital signature for client delivery, and evaluates the confidence metric to confirm the signature was applied correctly.
 * 5. When a financial institution generates high‑resolution scanned checks in TIFF, signs them digitally to comply with e‑check regulations, and analyzes the confidence percentage to detect any signature corruption before processing.
 */