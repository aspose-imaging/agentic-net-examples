using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

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

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Resize using Lanczos resampling
                image.Resize(image.Width / 2, image.Height / 2, ResizeType.LanczosResample);

                // Embed digital signature with a password longer than four characters
                image.EmbedDigitalSignature("secure123");

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When a developer needs to halve the dimensions of a high‑resolution TIFF scan (such as a legal contract) using Lanczos resampling and then protect the file with a password‑protected digital signature longer than four characters.
 * 2. When an application must prepare medical TIFF images for faster transmission by resizing them with Lanczos and ensuring authenticity by embedding a secure digital signature.
 * 3. When a GIS system processes large satellite TIFF tiles, reduces their size for web mapping using Lanczos, and adds a tamper‑evident digital signature to meet compliance requirements.
 * 4. When an engineering firm wants to archive detailed CAD drawings saved as multi‑page TIFFs, compress the pages by resizing and embed a strong password‑protected digital signature to prevent unauthorized modifications.
 * 5. When a document management workflow automatically converts scanned TIFF invoices to a smaller format for storage and adds a digital signature with a robust password to guarantee the invoice’s integrity.
 */