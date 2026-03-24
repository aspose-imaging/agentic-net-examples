using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"c:\temp\input.bmp";
        string outputPath = @"c:\temp\output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            Graphics graphics = new Graphics(image);

            graphics.DrawRectangle(
                new Pen(Color.Blue, 5),
                new Rectangle(50, 50, 200, 150));

            graphics.DrawEllipse(
                new Pen(Color.Green, 5),
                new Rectangle(300, 100, 150, 150));

            graphics.DrawLine(
                new Pen(Color.Red, 3),
                new Point(0, 0),
                new Point(image.Width, image.Height));

            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };
            image.Save(outputPath, bmpOptions);
        }
    }
}