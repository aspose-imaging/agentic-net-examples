using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "Input/sample.otg";
        string outputPath = "Output/sample.jpg";

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
                jpegOptions.Quality = 100;

                image.Save(outputPath, jpegOptions);
            }
        }
    }
}