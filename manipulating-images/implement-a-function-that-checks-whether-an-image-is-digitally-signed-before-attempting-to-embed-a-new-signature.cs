using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";
        string password = "myPassword";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                if (image is RasterImage rasterImage)
                {
                    // Check if the image is already digitally signed
                    bool isSigned = rasterImage.IsDigitalSigned(password);

                    if (isSigned)
                    {
                        Console.WriteLine("Image is already digitally signed. No action taken.");
                    }
                    else
                    {
                        // Embed a new digital signature
                        rasterImage.EmbedDigitalSignature(password);
                        // Save the modified image
                        rasterImage.Save(outputPath);
                        Console.WriteLine($"Digital signature embedded and image saved to {outputPath}");
                    }
                }
                else
                {
                    Console.Error.WriteLine("Loaded image does not support digital signature operations.");
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
 * 1. When a C# application must verify that a PNG file uploaded by a user hasn't already been digitally signed before adding a new signature for compliance auditing.
 * 2. When an automated workflow processes scanned documents and needs to ensure each image is unsigned before embedding a password‑protected digital signature using Aspose.Imaging.
 * 3. When a secure image storage service wants to prevent duplicate signatures by checking the IsDigitalSigned flag on a RasterImage before saving the signed version.
 * 4. When a desktop utility that batch‑processes PNG assets must skip images that already contain a digital signature to avoid corrupting existing authentication data.
 * 5. When integrating image authentication into a .NET API, developers use this code to confirm an image is unsigned before calling EmbedDigitalSignature to protect the file with a password.
 */