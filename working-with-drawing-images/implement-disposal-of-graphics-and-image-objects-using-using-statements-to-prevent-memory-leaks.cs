using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path check
        string inputPath = @"c:\temp\input.png";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output path
        string outputPath = @"c:\temp\output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a PNG image and draw on it
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                // Graphics does not implement IDisposable; do not wrap in using
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);
                graphics.DrawRectangle(new Pen(Color.Blue, 5), new Rectangle(50, 50, 300, 200));

                // Use SolidBrush inside using for disposal
                using (SolidBrush brush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillRectangle(brush, new Rectangle(60, 60, 280, 180));
                }

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}