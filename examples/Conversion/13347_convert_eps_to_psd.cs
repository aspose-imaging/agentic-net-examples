using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class EpsToPsdConverter
{
    static void Main()
    {
        // Path to the source EPS file
        string sourcePath = "input.eps";

        // Path for the resulting PSD file
        string outputPath = "output.psd";

        // Load the EPS image using Aspose.Imaging
        using (Image epsImage = Image.Load(sourcePath))
        {
            // Create PSD export options (default settings)
            PsdOptions psdOptions = new PsdOptions();

            // Optional: configure PSD options (e.g., compression method)
            // psdOptions.CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE;
            // psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.RGB;

            // Save the loaded EPS image as a PSD file
            epsImage.Save(outputPath, psdOptions);
        }
    }
}