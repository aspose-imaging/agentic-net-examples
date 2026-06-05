using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;
                string password = "secure123";

                bool isSigned = raster.IsDigitalSigned(password);
                if (isSigned)
                {
                    Console.WriteLine("Image is already digitally signed.");
                }
                else
                {
                    raster.EmbedDigitalSignature(password);
                    raster.Save(outputPath, new PngOptions());
                    Console.WriteLine("Digital signature embedded and image saved.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}