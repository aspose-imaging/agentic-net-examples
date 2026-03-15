using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        string outputPath = args.Length > 1 ? args[1] : "output.tga";

        if (Path.GetExtension(outputPath).Equals(".tga", StringComparison.OrdinalIgnoreCase))
        {
            outputPath = Path.ChangeExtension(outputPath, ".jpg");
        }

        using (Image image = Image.Load(inputPath))
        {
            var jpegOptions = new JpegOptions();
            image.Save(outputPath, jpegOptions);
        }
    }
}