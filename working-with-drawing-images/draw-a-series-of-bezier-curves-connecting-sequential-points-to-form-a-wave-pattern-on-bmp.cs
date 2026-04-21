using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string outputPath = "./output.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        int width = 800;
        int height = 200;

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);

            Aspose.Imaging.Point[] wavePoints = new Aspose.Imaging.Point[]
            {
                new Aspose.Imaging.Point(0, height / 2),
                new Aspose.Imaging.Point(100, height / 2 - 50),
                new Aspose.Imaging.Point(200, height / 2 + 50),
                new Aspose.Imaging.Point(300, height / 2),
                new Aspose.Imaging.Point(400, height / 2 - 50),
                new Aspose.Imaging.Point(500, height / 2 + 50),
                new Aspose.Imaging.Point(600, height / 2),
                new Aspose.Imaging.Point(700, height / 2 - 50),
                new Aspose.Imaging.Point(800, height / 2)
            };

            for (int i = 0; i + 3 < wavePoints.Length; i += 3)
            {
                graphics.DrawBezier(pen,
                    wavePoints[i],
                    wavePoints[i + 1],
                    wavePoints[i + 2],
                    wavePoints[i + 3]);
            }

            image.Save();
        }
    }
}