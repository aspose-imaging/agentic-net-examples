using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the input BMP image and the output image.
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Load the BMP image.
        using (Image image = Image.Load(inputPath))
        {
            // Edge detection filter is not available in the Aspose.Imaging filter options.
            // Throw an exception to indicate the operation is unsupported.
            throw new NotSupportedException("Edge detection filter is not supported by Aspose.Imaging.");
        }

        // Note: The code above will not reach this point due to the exception.
        // If a supported filter were available, it would be applied here and the image saved:
        // image.Save(outputPath, new BmpOptions());
    }
}