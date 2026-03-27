using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.djvu";
        string outputPath = "sample_cropped.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Define the crop rectangle (0,0,400,400)
            Rectangle cropArea = new Rectangle(0, 0, 400, 400);

            // Crop the DjVu image to the specified area
            djvuImage.Crop(cropArea);

            // Save the cropped portion as BMP
            djvuImage.Save(outputPath, new BmpOptions());
        }
    }
}