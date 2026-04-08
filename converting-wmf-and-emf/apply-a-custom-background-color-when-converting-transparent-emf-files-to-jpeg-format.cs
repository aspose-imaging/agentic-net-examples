using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF‑specific properties
            EmfImage emfImage = (EmfImage)image;

            // Configure rasterization options with a custom background color
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                // Set the desired background color (e.g., white)
                BackgroundColor = Aspose.Imaging.Color.White,
                // Use the original EMF size as the page size
                PageSize = emfImage.Size
            };

            // Configure JPEG save options and attach the rasterization options
            JpegOptions jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as JPEG with the specified background color
            emfImage.Save(outputPath, jpegOptions);
        }
    }
}