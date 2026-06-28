using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cmx";
        string outputPath = "result.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                bool isMultiPage = image.IsMultiPage;
                Console.WriteLine($"Is multi-page: {isMultiPage}");
                File.WriteAllText(outputPath, isMultiPage.ToString());
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
 * 1. When a CAD application imports a CMX file and must decide whether to treat it as a single drawing or iterate through multiple pages for batch rendering.
 * 2. When a document conversion service processes CMX drawings and needs to split each page into separate PNG files only if the image is multi‑page.
 * 3. When an automated quality‑control script validates incoming CMX assets and logs a warning if a file contains more than one page, which could affect downstream printing.
 * 4. When a cloud‑based image viewer loads CMX files and uses the IsMultiPage flag to enable page navigation controls for end users.
 * 5. When a migration tool moves legacy CMX drawings to a new repository and must preserve page hierarchy by checking the multi‑page property before creating separate database entries.
 */