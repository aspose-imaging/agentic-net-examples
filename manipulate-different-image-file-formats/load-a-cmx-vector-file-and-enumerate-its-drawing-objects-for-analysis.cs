using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Cmx.ObjectModel;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\analysis.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image with default load options
            var loadOptions = new CmxLoadOptions();
            using (CmxImage image = (CmxImage)Image.Load(inputPath, loadOptions))
            {
                // Access the underlying CMX document
                CmxDocument document = image.Document;

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine($"CMX Document contains {document.Pages.Count} page(s).");

                    int pageIndex = 0;
                    foreach (var page in document.Pages)
                    {
                        writer.WriteLine($"Page {pageIndex}:");

                        // Attempt to enumerate drawing objects via reflection
                        var objectsProp = page.GetType().GetProperty("Objects");
                        if (objectsProp != null)
                        {
                            var objects = objectsProp.GetValue(page) as System.Collections.IEnumerable;
                            if (objects != null)
                            {
                                int objIndex = 0;
                                foreach (var obj in objects)
                                {
                                    writer.WriteLine($"  Object {objIndex}: {obj}");
                                    objIndex++;
                                }
                            }
                            else
                            {
                                writer.WriteLine("  Objects collection is empty.");
                            }
                        }
                        else
                        {
                            writer.WriteLine("  No Objects collection found on this page.");
                        }

                        pageIndex++;
                    }
                }
            }

            Console.WriteLine($"Analysis written to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}