using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf.Graphics;

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
            // Attempt to increase line thickness for each record that contains a Pen
            foreach (var record in emfImage.Records)
            {
                var penProperty = record.GetType().GetProperty("Pen");
                if (penProperty != null)
                {
                    var pen = penProperty.GetValue(record) as Pen;
                    if (pen != null)
                    {
                        // Increase the pen width by 2 points
                        pen.Width += 2;
                    }
                }
            }

            // Save the modified image as WMF
            var wmfOptions = new WmfOptions();
            emfImage.Save(outputPath, wmfOptions);
        }
    }
}