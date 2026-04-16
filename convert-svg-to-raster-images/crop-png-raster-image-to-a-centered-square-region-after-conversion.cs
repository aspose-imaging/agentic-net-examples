using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_cropped.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for cropping
            RasterImage rasterImage = (RasterImage)image;

            // Determine the size of the centered square
            int side = Math.Min(rasterImage.Width, rasterImage.Height);
            int left = (rasterImage.Width - side) / 2;
            int top = (rasterImage.Height - side) / 2;

            // Define the cropping rectangle
            Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(left, top, side, side);

            // Perform the crop
            rasterImage.Crop(cropArea);

            // Save the cropped image as PNG
            PngOptions pngOptions = new PngOptions();
            rasterImage.Save(outputPath, pngOptions);
        }
    }
}