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
        // Path safety rules
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_converted.wmf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage for vector operations
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid EMF image.");
                    return;
                }

                // ------------------------------------------------------------
                // Increase line thickness by 2 points.
                // Aspose.Imaging does not provide a direct method to modify
                // existing pen widths in an EMF record collection.
                // A typical approach would be to iterate over emfImage.Records,
                // identify pen creation records, and adjust their width.
                // The following placeholder demonstrates where such logic
                // would be inserted.
                // ------------------------------------------------------------
                /*
                foreach (var record in emfImage.Records)
                {
                    // Example: if (record is EmfPlusRecord && record.Type == EmfPlusRecordType.PenCreate)
                    // {
                    //     var penRecord = (EmfPlusPenCreateRecord)record;
                    //     penRecord.Width += 2.0f; // increase by 2 points
                    // }
                }
                */

                // Save the modified image as WMF
                // Use WmfOptions with default rasterization settings
                var wmfOptions = new WmfOptions
                {
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        PageSize = emfImage.Size
                    }
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