using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "blended.png";

        using (Aspose.Imaging.RasterImage source = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            int width = source.Width;
            int height = source.Height;

            var overlaySrc = new FileCreateSource("overlay.tmp", false);
            var overlayOpts = new PngOptions { Source = overlaySrc };
            using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(overlayOpts, width, height))
            {
                Aspose.Imaging.Graphics overlayGraphics = new Aspose.Imaging.Graphics(overlay);
                overlayGraphics.Clear(Aspose.Imaging.Color.FromArgb(255, 255, 0, 0));

                source.Blend(new Aspose.Imaging.Point(0, 0), overlay, 128);
            }

            var outSrc = new FileCreateSource(outputPath, false);
            var outOpts = new PngOptions { Source = outSrc };
            source.Save(outputPath, outOpts);
        }
    }
}