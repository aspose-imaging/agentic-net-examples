using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu; // Namespace for DjvuImage
using Aspose.Imaging; // Base namespace for ImageOptionsBase if needed

class ImageProcessingExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Images\sample.djvu";
        string outputPath = @"C:\Images\sample_processed.bmp";

        // Open a file stream for reading the DjVu document
        using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            // Load the DjVu image using the provided static LoadDocument method
            DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream);

            // Apply a series of transformations using the available instance methods
            djvuImage.AdjustBrightness(30);          // Increase brightness
            djvuImage.Grayscale();                   // Convert to grayscale
            djvuImage.Resize(800, 600);              // Resize to 800x600 pixels

            // Save the processed image to a new file using the overridden Save(string) method
            djvuImage.Save(outputPath);
        }

        Console.WriteLine("Image processing completed successfully.");
    }
}