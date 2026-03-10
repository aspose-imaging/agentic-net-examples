using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Path to the EMF file
        string emfFilePath = @"C:\temp\test.emf";

        // Load the EMF image using Aspose.Imaging.Image.Load
        using (EmfImage emfImage = (EmfImage)Image.Load(emfFilePath))
        {
            // The image is now loaded and can be used.
            // Example: output its dimensions.
            Console.WriteLine($"EMF image loaded. Width: {emfImage.Width}, Height: {emfImage.Height}");
        }
    }
}