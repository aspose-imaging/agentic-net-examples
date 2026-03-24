using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\output.tif";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(tiffOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            Pen pen = new Pen(Color.Black, 5);
            graphics.DrawRectangle(pen, new Rectangle(50, 50, 400, 400));

            image.Save();
        }
    }
}