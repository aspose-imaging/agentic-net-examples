using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Path to the EMF file
        string emfPath = @"c:\temp\test.emf";

        // Load the image using Aspose.Imaging's unified Load method
        using (Image image = Image.Load(emfPath))
        {
            // Cast the generic Image to EmfImage to access EMF‑specific members
            EmfImage emfImage = (EmfImage)image;

            // Example usage: output image dimensions
            Console.WriteLine($"EMF image loaded. Width = {emfImage.Width}, Height = {emfImage.Height}");
        }
    }
}