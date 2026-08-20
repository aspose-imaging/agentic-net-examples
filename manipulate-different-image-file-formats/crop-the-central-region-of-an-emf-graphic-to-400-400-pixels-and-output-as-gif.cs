// HOW-TO: Crop Center of EMF to 400x400 and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.gif";

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
                // Cast to EmfImage to access EMF-specific members
                EmfImage emfImage = (EmfImage)image;

                // Determine the rectangle for the central 400x400 region
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (emfImage.Width - cropWidth) / 2;
                int top = (emfImage.Height - cropHeight) / 2;

                // Ensure the rectangle is within image bounds
                if (left < 0) left = 0;
                if (top < 0) top = 0;
                if (cropWidth > emfImage.Width) cropWidth = emfImage.Width;
                if (cropHeight > emfImage.Height) cropHeight = emfImage.Height;

                // Perform the crop
                Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight);
                emfImage.Crop(cropArea);

                // Save the cropped image as GIF
                GifOptions gifOptions = new GifOptions();
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
 * 1. When you need to extract a fixed‑size thumbnail from the middle of a vector EMF file and deliver it as a lightweight GIF for web previews.
 * 2. When generating report thumbnails where the original EMF diagram must be cropped to a 400 × 400 region before embedding in an email or dashboard.
 * 3. When converting legacy Windows Metafile graphics to GIF format while focusing on the central content for consistent UI icons.
 * 4. When automating batch processing of EMF assets to create uniformly sized GIF previews for a digital asset management system.
 * 5. When preparing a central portion of a large EMF illustration for inclusion in a mobile app that only supports GIF images.
 */
