using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\newImage.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options for 24 bits per pixel
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            // Specify the file to create; false means the file is not temporal
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new 500x500 image using the specified options
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Save the image to the specified path
            image.Save();
        }
    }
}