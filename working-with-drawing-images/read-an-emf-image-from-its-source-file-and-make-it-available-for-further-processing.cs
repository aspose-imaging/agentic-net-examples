using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Path to the EMF file
        string dir = @"c:\temp\";
        string filePath = Path.Combine(dir, "test.emf");

        // Load the EMF image using Aspose.Imaging.Image.Load
        using (EmfImage emfImage = (EmfImage)Image.Load(filePath))
        {
            // Cache data to ensure all records are loaded (optional but improves performance)
            emfImage.CacheData();

            // The EMF image is now available for further processing.
            // Example: retrieve basic properties.
            int width = emfImage.Width;
            int height = emfImage.Height;
            Console.WriteLine($"EMF Image Size: {width}x{height}");

            // Additional processing can be performed here, e.g., accessing records:
            // var recordCount = emfImage.Records.Count;
        }
    }
}