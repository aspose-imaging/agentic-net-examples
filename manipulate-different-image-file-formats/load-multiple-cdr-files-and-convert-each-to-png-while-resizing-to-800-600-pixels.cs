using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input CDR files
        string[] inputPaths = {
            @"C:\Images\sample1.cdr",
            @"C:\Images\sample2.cdr"
        };

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PNG path (same folder, same name, .png extension)
            string outputPath = Path.ChangeExtension(inputPath, ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Process each page (CorelDRAW files can be multipage)
                foreach (CdrImagePage page in cdrImage.Pages)
                {
                    // Resize page to 800x600 pixels
                    page.Resize(800, 600);

                    // Save the resized page as PNG
                    PngOptions pngOptions = new PngOptions();
                    page.Save(outputPath, pngOptions);
                }
            }
        }
    }
}