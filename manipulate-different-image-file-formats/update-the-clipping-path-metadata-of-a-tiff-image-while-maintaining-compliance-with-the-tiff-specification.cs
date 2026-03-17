using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            image.Save(outputPath);
        }
    }
}