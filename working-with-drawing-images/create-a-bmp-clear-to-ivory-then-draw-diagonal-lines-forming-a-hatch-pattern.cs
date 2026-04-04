using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        string outputPath = @"C:\temp\hatch.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int width = 500;
        int height = 500;

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, width, height))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Ivory);

            using (HatchBrush brush = new HatchBrush())
            {
                brush.BackgroundColor = Color.Ivory;
                brush.ForegroundColor = Color.Black;
                brush.HatchStyle = HatchStyle.ForwardDiagonal;

                graphics.FillRectangle(brush, new Rectangle(0, 0, width, height));
            }

            image.Save();
        }
    }
}