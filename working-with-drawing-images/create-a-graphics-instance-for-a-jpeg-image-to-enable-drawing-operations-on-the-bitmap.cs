using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            Graphics graphics = new Graphics(jpegImage);

            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                graphics.FillRectangle(brush, jpegImage.Bounds);
            }

            jpegImage.Save(outputPath);
        }
    }
}