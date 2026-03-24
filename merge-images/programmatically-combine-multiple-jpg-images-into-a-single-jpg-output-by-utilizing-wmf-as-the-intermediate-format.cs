using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputFiles = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Verify each input file exists
        foreach (var inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Create a multipage image from the JPG files
        using (Image multiPageImage = Image.Create(inputFiles))
        {
            // Intermediate WMF file path
            string wmfPath = @"C:\Images\combined.wmf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(wmfPath));

            // Save the multipage image as WMF (intermediate format)
            multiPageImage.Save(wmfPath, new WmfOptions());

            // Load the WMF image
            using (Image wmfImage = Image.Load(wmfPath))
            {
                // Final combined JPG output path
                string outputJpgPath = @"C:\Images\combined.jpg";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputJpgPath));

                // Save the WMF image as a single JPEG
                wmfImage.Save(outputJpgPath, new JpegOptions());
            }
        }
    }
}