using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputPaths = {
                @"C:\Images\sample1.cdr",
                @"C:\Images\sample2.cdr"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Images\Output";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to CdrImage to access pages
                    CdrImage cdrImage = image as CdrImage;
                    if (cdrImage == null)
                    {
                        Console.Error.WriteLine($"Unable to cast to CdrImage: {inputPath}");
                        continue;
                    }

                    // Process the first page (or the whole image if no pages)
                    if (cdrImage.Pages.Length > 0)
                    {
                        var page = cdrImage.Pages[0] as Aspose.Imaging.FileFormats.Cdr.CdrImagePage;
                        if (page != null)
                        {
                            // Resize page to 800x600
                            page.Resize(800, 600);
                            // Save as PNG
                            page.Save(outputPath);
                            continue;
                        }
                    }

                    // Fallback: resize the whole image and save
                    cdrImage.Resize(800, 600);
                    cdrImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}