using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class CombineImages
{
    static void Main()
    {
        // Folder containing the source images
        string inputFolder = @"C:\Images\Input";

        // Output file – a multipage TIFF that will hold all images
        string outputFile = @"C:\Images\Combined\combined.tiff";

        // Get all image files from the folder (you can adjust the filter as needed)
        string[] imageFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);

        // Create a multipage image from the specified files.
        // This uses the provided Image.Create(string[]) overload which builds a multi‑page image
        // while preserving each source image's original format.
        using (Image multiPageImage = Image.Create(imageFiles))
        {
            // Save the combined image to disk.
            // The Save(string) method follows the lifecycle rule for persisting the image.
            multiPageImage.Save(outputFile);
        }

        Console.WriteLine("Images combined successfully into: " + outputFile);
    }
}