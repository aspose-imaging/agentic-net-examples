using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source EMF file
        string inputFile = @"C:\Images\source.emf";
        // Path where the cropped EMF will be saved
        string outputFile = @"C:\Images\cropped.emf";

        // Load the EMF image using the unified Image.Load method
        using (Image image = Image.Load(inputFile))
        {
            // Cast the generic Image to EmfImage to access EMF‑specific functionality
            EmfImage emfImage = (EmfImage)image;

            // Define the cropping rectangle (example: keep the central half of the image)
            int cropX = emfImage.Width / 4;
            int cropY = emfImage.Height / 4;
            int cropWidth = emfImage.Width / 2;
            int cropHeight = emfImage.Height / 2;
            Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Perform the crop operation while preserving vector data
            emfImage.Crop(cropRect);

            // Save the cropped image back to EMF format using EmfOptions
            emfImage.Save(outputFile, new EmfOptions());
        }
    }
}