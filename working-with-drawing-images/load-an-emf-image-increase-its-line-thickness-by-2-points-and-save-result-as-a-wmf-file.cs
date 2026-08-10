// HOW-TO: Increase EMF Line Thickness By 2 Points And Save As WMF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.wmf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Attempt to increase line thickness by 2 points.
                // The API does not provide a direct method, so we iterate over records
                // and adjust PenWidth where applicable.
                foreach (var record in emfImage.Records)
                {
                    // Many record types expose a PenWidth property; we use reflection to modify it safely.
                    var penWidthProp = record.GetType().GetProperty("PenWidth");
                    if (penWidthProp != null && penWidthProp.PropertyType == typeof(float))
                    {
                        float current = (float)penWidthProp.GetValue(record);
                        penWidthProp.SetValue(record, current + 2f);
                    }
                }

                // Save as WMF using WmfOptions
                var wmfOptions = new WmfOptions();
                emfImage.Save(outputPath, wmfOptions);
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
 * 1. When you need to programmatically thicken vector lines in an EMF diagram before converting it to WMF for legacy Windows applications.
 * 2. When a batch process must adjust the visual weight of graphics in EMF files to meet branding guidelines and then output them as WMF for compatibility with older printers.
 * 3. When integrating a .NET service that receives EMF artwork, enhances stroke widths, and stores the result as WMF for use in legacy reporting tools.
 * 4. When automating the preparation of technical drawings where line thickness must be increased to improve readability after converting from EMF to WMF.
 * 5. When migrating a collection of EMF icons to WMF format and you need to uniformly boost their pen widths to maintain consistent appearance across different Windows platforms.
 */
