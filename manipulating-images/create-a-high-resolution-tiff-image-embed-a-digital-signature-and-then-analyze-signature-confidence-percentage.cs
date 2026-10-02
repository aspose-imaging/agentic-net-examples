// HOW-TO: Create High Resolution TIFF with Digital Signature in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\highres.tiff";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 3000;
            int height = 2000;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                RasterImage raster = (RasterImage)tiffImage;
                int[] whitePixels = new int[width * height];
                for (int i = 0; i < whitePixels.Length; i++)
                {
                    whitePixels[i] = unchecked((int)0xFFFFFFFF);
                }
                raster.SaveArgb32Pixels(raster.Bounds, whitePixels);

                string password = "secure123";
                raster.EmbedDigitalSignature(password);

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
 * 1. When you need to generate a large‑format TIFF for printing and protect it from tampering by embedding a password‑protected digital signature.
 * 2. When a document management system must store scanned documents as high‑resolution TIFF files and ensure authenticity using Aspose.Imaging’s signature feature.
 * 3. When an archival workflow requires creating white‑background TIFF canvases of specific dimensions and embedding a cryptographic signature for later verification.
 * 4. When a medical imaging application needs to produce DICOM‑compatible TIFF images and attach a secure digital signature to meet compliance standards.
 * 5. When a legal software solution must programmatically create high‑quality TIFF evidence files and embed a signer’s password to prove integrity.
 */
