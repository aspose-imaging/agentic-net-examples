using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.cmx";
        string outputPath = @"C:\Data\analysis\output.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (CmxImage image = (CmxImage)Image.Load(inputPath))
        {
            // Access the CMX document
            var document = image.Document;

            // Write analysis results
            using (var writer = new StreamWriter(outputPath))
            {
                writer.WriteLine($"CMX Document Analysis for: {inputPath}");
                writer.WriteLine($"Page count: {document.Pages.Count}");
                writer.WriteLine();

                int pageIndex = 0;
                foreach (var page in document.Pages)
                {
                    writer.WriteLine($"Page {pageIndex}: {page.GetType().Name}");

                    // List public properties of the page
                    var properties = page.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        try
                        {
                            var value = prop.GetValue(page);
                            writer.WriteLine($"  {prop.Name} = {value}");
                        }
                        catch
                        {
                            // Ignore properties that throw
                        }
                    }

                    writer.WriteLine();
                    pageIndex++;
                }
            }
        }
    }
}