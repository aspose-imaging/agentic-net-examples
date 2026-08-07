using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\SourceImage.eps";
            string outputPath = @"C:\Images\Result\HighResImage.png";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image, resize it, and save as a high‑resolution PNG
            using (Image image = Image.Load(inputPath))
            {
                // Desired dimensions for the high‑resolution output
                int targetWidth = 2000;   // example width
                int targetHeight = 2000;  // example height

                // Resize using a high‑quality interpolation method
                image.Resize(targetWidth, targetHeight, ResizeType.Mitchell);

                // Save the resized image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a vector EPS logo into a high‑resolution PNG for web display, they can use this code to resize and export the image in a single step.
 * 2. When generating print‑ready assets from EPS artwork, the code enables automated scaling to the required DPI and saving as PNG for downstream workflows.
 * 3. When building a batch‑processing tool that ingests EPS files from a legacy design system and outputs PNG thumbnails at 2000×2000 pixels, this method provides the core conversion logic.
 * 4. When a C# application must ensure that an EPS diagram fits within a fixed layout size before embedding it in a PDF report, the code resizes the EPS and saves it as a PNG for easy inclusion.
 * 5. When creating a responsive UI that loads vector EPS icons and needs them rasterized at high quality for retina displays, the snippet performs the resize and PNG export in one operation.
 */