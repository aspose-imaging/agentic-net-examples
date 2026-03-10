using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;

class JpgToPngViaEmf
{
    static void Main()
    {
        // Input JPG file path
        string jpgPath = @"C:\Images\input.jpg";

        // Temporary EMF file path
        string emfPath = Path.Combine(Path.GetDirectoryName(jpgPath) ?? "", "temp.emf");

        // Output PNG file path
        string pngPath = Path.Combine(Path.GetDirectoryName(jpgPath) ?? "", "output.png");

        // -----------------------------------------------------------------
        // Step 1: Load the JPG image
        // -----------------------------------------------------------------
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Prepare EMF rasterization options – page size equals the source image size
            var emfRasterOptions = new EmfRasterizationOptions
            {
                PageSize = jpgImage.Size
            };

            // Save the JPG as an EMF file
            jpgImage.Save(emfPath, new EmfOptions { VectorRasterizationOptions = emfRasterOptions });
        }

        // -----------------------------------------------------------------
        // Step 2: Load the generated EMF and convert it to PNG
        // -----------------------------------------------------------------
        using (Image emfImage = Image.Load(emfPath))
        {
            // Prepare vector rasterization options for PNG conversion
            var pngRasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                // Optional: set background color if needed
                BackgroundColor = Color.White
            };

            // Configure PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = pngRasterOptions
            };

            // Save the EMF as a PNG image
            emfImage.Save(pngPath, pngOptions);
        }

        // Clean up the temporary EMF file
        if (File.Exists(emfPath))
        {
            File.Delete(emfPath);
        }

        Console.WriteLine("Conversion completed. PNG saved at: " + pngPath);
    }
}