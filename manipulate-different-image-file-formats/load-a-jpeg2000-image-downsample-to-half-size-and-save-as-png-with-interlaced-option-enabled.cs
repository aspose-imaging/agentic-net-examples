using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jp2";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Jpeg2000Image jpeg2000Image = (Jpeg2000Image)Image.Load(inputPath))
            {
                if (!jpeg2000Image.IsCached)
                    jpeg2000Image.CacheData();

                int newWidth = jpeg2000Image.Width / 2;
                int newHeight = jpeg2000Image.Height / 2;

                jpeg2000Image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                PngOptions pngOptions = new PngOptions();

                jpeg2000Image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}