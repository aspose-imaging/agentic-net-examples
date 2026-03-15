using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input image path (PNG) and output image path (JPEG)
        string inputPath = "input.png";
        string outputPath = "output.jpg";

        // Open the input image via a file stream
        using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            // Load the image from the stream
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputStream))
            {
                // Ensure the image data is cached for better performance
                if (!image.IsCached)
                    image.CacheData();

                // Resize the image to half of its original dimensions
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight);

                // Define a rectangle to crop the central area of the resized image
                int cropX = newWidth / 4;
                int cropY = newHeight / 4;
                int cropWidth = newWidth / 2;
                int cropHeight = newHeight / 2;
                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(cropX, cropY, cropWidth, cropHeight);
                image.Crop(cropRect);

                // Save the processed image as JPEG using default options
                image.Save(outputPath, new JpegOptions());
            }
        }
    }
}