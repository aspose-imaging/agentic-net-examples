using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        int width = 800;
        int height = 600;

        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

        using (TiffImage image = (TiffImage)Image.Create(tiffOptions, width, height))
        {
            image.Save("SimpleImage.tif");
        }
    }
}