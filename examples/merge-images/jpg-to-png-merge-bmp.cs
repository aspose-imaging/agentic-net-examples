using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpgToPngViaBmp
{
    static void Main()
    {
        // Define source and destination paths
        string dir = @"C:\temp\";
        string jpgPath = Path.Combine(dir, "input.jpg");
        string bmpPath = Path.Combine(dir, "intermediate.bmp");
        string pngPath = Path.Combine(dir, "output.png");

        // Load the original JPG image
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Save the JPG image as BMP using default BMP options
            jpgImage.Save(bmpPath, new BmpOptions());

            // Load the intermediate BMP image
            using (Image bmpImage = Image.Load(bmpPath))
            {
                // Save the BMP image as PNG using default PNG options
                bmpImage.Save(pngPath, new PngOptions());
            }
        }

        Console.WriteLine("Conversion completed: JPG -> BMP -> PNG");
    }
}