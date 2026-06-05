using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.wmf";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image img = Image.Load(inputPath))
            {
                // Cast to EmfImage
                EmfImage emfImage = img as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid EMF image.");
                    return;
                }

                // Increase line thickness of all graphic records by 2 points
                // The Records collection contains various metafile records.
                // We use dynamic to access Pen.Width when the record supports it.
                for (int i = 0; i < emfImage.Records.Count; i++)
                {
                    dynamic record = emfImage.Records[i];
                    try
                    {
                        // If the record has a Pen property with a Width, increase it.
                        if (record.Pen != null && record.Pen.Width > 0)
                        {
                            record.Pen.Width += 2;
                        }
                    }
                    catch
                    {
                        // Ignore records that do not have a Pen or Width property.
                    }
                }

                // Save the modified image as WMF
                // Use WmfOptions for vector format saving.
                var wmfOptions = new WmfOptions
                {
                    // Preserve original size; no additional rasterization options needed.
                };
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
 * 1. When a developer needs to convert legacy vector graphics from EMF to WMF while making all lines bolder for better visibility in printed reports.
 * 2. When an application must programmatically thicken the strokes of diagram elements in an EMF file before embedding the image into a Windows Forms control that only supports WMF.
 * 3. When a batch processing tool updates technical schematics stored as EMF by increasing line weight to meet new corporate branding guidelines and saves them as WMF for compatibility with older CAD software.
 * 4. When a C# service generates printable invoices that include EMF logos, and the service needs to enhance the logo outlines by 2 points and output the result as a WMF file for Office document integration.
 * 5. When a migration script modernizes a document archive by loading each EMF illustration, enlarging its pen width for clearer on-screen rendering, and exporting the modified graphics to WMF format for legacy Windows applications.
 */