// HOW-TO: Create BMP Image with Digital Signature and Verify Password in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "signed_image.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a blank BMP image
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 200, 200))
            {
                // Fill with white color
                int[] whitePixels = Enumerable.Repeat(unchecked((int)0xFFFFFFFF), 200 * 200).ToArray();
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, 200, 200), whitePixels);

                // Embed digital signature
                string correctPassword = "Secret123";
                canvas.EmbedDigitalSignature(correctPassword);

                // Save the image (bound to file)
                canvas.Save();
            }

            // Verify with correct password
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (RasterImage signedImage = (RasterImage)Image.Load(outputPath))
            {
                bool isSignedCorrect = signedImage.IsDigitalSigned("Secret123");
                Console.WriteLine($"Verification with correct password: {isSignedCorrect}");

                // Verify with wrong password
                bool isSignedWrong = signedImage.IsDigitalSigned("WrongPass");
                Console.WriteLine($"Verification with wrong password: {isSignedWrong}");
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
 * 1. When you need to generate a blank BMP file and embed a digital signature to protect confidential graphics in a C# application.
 * 2. When you want to ensure that only users with the correct password can verify the authenticity of an image, such as in secure document workflows.
 * 3. When you are implementing compliance checks that require proof that an image has not been tampered with by validating the signature with both correct and incorrect passwords.
 * 4. When you are testing error handling in image security features by deliberately using a wrong password to confirm the verification fails.
 * 5. When you need to programmatically create and sign BMP images for automated reporting systems that store signed visual assets.
 */
