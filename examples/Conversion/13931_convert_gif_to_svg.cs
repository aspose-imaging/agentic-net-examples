using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.svg";

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var svgRasterOptions = new SvgRasterizationOptions
            {
                PageWidth = image.Width,
                PageHeight = image.Height,
                BackgroundColor = Aspose.Imaging.Color.White,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None
            };

            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = svgRasterOptions
            };

            image.Save(outputPath, svgOptions);
        }
    }
}