using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path and password
            string inputPath = "input.jpg";
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

                // Determine the concrete type to call IsDigitalSigned
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
 * 1. When a developer needs to confirm that a received JPEG file from a client is digitally signed before processing it further in a C# web service.
 * 2. When an application must validate the authenticity of scanned documents stored as JPEG images by checking the digital signature with a password during batch import.
 * 3. When a secure image archiving system loads JPEG images from a file stream and verifies their digital signature to ensure they have not been tampered with.
 * 4. When a desktop utility reads JPEG photos from a user‑selected folder and reports whether each image is digitally signed using Aspose.Imaging in .NET.
 * 5. When a cloud‑based workflow validates uploaded JPEG assets by loading them from a stream and using a password‑protected digital signature check before allowing them to be published.
 */