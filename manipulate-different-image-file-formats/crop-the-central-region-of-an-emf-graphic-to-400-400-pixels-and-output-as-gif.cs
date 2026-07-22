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
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF-specific members
                EmfImage emfImage = (EmfImage)image;

                // Determine the central 400x400 rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (emfImage.Width - cropWidth) / 2;
                int top = (emfImage.Height - cropHeight) / 2;

                // Ensure the rectangle is within image bounds
                if (left < 0) left = 0;
                if (top < 0) top = 0;
                if (cropWidth > emfImage.Width) cropWidth = emfImage.Width;
                if (cropHeight > emfImage.Height) cropHeight = emfImage.Height;

                // Crop the image
                var area = new Rectangle(left, top, cropWidth, cropHeight);
                emfImage.Crop(area);

                // Save the cropped image as GIF
                emfImage.Save(outputPath, new GifOptions());
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
 * 1. When a desktop application needs to extract the central 400×400 pixels from a Windows Metafile (EMF) and deliver it as a lightweight GIF for web preview.
 * 2. When a reporting tool generates vector charts in EMF format and must create a fixed‑size thumbnail GIF for inclusion in PDF or email summaries.
 * 3. When a batch‑processing service processes legacy EMF icons and crops their central area to a 400×400 pixel GIF to meet a mobile app’s asset size requirements.
 * 4. When a document conversion pipeline converts scanned EMF diagrams into GIF images and needs to focus on the central region to remove surrounding whitespace.
 * 5. When a C# utility automates the preparation of EMF logos for e‑commerce sites by cropping the core 400×400 pixel area and saving it as an optimized GIF.
 */