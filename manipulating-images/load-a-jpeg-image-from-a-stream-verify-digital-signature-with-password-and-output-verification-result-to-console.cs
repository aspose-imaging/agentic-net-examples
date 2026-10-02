// HOW-TO: Verify JPEG Digital Signature From Stream With Password In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string password = "yourPassword";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (RasterImage image = (RasterImage)Image.Load(stream))
                {
                    bool isSigned = image.IsDigitalSigned(password);
                    Console.WriteLine(isSigned ? "Image is digitally signed." : "Image is NOT digitally signed.");
                }
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
 * 1. When a web application receives uploaded JPEG files and must confirm they are authentic and untampered before processing them.
 * 2. When a desktop utility needs to batch‑check scanned JPEG documents for a valid digital signature using a known password.
 * 3. When a secure archiving system validates that archived JPEG images retain their original digital signature before allowing download.
 * 4. When a compliance tool verifies that product photos embedded with a password‑protected digital signature meet regulatory audit requirements.
 * 5. When a cloud service reads JPEG images from a stream and needs to programmatically report whether the image is digitally signed to trigger further workflow steps.
 */
