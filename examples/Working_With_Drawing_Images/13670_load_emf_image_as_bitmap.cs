using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Path to the EMF file
        string emfPath = @"C:\temp\sample.emf";

        // Load the image using Aspose.Imaging's unified Load method
        using (Image image = Image.Load(emfPath))
        {
            // Cast to EmfImage to access EMF‑specific properties
            EmfImage emfImage = image as EmfImage;

            if (emfImage != null)
            {
                // The EMF image is successfully loaded; display its dimensions
                Console.WriteLine($"EMF image loaded. Width = {emfImage.Width}, Height = {emfImage.Height}");
            }
            else
            {
                // The file was loaded but is not an EMF image
                Console.WriteLine("The loaded file is not an EMF image.");
            }
        }
    }
}