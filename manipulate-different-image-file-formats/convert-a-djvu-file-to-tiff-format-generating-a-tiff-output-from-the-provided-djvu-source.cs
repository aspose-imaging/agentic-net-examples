using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input DjVu file path
        string inputPath = "sample.djvu";
        // Output TIFF file path
        string outputPath = "output.tif";

        // Open the DjVu file stream
        using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            // Load DjVu image from the stream
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                // Save all pages as a multi-page TIFF
                djvuImage.Save(outputPath, tiffOptions);
            }
        }
    }
}