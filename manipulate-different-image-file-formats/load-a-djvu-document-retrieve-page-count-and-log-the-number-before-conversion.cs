// HOW-TO: Get Page Count From DjVu File Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.djvu";
        string outputPath = "output.tif";

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

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvuImage.PageCount;
                Console.WriteLine($"Total pages: {pageCount}");
                // Conversion logic can be added here.
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
 * 1. When you need to display the total number of pages in a DjVu document before further processing in a .NET application.
 * 2. When you want to verify that a DjVu file contains the expected page count prior to converting it to another format such as TIFF.
 * 3. When you are creating a batch job that logs page counts of multiple DjVu files for reporting or auditing purposes.
 * 4. When you must ensure the output directory exists before performing any image conversion on a DjVu document.
 * 5. When you need to handle missing DjVu files gracefully by checking file existence and reporting an error in a C# console program.
 */
