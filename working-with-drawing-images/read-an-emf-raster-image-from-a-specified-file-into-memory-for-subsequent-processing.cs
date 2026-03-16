using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Path to the EMF file to be loaded
        string inputFile = @"C:\Images\sample.emf";

        // Load the EMF image into memory using the unified Image.Load method
        using (Image image = Image.Load(inputFile))
        {
            // Cast the generic Image to a strongly‑typed EmfImage for EMF‑specific operations
            EmfImage emfImage = (EmfImage)image;

            // Ensure all internal data is cached so the image is fully loaded in memory
            emfImage.CacheData();

            // At this point emfImage is fully loaded and can be processed further
            Console.WriteLine($"EMF image loaded: {emfImage.Width}x{emfImage.Height} pixels");
        }
    }
}