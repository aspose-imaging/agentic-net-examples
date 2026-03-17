using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Path to the image file (can be JPEG, PNG, APNG, TGA, etc.)
        string imagePath = "sample.jpg";

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(imagePath))
        {
            // Retrieve the last modified timestamp.
            // The 'true' argument tells the method to fall back to the file system's
            // timestamp if the image metadata does not contain a modification date.
            DateTime lastModified = ((RasterImage)image).GetModifyDate(true);

            // Display the result
            Console.WriteLine($"Last modified: {lastModified}");
        }
    }
}