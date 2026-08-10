// HOW-TO: Verify JPEG Digital Signature From Stream With Password In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = "input.jpg";
            // Password used for digital signature verification
            string password = "myPassword";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load JPEG image from a file stream
            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (Image image = Image.Load(stream))
            {
                bool isSigned = false;

                // Determine the concrete image type that supports digital signature checking
                if (image is RasterImage rasterImage)
                {
                    isSigned = rasterImage.IsDigitalSigned(password);
                }
                else if (image is RasterCachedImage cachedImage)
                {
                    isSigned = cachedImage.IsDigitalSigned(password);
                }
                else if (image is RasterCachedMultipageImage multiPageImage)
                {
                    isSigned = multiPageImage.IsDigitalSigned(password);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image type for digital signature verification.");
                    return;
                }

                // Output verification result
                Console.WriteLine(isSigned
                    ? "Image is digitally signed."
                    : "Image is NOT digitally signed.");
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
 * 1. When you need to confirm that a received JPEG file has not been tampered with before processing it in a C# application.
 * 2. When an enterprise workflow requires validating digitally signed images uploaded via a web service using a known password.
 * 3. When integrating secure image storage, you must check the digital signature of JPEGs stored in a database before displaying them to users.
 * 4. When building a desktop utility that scans a folder of JPEGs and reports which ones are digitally signed using a password.
 * 5. When implementing compliance checks that ensure all product photos contain a valid digital signature before they are published online.
 */
