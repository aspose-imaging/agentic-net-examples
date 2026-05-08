using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
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
                    // Use the original image size as the page size
                    PageSize = emfImage.Size,
                    // Set desired background color (e.g., LightGray)
                    BackgroundColor = Aspose.Imaging.Color.LightGray,
                    // Render mode – auto selects appropriate rendering
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
                };

                // Configure JPEG save options and attach rasterization options
                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as JPEG
                emfImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}