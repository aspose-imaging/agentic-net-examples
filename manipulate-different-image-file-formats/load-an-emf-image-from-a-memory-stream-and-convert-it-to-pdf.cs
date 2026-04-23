using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image from a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                using (Image image = Image.Load(ms))
                {
                    // Cast to EmfImage to access size information
                    EmfImage emfImage = image as EmfImage;
                    if (emfImage == null)
                    {
                        Console.Error.WriteLine("The loaded image is not a valid EMF image.");
                        return;
                    }

                    // Set up rasterization options for EMF rendering
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Color.White
                    };

                    // Configure PDF save options with the rasterization settings
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}