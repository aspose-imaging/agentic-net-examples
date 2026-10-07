// HOW-TO: Get Page Count From DjVu Document In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                Console.WriteLine($"Page count: {pageCount}");
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
 * 1. When you need to validate the number of pages in a DjVu file before batch converting it to another format.
 * 2. When you want to display the total pages of a DjVu document in a C# desktop or web application.
 * 3. When you must check page count to decide whether to split a large DjVu archive into smaller files.
 * 4. When you are building a document management system that logs DjVu page statistics for auditing purposes.
 * 5. When you need to ensure a DjVu file meets a required page limit before processing it with Aspose.Imaging.
 */
