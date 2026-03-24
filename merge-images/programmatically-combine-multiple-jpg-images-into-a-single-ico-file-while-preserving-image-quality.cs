using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\icon1.jpg",
            @"C:\Images\icon2.jpg",
            @"C:\Images\icon3.jpg"
        };

        // Hard‑coded output ICO file
        string outputPath = @"C:\Images\combined.ico";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        IcoImage icoImage = null;
        try
        {
            // Load the first image to obtain width/height for the ICO canvas
            using (Image firstImg = Image.Load(inputPaths[0]))
            {
                // Create default ICO options (32‑bit PNG frames)
                IcoOptions icoOptions = new IcoOptions();

                // Initialise the ICO image with the size of the first frame
                icoImage = new IcoImage(firstImg.Width, firstImg.Height, icoOptions);

                // Add the first image as a page
                icoImage.AddPage(firstImg);
            }

            // Process remaining images and add them as additional pages
            for (int i = 1; i < inputPaths.Length; i++)
            {
                using (Image img = Image.Load(inputPaths[i]))
                {
                    icoImage.AddPage(img);
                }
            }

            // Save the combined ICO file
            icoImage.Save(outputPath);
        }
        finally
        {
            // Ensure the ICO image is disposed even if an error occurs
            icoImage?.Dispose();
        }
    }
}