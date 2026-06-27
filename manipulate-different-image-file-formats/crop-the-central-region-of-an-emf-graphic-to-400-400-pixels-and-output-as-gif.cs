using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.emf";
        string outputPath = @"C:\temp\cropped.gif";

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
                // Cast to EmfImage to access EMF-specific methods
                EmfImage emfImage = (EmfImage)image;

                // Determine central 400x400 rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int x = (emfImage.Width - cropWidth) / 2;
                int y = (emfImage.Height - cropHeight) / 2;
                var cropArea = new Rectangle(x, y, cropWidth, cropHeight);

                // Crop the image
                emfImage.Crop(cropArea);

                // Save as GIF
                var gifOptions = new GifOptions(); // default options
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
 * 1. When a developer needs to extract the central 400×400 pixels from a vector EMF logo and deliver it as a lightweight GIF for web thumbnails.
 * 2. When an application must convert legacy Windows Metafile (EMF) diagrams into GIF images while focusing on the central area for consistent presentation.
 * 3. When a reporting tool has to generate preview images of EMF charts by cropping the middle section to a fixed size and saving it as a GIF for inclusion in PDF reports.
 * 4. When a batch‑processing script processes a folder of EMF icons, cropping each to a 400×400 central region and exporting them as GIFs for use in mobile UI assets.
 * 5. When a developer wants to programmatically validate that an EMF file contains sufficient resolution, crop its core region, and store the result as a GIF for archival or comparison purposes.
 */