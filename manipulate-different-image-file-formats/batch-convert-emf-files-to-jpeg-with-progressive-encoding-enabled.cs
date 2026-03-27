using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        string[] files = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 90,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, jpegOptions);
            }
        }
    }
}