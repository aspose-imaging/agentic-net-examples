using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // TGA format is not supported in this environment.
        // Attempting to process TGA will result in NotSupportedException.
        // Uncomment the following line to enforce this behavior at runtime.
        // throw new NotSupportedException("TGA format is not supported.");

        // Example: Load a JPEG image and save it using JPEG options.
        string jpegPath = "source.jpg";
        string outputJpegPath = "output.jpg";

        using (RasterImage jpegRaster = (JpegImage)Image.Load(jpegPath))
        {
            jpegRaster.Save(outputJpegPath, new JpegOptions());
        }
    }
}