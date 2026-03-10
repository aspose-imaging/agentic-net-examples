using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the input and output BigTIFF files
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the loaded image is a BigTiffImage
            BigTiffImage bigTiff = image as BigTiffImage;
            if (bigTiff == null)
                throw new InvalidOperationException("The loaded image is not a BigTIFF.");

            // Edge detection filter is not available in Aspose.Imaging.
            // Throw an exception to indicate the operation is unsupported.
            throw new NotSupportedException("Edge detection filter is not supported in Aspose.Imaging.");
        }
    }
}