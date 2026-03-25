using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
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
                jpegOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                image.Save(outputPath, jpegOptions);
            }
        }

        if (!File.Exists(outputPath))
        {
            Console.Error.WriteLine($"Output file not found: {outputPath}");
            return;
        }

        FileInfo info = new FileInfo(outputPath);
        if (info.Length == 0)
        {
            Console.Error.WriteLine($"Output file is empty: {outputPath}");
        }
        else
        {
            Console.WriteLine($"JPG file created successfully. Size: {info.Length} bytes.");
        }
    }
}