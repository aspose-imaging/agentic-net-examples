using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\Images\large.jpg";
        string outputPath = @"C:\Images\thumbnail.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 50 }))
        {
            image.Resize(200, 200, ResizeType.NearestNeighbourResample);

            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90,
                Source = new FileCreateSource(outputPath, false)
            };

            image.Save(outputPath, jpegOptions);
        }
    }
}