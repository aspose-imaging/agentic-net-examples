using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine("Output", "sample.jp2");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 100;
            int height = 100;

            using (Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image jpeg2000Image = new Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image(width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(jpeg2000Image);
                graphics.Clear(Aspose.Imaging.Color.Red);
                jpeg2000Image.Save(outputPath, new Jpeg2000Options());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}