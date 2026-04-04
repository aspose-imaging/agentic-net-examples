using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            try
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawRectangle(new Pen(Aspose.Imaging.Color.Blue, 3), new Rectangle(10, 10, image.Width - 20, image.Height - 20));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Graphics not supported for this format: {ex.Message}");
                return;
            }

            PngOptions saveOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            image.Save(outputPath, saveOptions);
        }
    }
}