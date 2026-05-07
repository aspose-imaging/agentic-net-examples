using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            int width = 500;
            int height = 500;

            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Ivory);

                using (HatchBrush hatchBrush = new HatchBrush())
                {
                    hatchBrush.BackgroundColor = Color.Ivory;
                    hatchBrush.ForegroundColor = Color.Black;
                    hatchBrush.HatchStyle = HatchStyle.ForwardDiagonal;
                    graphics.FillRectangle(hatchBrush, new Rectangle(0, 0, width, height));
                }

                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}