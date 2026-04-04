using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string outputPath = "output/output.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (MemoryStream memoryStream = new MemoryStream())
        {
            PngOptions pngOptions = new PngOptions
            {
                Source = new StreamSource(memoryStream)
            };

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);
                image.Save();
            }

            memoryStream.Position = 0;
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                memoryStream.CopyTo(fileStream);
            }
        }
    }
}