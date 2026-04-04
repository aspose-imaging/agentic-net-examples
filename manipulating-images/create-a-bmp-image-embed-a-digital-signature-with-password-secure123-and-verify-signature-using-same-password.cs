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
        // Define output directory and file path
        string outputDir = "C:\\Temp";
        string outputPath = Path.Combine(outputDir, "signed.bmp");

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Create a BMP canvas of size 200x200
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = source };
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 200, 200))
        {
            // Embed a digital signature with the password "Secure123"
            canvas.EmbedDigitalSignature("Secure123");

            // Save the image (output file is already bound to the source)
            canvas.Save();
        }

        // Verify that the image is digitally signed
        if (!File.Exists(outputPath))
        {
            Console.Error.WriteLine($"File not found: {outputPath}");
            return;
        }

        using (RasterImage loadedImage = (RasterImage)Image.Load(outputPath))
        {
            bool isSigned = loadedImage.IsDigitalSigned("Secure123");
            Console.WriteLine($"Is image digitally signed? {isSigned}");
        }
    }
}