using System;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Specify the path to the image file to be loaded
        string imagePath = @"C:\temp\sample.bmp";

        // Load the image into memory using Aspose.Imaging's static Load method
        // The using statement ensures the image resources are released after processing
        using (Image image = Image.Load(imagePath))
        {
            // The image is now initialized and ready for further processing
            // Example: retrieve basic properties
            int width = image.Width;
            int height = image.Height;

            // Placeholder for additional image processing logic
            // ...
        }
    }
}