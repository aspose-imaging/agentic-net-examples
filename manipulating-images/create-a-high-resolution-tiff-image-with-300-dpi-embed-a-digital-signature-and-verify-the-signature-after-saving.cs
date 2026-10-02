// HOW-TO: Create High Resolution 300 DPI TIFF with Digital Signature in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.tiff";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = source };
            int width = 2000;
            int height = 2000;
            string password = "Secret123";

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                tiffImage.HorizontalResolution = 300;
                tiffImage.VerticalResolution = 300;
                ((RasterImage)tiffImage).EmbedDigitalSignature(password);
                tiffImage.Save();
            }

            using (RasterImage loadedImage = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = loadedImage.IsDigitalSigned(password);
                Console.WriteLine($"Signature verification: {(isSigned ? "Valid" : "Invalid")}");
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
 * 1. When you need to generate a high‑resolution 300 DPI TIFF for printing and ensure its authenticity by embedding a password‑protected digital signature.
 * 2. When a medical imaging application must create diagnostic TIFF files that can be verified later to prevent tampering.
 * 3. When an archival system stores scanned documents as TIFFs and requires a built‑in signature to prove the files haven’t been altered.
 * 4. When a GIS tool exports large raster maps to TIFF and wants to embed a signature so downstream users can confirm the source.
 * 5. When a legal document workflow creates TIFF evidence files and needs to programmatically sign and later validate them in C#.
 */
