using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_signed.jpg";
        string password = "MySecretPassword";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load JPEG from a stream, embed digital signature, and save
        using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            // Load the image (returns a RasterImage for JPEG)
            using (RasterImage image = (RasterImage)Image.Load(inputStream))
            {
                // Embed the digital signature using the provided password
                image.EmbedDigitalSignature(password);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the signed image
                image.Save(outputPath);
            }
        }

        // Reload the saved image to verify the signature
        using (RasterImage verifyImage = (RasterImage)Image.Load(outputPath))
        {
            bool isSigned = verifyImage.IsDigitalSigned(password);
            Console.WriteLine($"Digital signature verification: {(isSigned ? "Valid" : "Invalid")}");
        }
    }
}