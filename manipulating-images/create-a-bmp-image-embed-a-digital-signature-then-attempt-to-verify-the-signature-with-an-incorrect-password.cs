// HOW-TO: Create BMP Image With Digital Signature And Verify Using Wrong Password In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                canvas.EmbedDigitalSignature("secure123");
                canvas.Save();
            }

            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (RasterImage loaded = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = loaded.IsDigitalSigned("123");
                Console.WriteLine($"Signature valid with incorrect password: {isSigned}");
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
 * 1. When you need to embed a password‑protected digital signature into a BMP file to guarantee its integrity.
 * 2. When you want to programmatically create a bitmap, sign it, and then confirm that verification fails if an incorrect password is supplied.
 * 3. When you are developing a C# application that must generate secure BMP assets and enforce authentication before they can be used.
 * 4. When you are testing Aspose.Imaging’s digital signature API for BMP images by creating, signing, and validating the image in code.
 * 5. When you are debugging signature validation logic by deliberately providing a wrong password to see the expected false result.
 */
