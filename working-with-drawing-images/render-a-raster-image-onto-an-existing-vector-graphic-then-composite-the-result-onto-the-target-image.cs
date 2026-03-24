using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string vectorPath = @"C:\Images\vector.svg";
        string rasterPath = @"C:\Images\raster.png";
        string targetPath = @"C:\Images\target.jpg";
        string intermediatePath = @"C:\Images\vector_with_raster.png";
        string outputPath = @"C:\Images\final_output.jpg";

        if (!File.Exists(vectorPath))
        {
            Console.Error.WriteLine($"File not found: {vectorPath}");
            return;
        }
        if (!File.Exists(rasterPath))
        {
            Console.Error.WriteLine($"File not found: {rasterPath}");
            return;
        }
        if (!File.Exists(targetPath))
        {
            Console.Error.WriteLine($"File not found: {targetPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (SvgImage vectorImage = (SvgImage)Image.Load(vectorPath))
        {
            using (RasterImage rasterImg = (RasterImage)Image.Load(rasterPath))
            {
                Graphics vectorGraphics = new Graphics(vectorImage);
                vectorGraphics.DrawImage(rasterImg, new Point(50, 50));
            }

            Source vecSource = new FileCreateSource(intermediatePath, false);
            PngOptions pngOptions = new PngOptions() { Source = vecSource };
            vectorImage.Save(intermediatePath, pngOptions);
        }

        using (RasterImage vecRaster = (RasterImage)Image.Load(intermediatePath))
        using (RasterImage targetImg = (RasterImage)Image.Load(targetPath))
        {
            Graphics targetGraphics = new Graphics(targetImg);
            targetGraphics.DrawImage(vecRaster, new Point(0, 0));

            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };
            targetImg.Save(outputPath, jpegOptions);
        }
    }
}