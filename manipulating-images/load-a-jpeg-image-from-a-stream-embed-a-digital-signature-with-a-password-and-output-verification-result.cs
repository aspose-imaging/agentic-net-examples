using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\signed.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (var image = Image.Load(stream))
                {
                    var raster = (RasterImage)image;

                    raster.EmbedDigitalSignature("secure123");

                    bool isSigned = raster.IsDigitalSigned("secure123");
                    Console.WriteLine($"Verification result: {isSigned}");

                    var jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}