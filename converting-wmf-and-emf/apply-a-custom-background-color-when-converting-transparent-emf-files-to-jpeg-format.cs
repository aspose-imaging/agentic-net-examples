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
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.jpg";

        // Ensure any runtime exception is reported cleanly
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

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF‑specific properties
                EmfImage emfImage = (EmfImage)image;

                // Configure rasterization options with a custom background color
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,                 // Preserve original size
                    BackgroundColor = Aspose.Imaging.Color.White, // Desired background color
                    RenderMode = EmfRenderMode.Auto          // Let the library choose the render mode
                };

                // Configure JPEG save options and attach rasterization options
                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as JPEG with the specified background
                emfImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating product catalog PDFs that embed transparent EMF logos and need to be converted to JPEG thumbnails with a white background for consistent display on web pages.
 * 2. When a reporting system exports vector charts as EMF files and must rasterize them to JPEG images with a specific background color to match the report’s theme.
 * 3. When an e‑learning platform stores diagram assets in EMF format and requires JPEG previews with a corporate brand color background for course listings.
 * 4. When a legacy document conversion pipeline processes EMF signatures and needs to embed them in JPEG files with a neutral background to avoid transparency artifacts.
 * 5. When an automated email service creates JPEG previews of user‑uploaded EMF graphics and must apply a custom background color to ensure the images render correctly in email clients that do not support transparency.
 */