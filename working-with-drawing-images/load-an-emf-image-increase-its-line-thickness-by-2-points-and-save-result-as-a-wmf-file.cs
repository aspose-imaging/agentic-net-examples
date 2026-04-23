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
            // Create a graphics object that contains all records from the EMF
            var graphics = Aspose.Imaging.FileFormats.Emf.Graphics.EmfRecorderGraphics2D.FromEmfImage(emfImage);

            // Increase line thickness by 2 points for every pen found in the records
            foreach (var record in emfImage.Records)
            {
                // Use dynamic to attempt accessing a Pen property if it exists
                dynamic dynRecord = record;
                try
                {
                    if (dynRecord.Pen != null)
                    {
                        dynRecord.Pen.Width += 2;
                    }
                }
                catch
                {
                    // Record does not contain a Pen; ignore
                }
            }

            // Finalize the modified EMF image
            using (EmfImage modifiedEmf = graphics.EndRecording())
            {
                // Prepare WMF save options
                var wmfOptions = new WmfOptions
                {
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        PageSize = modifiedEmf.Size
                    }
                };

                // Save the modified image as WMF
                modifiedEmf.Save(outputPath, wmfOptions);
            }
        }
    }
}