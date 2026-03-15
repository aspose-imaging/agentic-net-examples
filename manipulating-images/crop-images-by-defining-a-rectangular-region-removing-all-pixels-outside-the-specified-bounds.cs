using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageCropper
{
    // Crops an image to a rectangular region defined by (x, y, width, height)
    // and saves the result as a PNG file.
    public static void CropImage(string inputPath, string outputPath,
                                 int x, int y, int width, int height)
    {
        // Load the image from the specified file.
        using (Image image = Image.Load(inputPath))
        {
            // Define the cropping rectangle.
            Rectangle area = new Rectangle(x, y, width, height);

            // Perform the crop operation.
            image.Crop(area);

            // Save the cropped image as PNG.
            image.Save(outputPath, new PngOptions());
        }
    }

    // Example usage.
    static void Main()
    {
        string inputFile = @"c:\temp\sample.png";
        string outputFile = @"c:\temp\sample.Crop.png";

        // Crop the central half of the image.
        using (Image img = Image.Load(inputFile))
        {
            int x = img.Width / 4;
            int y = img.Height / 4;
            int w = img.Width / 2;
            int h = img.Height / 2;

            CropImage(inputFile, outputFile, x, y, w, h);
        }

        Console.WriteLine("Cropping completed.");
    }
}