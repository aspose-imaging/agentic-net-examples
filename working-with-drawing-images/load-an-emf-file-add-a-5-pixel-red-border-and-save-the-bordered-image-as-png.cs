using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output\\bordered.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);
            graphics.DrawRectangle(new Pen(Color.Red, 5), 0, 0, emfImage.Width, emfImage.Height);

            using (EmfImage borderedEmf = graphics.EndRecording())
            {
                PngOptions pngOptions = new PngOptions();
                borderedEmf.Save(outputPath, pngOptions);
            }
        }
    }
}