using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DjvuProcessingExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputPath = @"C:\Temp\sample_processed.png";

        // Load the DjVu document from a file stream using the provided LoadDocument method
        using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
        {
            // Adjust contrast (range -100 to 100)
            djvuImage.AdjustContrast(30f);

            // Adjust brightness (range -255 to 255)
            djvuImage.AdjustBrightness(20);

            // Rotate the image by 5 degrees around its center
            djvuImage.Rotate(5f);

            // Apply a Gaussian blur filter to the entire image
            djvuImage.Filter(
                djvuImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG using the provided Save method and PngOptions
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}