using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample.apng";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF metafile
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Configure rasterization so that text is rendered as shapes (no font dependency)
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.White,
                // Render text as bitmap shapes to preserve visual fidelity without fonts
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None
            };

            // Set up APNG save options and attach the rasterization options
            ApngOptions apngOptions = new ApngOptions
            {
                // Default frame duration (in milliseconds)
                DefaultFrameTime = 100,
                // Use the rasterization options defined above
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as a single‑frame APNG
            emfImage.Save(outputPath, apngOptions);
        }
    }
}