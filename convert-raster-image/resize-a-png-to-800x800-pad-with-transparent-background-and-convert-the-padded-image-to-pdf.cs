using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main()
    {
        string inputPath = "Input/input.png";
        string outputPath = "Output/output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage src = (RasterImage)Image.Load(inputPath))
        {
            if (!src.IsCached) src.CacheData();

            const int targetSize = 800;
            double scale = Math.Min((double)targetSize / src.Width, (double)targetSize / src.Height);
            int newWidth = (int)(src.Width * scale);
            int newHeight = (int)(src.Height * scale);

            src.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            using (PngImage canvas = new PngImage(targetSize, targetSize))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Transparent);

                int offsetX = (targetSize - newWidth) / 2;
                int offsetY = (targetSize - newHeight) / 2;

                Rectangle destRect = new Rectangle(offsetX, offsetY, newWidth, newHeight);
                canvas.SaveArgb32Pixels(destRect, src.LoadArgb32Pixels(src.Bounds));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    canvas.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}