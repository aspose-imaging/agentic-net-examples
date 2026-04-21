using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\sample.otg";
        string outputPath = "Output\\sample.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.HorizontalSampling = new byte[] { 2, 1, 1 };
                jpegOptions.VerticalSampling = new byte[] { 2, 1, 1 };
                jpegOptions.Quality = 90;

                jpegOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                image.Save(outputPath, jpegOptions);
            }
        }
    }
}