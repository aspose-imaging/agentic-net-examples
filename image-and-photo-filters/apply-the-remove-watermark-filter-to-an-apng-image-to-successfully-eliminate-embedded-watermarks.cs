using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = apng.DefaultFrameTime,
                NumPlays = apng.NumPlays
            };

            using (ApngImage resultApng = (ApngImage)Image.Create(createOptions, apng.Width, apng.Height))
            {
                resultApng.RemoveAllFrames();

                foreach (var page in apng.Pages)
                {
                    RasterImage frame = (RasterImage)page;

                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0, 0, frame.Width, frame.Height)));
                    mask.AddFigure(figure);

                    var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                    RasterImage cleaned = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(frame, options);

                    resultApng.AddFrame(cleaned);
                    cleaned.Dispose();
                }

                resultApng.Save();
            }
        }
    }
}