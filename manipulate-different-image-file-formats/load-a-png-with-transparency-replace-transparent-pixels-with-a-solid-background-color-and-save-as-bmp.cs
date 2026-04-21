using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image (may contain transparency)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to PngImage to access PNG‑specific properties
                PngImage pngImage = (PngImage)image;

                // Define the solid background color to replace transparent pixels
                pngImage.HasBackgroundColor = true;
                pngImage.BackgroundColor = Color.White; // change as needed

                // Save the image as BMP; BMP supports background color via default Bitfields compression
                pngImage.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}