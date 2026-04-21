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
            // Hardcoded output path
            string outputPath = "output.bmp";

            // Ensure output directory exists (null-safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a bound BMP image (200x200)
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            int width = 200;
            int height = 200;

            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                // Embed digital signature with password
                canvas.EmbedDigitalSignature("Secure123");

                // Verify the signature using the same password
                bool isSigned = canvas.IsDigitalSigned("Secure123");
                Console.WriteLine($"Signature verification result: {isSigned}");

                // Save the image (bound source)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}