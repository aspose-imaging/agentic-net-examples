using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.emf";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the EMF image and retrieve dimensions
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access Width and Height properties
            EmfImage emfImage = (EmfImage)image;
            int width = emfImage.Width;
            int height = emfImage.Height;

            // Log the dimensions
            Console.WriteLine($"Width: {width}");
            Console.WriteLine($"Height: {height}");
        }
    }
}