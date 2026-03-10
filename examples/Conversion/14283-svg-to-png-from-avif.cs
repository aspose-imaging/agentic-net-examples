using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.jpg";

        using (Image image = Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageWidth = image.Width;
            rasterOptions.PageHeight = image.Height;
            rasterOptions.BackgroundColor = Color.White;

            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.VectorRasterizationOptions = rasterOptions;
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}