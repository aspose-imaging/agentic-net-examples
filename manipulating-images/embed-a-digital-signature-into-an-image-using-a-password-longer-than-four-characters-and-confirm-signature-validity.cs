using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output_signed.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Work with RasterImage which provides digital signature methods
            if (image is RasterImage rasterImage)
            {
                // Password longer than four characters
                string password = "StrongPass123";

                // Embed the digital signature into the image
                rasterImage.EmbedDigitalSignature(password);

                // Save the signed image to the output path
                rasterImage.Save(outputPath);
            }
            else
            {
                Console.Error.WriteLine("The loaded image type does not support digital signatures.");
                return;
            }
        }

        // Load the signed image to verify the signature
        using (Image signedImage = Image.Load(outputPath))
        {
            if (signedImage is RasterImage signedRaster)
            {
                string password = "StrongPass123";

                // Check whether the image is digitally signed with the given password
                bool isSigned = signedRaster.IsDigitalSigned(password);

                Console.WriteLine($"Signature verification result: {isSigned}");
            }
            else
            {
                Console.Error.WriteLine("The signed image type does not support digital signature verification.");
            }
        }
    }
}