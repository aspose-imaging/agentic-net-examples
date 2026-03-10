using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input EMF image and output file
        string inputPath = "input.emf";
        string outputPath = "output.emf";

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the loaded image is an EMF image
            EmfImage emfImage = image as EmfImage;
            if (emfImage == null)
                throw new InvalidOperationException("The specified file is not an EMF image.");

            // Edge detection filter is not available in Aspose.Imaging.
            // Throwing NotSupportedException as per guidelines.
            throw new NotSupportedException("Edge detection filter is not supported by Aspose.Imaging.");
        }
    }
}