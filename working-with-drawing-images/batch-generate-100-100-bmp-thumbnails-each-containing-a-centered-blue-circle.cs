using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] inputFiles = Directory.GetFiles(inputDir);
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_thumb.bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    bmpOptions.Source = new FileCreateSource(outputPath, false);
                    using (Aspose.Imaging.Image canvas = Aspose.Imaging.Image.Create(bmpOptions, 100, 100))
                    {
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                        graphics.Clear(Aspose.Imaging.Color.White);

                        int radius = 40;
                        int centerX = 50;
                        int centerY = 50;
                        int left = centerX - radius;
                        int top = centerY - radius;
                        int diameter = radius * 2;

                        using (SolidBrush brush = new SolidBrush())
                        {
                            brush.Color = Aspose.Imaging.Color.Blue;
                            brush.Opacity = 100;
                            graphics.FillEllipse(brush, new Aspose.Imaging.Rectangle(left, top, diameter, diameter));
                        }

                        canvas.Save();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}