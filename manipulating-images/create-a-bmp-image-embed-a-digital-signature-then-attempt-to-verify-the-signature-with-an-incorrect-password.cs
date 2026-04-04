using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string outputPath = "output/output.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Create(new BmpOptions(), 200, 200))
        {
            RasterImage raster = (RasterImage)image;
            raster.EmbedDigitalSignature("correctPassword");
            image.Save(outputPath, new BmpOptions());
        }

        if (!File.Exists(outputPath))
        {
            Console.Error.WriteLine($"File not found: {outputPath}");
            return;
        }

        using (Image loadedImage = Image.Load(outputPath))
        {
            RasterImage rasterLoaded = (RasterImage)loadedImage;
            bool isSigned = rasterLoaded.IsDigitalSigned("wrongPassword");
            Console.WriteLine($"Is signed with wrong password: {isSigned}");
        }
    }
}