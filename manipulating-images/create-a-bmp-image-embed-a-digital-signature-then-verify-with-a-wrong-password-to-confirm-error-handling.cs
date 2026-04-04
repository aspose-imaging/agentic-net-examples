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
        // Define output directory and file
        string outputDirectory = "Output";
        Directory.CreateDirectory(outputDirectory);
        string outputPath = Path.Combine(outputDirectory, "signed.bmp");

        // Create a BMP image, fill with white, and embed a digital signature
        int width = 200;
        int height = 200;
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Clear background to white
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Embed digital signature with correct password
            ((RasterImage)image).EmbedDigitalSignature("correctPassword");

            // Save the image (output path already bound via FileCreateSource)
            image.Save();
        }

        // Verify the digital signature using a wrong password
        if (!File.Exists(outputPath))
        {
            Console.Error.WriteLine($"File not found: {outputPath}");
            return;
        }

        using (Image loadedImage = Image.Load(outputPath))
        {
            RasterImage raster = (RasterImage)loadedImage;
            bool isSigned = raster.IsDigitalSigned("wrongPassword");
            Console.WriteLine($"Is image digitally signed with wrong password? {isSigned}");
        }
    }
}