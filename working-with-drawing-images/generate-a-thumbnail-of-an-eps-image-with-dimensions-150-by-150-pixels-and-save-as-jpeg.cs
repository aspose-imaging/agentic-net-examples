using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "thumbnail.jpg";

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

            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Resize to 150x150 pixels
                epsImage.Resize(150, 150, ResizeType.NearestNeighbourResample);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When building a web portal that lists vector graphics, a developer can use this C# code with Aspose.Imaging to generate 150 × 150 pixel JPEG thumbnails of EPS files for fast preview in the browser.
 * 2. When creating a digital asset management system, the code helps produce small JPEG preview images from high‑resolution EPS logos so users can quickly identify assets without loading the full vector file.
 * 3. When sending EPS artwork as email attachments, a developer can generate a 150 × 150 pixel JPEG thumbnail to embed in the message body, giving recipients a visual cue of the content.
 * 4. When designing a desktop application that displays a gallery of vector icons, this snippet converts each EPS icon into a 150 × 150 pixel JPEG thumbnail for use as UI buttons or menu items.
 * 5. When implementing a search‑indexing pipeline, the code creates uniform 150 × 150 pixel JPEG thumbnails from EPS documents so the search engine can display consistent image previews in results.
 */