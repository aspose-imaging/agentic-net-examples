using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/sample.jp2";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Jpeg2000Options options = new Jpeg2000Options
            {
                Irreversible = true,
                Codec = Jpeg2000Codec.J2K
            };

            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200, options))
            {
                Graphics graphics = new Graphics(jpeg2000Image);
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, jpeg2000Image.Bounds);
                }
                jpeg2000Image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}