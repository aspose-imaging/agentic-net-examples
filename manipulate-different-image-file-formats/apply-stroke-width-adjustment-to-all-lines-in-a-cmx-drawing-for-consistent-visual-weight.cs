using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\input.cmx";
            string outputPath = @"C:\temp\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                using (Image canvas = Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    Pen pen = new Pen(Color.Black, 5);
                    graphics.DrawLine(pen, new Point(0, 0), new Point(width, height));

                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}