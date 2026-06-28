using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Try to treat it as an APNG image
                var apng = image as ApngImage;
                if (apng != null && apng.PageCount > 0)
                {
                    // Extract the first frame
                    using (RasterImage firstFrame = (RasterImage)apng.Pages[0])
                    {
                        // Save the first frame as a static PNG
                        firstFrame.Save(outputPath, new PngOptions());
                    }
                }
                else
                {
                    // If not an APNG, save the loaded image directly as PNG
                    image.Save(outputPath, new PngOptions());
                }
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
 * 1. When a developer needs to generate a preview thumbnail for an animated APNG file in a web gallery, they can extract the first frame and save it as a static PNG using Aspose.Imaging for .NET.
 * 2. When integrating a content management system that only supports PNG images, the code can convert uploaded animated APNGs to a single‑frame PNG to ensure compatibility.
 * 3. When creating PDF reports that embed images, extracting the first frame from an APNG and saving it as a PNG allows the image to be rendered correctly in the document.
 * 4. When optimizing assets for mobile apps that cannot display animated APNGs, developers can use this C# snippet to convert the animation to a static PNG to reduce file size and simplify rendering.
 * 5. When performing batch processing of user‑submitted APNG stickers, the code can extract the initial frame and store it as a PNG for faster indexing and search in a database.
 */