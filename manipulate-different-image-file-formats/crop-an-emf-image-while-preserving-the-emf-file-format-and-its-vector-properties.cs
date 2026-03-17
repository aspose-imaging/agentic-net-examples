using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Path to the source EMF file
        string inputPath = @"C:\Temp\input.emf";

        // Path where the cropped EMF will be saved
        string outputPath = @"C:\Temp\output_cropped.emf";

        // Load the EMF image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access vector‑specific functionality
            EmfImage emfImage = (EmfImage)image;

            // Define a rectangle that represents the area to keep.
            // Example: keep the central half of the image.
            int cropX = emfImage.Width / 4;
            int cropY = emfImage.Height / 4;
            int cropWidth = emfImage.Width / 2;
            int cropHeight = emfImage.Height / 2;
            var cropArea = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Crop the image. The operation preserves the vector data.
            emfImage.Crop(cropArea);

            // Save the cropped image back to EMF format, retaining its vector properties.
            emfImage.Save(outputPath);
        }
    }
}