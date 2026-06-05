using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.gif";

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
                // Cast to EmfImage for cropping
                EmfImage emfImage = (EmfImage)image;

                // Calculate the central 400x400 rectangle
                int cropWidth = Math.Min(400, emfImage.Width);
                int cropHeight = Math.Min(400, emfImage.Height);
                int left = (emfImage.Width - cropWidth) / 2;
                int top = (emfImage.Height - cropHeight) / 2;

                var cropArea = new Rectangle(left, top, cropWidth, cropHeight);

                // Crop the image
                emfImage.Crop(cropArea);

                // Save the cropped image as GIF
                var gifOptions = new GifOptions();
                emfImage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract the central 400×400 pixels from a vector‑based EMF logo and deliver it as a lightweight GIF for web thumbnails.
 * 2. When an application must convert legacy Windows Metafile (EMF) diagrams into GIFs while focusing on the most important central area.
 * 3. When a reporting tool has to generate preview images of large EMF charts, cropping the middle section to a fixed 400×400 size for inclusion in PDF reports.
 * 4. When a batch‑processing service automates the preparation of EMF icons for mobile apps, trimming them to a centered 400×400 region and saving as GIF to reduce file size.
 * 5. When a document management system needs to display a consistent square preview of uploaded EMF drawings by cropping the center and converting it to GIF for quick browser rendering.
 */