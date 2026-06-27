using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.tif";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
            {
                Graphics graphics = new Graphics(tiffImage);
                graphics.Clear(Color.White);

                tiffImage.EmbedDigitalSignature("secure123");
                tiffImage.Rotate(45f, true, Color.Gray);

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
 * 1. When a developer needs to generate a TIFF document that includes a tamper‑evident digital signature for secure archival and must rotate the page 45° with a gray fill to meet printing specifications.
 * 2. When an application must create a 200 × 200 pixel raster image in the TIFF format, embed a password‑protected signature, and apply a 45‑degree rotation while preserving the background color for compliance with medical imaging standards.
 * 3. When a workflow requires programmatically producing a LZW‑compressed RGB TIFF file, adding a custom security tag, and rotating the canvas to align with landscape layouts used in GIS mapping tools.
 * 4. When a document management system needs to store scanned forms as TIFF files, embed a unique identifier as a digital signature, and rotate the image to correct skew with a gray background for visual consistency.
 * 5. When a developer is building a C# service that automatically creates signed TIFF images, applies a 45° rotation with a gray background to match corporate branding, and saves the result to a file system for downstream processing.
 */