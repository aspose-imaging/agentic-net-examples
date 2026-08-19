// HOW-TO: Check If A CMX Image Has Multiple Pages In C# (Aspose.Imaging for .NET)
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

            using (Image image = Image.Load(inputPath))
            {
                CmxImage cmxImage = image as CmxImage;
                if (cmxImage == null)
                {
                    Console.WriteLine("The loaded file is not a CMX image.");
                    return;
                }

                bool isMultiPage = false;
                if (cmxImage is IMultipageImage multipage)
                {
                    isMultiPage = multipage.PageCount > 1;
                }

                Console.WriteLine($"Is multi-page: {isMultiPage}");
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
 * 1. When processing CAD drawings stored as CMX files, you may need to know if the file contains more than one page before extracting or converting each page.
 * 2. When building a batch conversion tool that converts each page of a CMX document to separate PNG images, you must first detect multi‑page files to handle them correctly.
 * 3. When validating user‑uploaded CMX files in a web application, checking the page count helps enforce limits on document size or complexity.
 * 4. When generating thumbnails for CMX documents, you may want to display a different icon for multi‑page files versus single‑page files.
 * 5. When integrating Aspose.Imaging with a document management system, detecting multi‑page CMX images allows you to store page metadata or split the document into individual pages.
 */
