using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            int width = 800;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 2);

                Point[] wavePoints = new Point[]
                {
                    new Point(0, height / 2),
                    new Point(100, 0),
                    new Point(200, height),
                    new Point(300, height / 2),
                    new Point(400, 0),
                    new Point(500, height),
                    new Point(600, height / 2),
                    new Point(700, 0),
                    new Point(800, height / 2)
                };

                for (int i = 0; i + 3 < wavePoints.Length; i += 3)
                {
                    graphics.DrawBezier(pen,
                                        wavePoints[i],
                                        wavePoints[i + 1],
                                        wavePoints[i + 2],
                                        wavePoints[i + 3]);
                }

                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}