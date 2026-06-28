using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cmx";
        string outputPath = "output\\result.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                bool isMultiPage = false;
                if (image is IMultipageImage multipageImage)
                {
                    isMultiPage = multipageImage.PageCount > 1;
                }

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
 * 1. When a C# application processes CMX vector drawings and must decide whether to treat the file as a single page or iterate through multiple pages, it can use Image.IsMultiPage (via IMultipageImage) to detect multi‑page content.
 * 2. When converting batch CMX files to PDF or another format, a developer needs to know if the source image contains more than one page to generate separate PDF pages accordingly.
 * 3. When building a document management system that indexes CMX assets, checking the multi‑page flag helps decide whether to store each page as an individual record.
 * 4. When implementing a preview thumbnail generator for CMX files, detecting multiple pages allows the UI to display a page‑navigation control only when needed.
 * 5. When validating user‑uploaded CMX files in a web service, the code can quickly reject files with unexpected page counts by inspecting the Image.IsMultiPage property.
 */
