using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image outputImage = Image.Create(pngOptions, inputImage.Width, inputImage.Height))
            {
                Graphics graphics = new Graphics(outputImage);

                graphics.Clip = new Region(new Rectangle(50, 50, 200, 200));

                Pen clipPen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(clipPen, new Rectangle(0, 0, 300, 300));

                graphics.Clip = null;

                Pen resetPen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(resetPen, new Rectangle(0, 0, 300, 300));

                outputImage.Save();
            }
        }
    }
}